using SigortaHasar.DataAccess;
using SigortaHasar.Entities;
namespace SigortaHasar.Business
{
    public class HasarManager : IHasarService
    {
        private IHasarDal _hasarDal;
       private List<IHasarKurali> _kurallar ;


        public HasarManager(IHasarDal hasarDal)
        {
            _hasarDal = hasarDal;
            _kurallar = new List<IHasarKurali>
            {
                new PoliceGecerlilikKurali(),
                new GecIhbarKurali()
            };
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
