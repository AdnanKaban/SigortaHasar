using SigortaHasar.Business.Interfaces;
using SigortaHasar.Business.Kurallar;
using SigortaHasar.DataAccess;
using SigortaHasar.Entities;
using System.Security.Cryptography;
namespace SigortaHasar.Business
{
    public class HasarManager : IHasarService
    {
        private IHasarDal _hasarDal;
        private List<IHasarKurali> _kurallar;
        private Dictionary<HasarDurumu, List<HasarDurumu>> _gecerliGecisler;


        public HasarManager(IHasarDal hasarDal)
        {
            _hasarDal = hasarDal;
            _kurallar = new List<IHasarKurali>{
                new PoliceGecerlilikKurali(),
                new GecIhbarKurali(),
                new PrimBorcuKurali()

            };
            _gecerliGecisler = new Dictionary<HasarDurumu, List<HasarDurumu>> {
               { HasarDurumu.Acik, new List<HasarDurumu> { HasarDurumu.Eksperde, HasarDurumu.Reddedildi } },
               { HasarDurumu.Eksperde, new List<HasarDurumu> { HasarDurumu.Acik, HasarDurumu.Degerlendirmede, HasarDurumu.Reddedildi } },
                { HasarDurumu.Degerlendirmede, new List<HasarDurumu> { HasarDurumu.Eksperde, HasarDurumu.Onaylandi, HasarDurumu.Reddedildi } },
                { HasarDurumu.Onaylandi, new List<HasarDurumu> { HasarDurumu.Odendi, HasarDurumu.Reddedildi } },
                { HasarDurumu.Reddedildi, new List<HasarDurumu>() }, 
                { HasarDurumu.Odendi, new List<HasarDurumu>() }
               };
            
        }

        public KuralSonucu DurumDegistir(HasarDosyasi dosya, HasarDurumu yeniDurum) 
        {

            if (dosya == null || !_gecerliGecisler.ContainsKey(dosya.Durum))
            {
                return new KuralSonucu { Basarili = false,Mesaj="Gecersiz dosya veya tanımsız durum" };
            }
            var izinliler = _gecerliGecisler[dosya.Durum];
            if (!izinliler.Contains(yeniDurum))
            {
                return new KuralSonucu { Basarili = false, Mesaj = $"{dosya.Durum} durumundan {yeniDurum} durumuna geçilemez" };
            }
            var kayit = new DurumGecmisi
            {
                EskiDurum = dosya.Durum,
                YeniDurum = yeniDurum,
                Tarih = DateTime.Now,
                IslemiYapan = "Sistem"
            };
            if (dosya.DurumGecmisi == null)
                dosya.DurumGecmisi = new List<DurumGecmisi>();

            dosya.DurumGecmisi.Add(kayit);
            dosya.Durum=yeniDurum;
            return new KuralSonucu { Basarili = true };
            
            
       
        }

        public List<HasarDurumu> GetGecerliGecisler(HasarDosyasi dosya)
        {
            if (dosya == null || !_gecerliGecisler.ContainsKey(dosya.Durum))
            {
                return new List<HasarDurumu>();
            }
            return _gecerliGecisler[dosya.Durum].ToList();
        }
        public KuralSonucu HasarIhbariniDegerlendir(HasarDosyasi dosya)
        {
            foreach (var kural in _kurallar)
            {
                var sonuc = kural.Kontrol(dosya);
                if (!sonuc.Basarili)
                    return sonuc;     
            }

            return new KuralSonucu { Basarili = true };
        }
        private const int IhbarSuresiGun = 5;
        public List<HasarDosyasi> GetAll()
        {
            return _hasarDal.GetAll();
        }
        public HasarDosyasi GetByDosyaNo(string DosyaNo)
        {
            return _hasarDal.GetByDosyaNo(DosyaNo);
        }
        public List<HasarDosyasi> GetAcikDosyalar()
        {
            return _hasarDal.GetAll().Where(d => d.Durum == HasarDurumu.Acik).ToList();
        }
        public List<HasarDosyasi> GetReddedilenDosyalar()
        {
            return _hasarDal.GetAll().Where(d => d.Durum == HasarDurumu.Reddedildi).ToList();
        }
        public List<HasarDosyasi> GetGecIhbarEdilenler()
        {
            return _hasarDal.GetAll().Where(d => (d.IhbarTarihi - d.OlayTarihi).Days > IhbarSuresiGun).ToList();
        }


    }
}
