using SigortaHasar.Entities;
namespace SigortaHasar.DataAccess
{
    public class InMemoryHasarDal:IHasarDal
    {

        private List<HasarDosyasi> _dosyalar;
        public InMemoryHasarDal()
        {
            // --- MÜŞTERİLER ---


            Musteri m1 = new Musteri
            {
                MusteriNo = 1,
                AdSoyad = "Ali Yılmaz",
                TcKimlikNo = "11111111111"
            };

            Musteri m2 = new Musteri
            {
                MusteriNo = 2,
                AdSoyad = "Mehmet Yılmaz",
                TcKimlikNo = "22222222222"
            };

            Musteri m3 = new Musteri
            {
                MusteriNo = 3,
                AdSoyad = "Ayşe Kaya",
                TcKimlikNo = "33333333333"
            };

            // --- ARAÇLAR ---
            Arac a1 = new Arac
            {
                PlakaNo = "34ABC123",
                Marka = "Dacia",
                ModelYili = 2013
            };

            Arac a2 = new Arac
            {
                PlakaNo = "06DEF456",
                Marka = "Ford",
                ModelYili = 2018
            };

            Arac a3 = new Arac
            {
                PlakaNo = "35GHI789",
                Marka = "Renault",
                ModelYili = 2021
            };

            // --- POLİÇELER ---
            // P1: Standart aktif poliçe (2024 - 2025)
            Police p1 = new Police
            {
                PoliceNo = "P001",
                Sigortali = m1,
                SigortaEttiren = m1,
                Arac = a1,
                BaslangicTarihi = new DateTime(2025, 10, 12),
                BitisTarihi = new DateTime(2026, 10, 12)
            };

            // P2: Süresi dolmuş/eski poliçe (2023 - 2024 tarihlerini test etmek için)
            Police p2 = new Police
            {
                PoliceNo = "P002",
                Sigortali = m1,
                SigortaEttiren = m1,
                Arac = a1,
                BaslangicTarihi = new DateTime(2023, 01, 01),
                BitisTarihi = new DateTime(2024, 01, 01)
            };

            // P3: Sigortalı != Sigorta Ettiren durumu (Sigortalı: Oğul/m1, Ettiren/Ödeyen: Baba/m2)
            Police p3 = new Police
            {
                PoliceNo = "P003",
                Sigortali = m1,
                SigortaEttiren = m2,
                Arac = a2,
                BaslangicTarihi = new DateTime(2024, 05, 01),
                BitisTarihi = new DateTime(2025, 05, 01)
            };

            // --- HASAR DOSYALARI ---
            HasarDosyasi h1 = new HasarDosyasi
            {
                DosyaNo = "H001",
                Police = p1,
                OlayTarihi = new DateTime(2025, 03, 10),
                IhbarTarihi = new DateTime(2025, 03, 11),
                Durum = HasarDurumu.Acik,
                TahminiHasarTutari = 25000
            };

            HasarDosyasi h2 = new HasarDosyasi
            {
                DosyaNo = "H002",
                Police = p1,
                OlayTarihi = new DateTime(2025, 04, 15),
                IhbarTarihi = new DateTime(2025, 04, 16),
                Durum = HasarDurumu.Eksperde,
                TahminiHasarTutari = 42000
            };


            HasarDosyasi h3 = new HasarDosyasi
            {
                DosyaNo = "H003",
                Police = p2,
                OlayTarihi = new DateTime(2024, 05, 10),
                IhbarTarihi = new DateTime(2024, 05, 12),
                Durum = HasarDurumu.Reddedildi,
                TahminiHasarTutari = 18500,
                RedSebebi = "Olay tarihi poliçe teminat süresi dışındadır."
            };


            HasarDosyasi h4 = new HasarDosyasi
            {
                DosyaNo = "H004",
                Police = p3,
                OlayTarihi = new DateTime(2024, 11, 01),
                IhbarTarihi = new DateTime(2024, 11, 02),
                Durum = HasarDurumu.Odendi,
                TahminiHasarTutari = 12000,
                OnaylananTutar = 12000,
                OdenenTutar = 12000
            };

            HasarDosyasi h5 = new HasarDosyasi
            {
                DosyaNo = "H005",
                Police = p3,
                OlayTarihi = new DateTime(2025, 01, 10),
                IhbarTarihi = new DateTime(2025, 02, 25),
                Durum = HasarDurumu.Reddedildi,
                TahminiHasarTutari = 60000,
                RedSebebi = "Geç ihbar bildirimi yapılmıştır."
            }; 
            _dosyalar = new List<HasarDosyasi> { h1, h2, h3, h4, h5 };

        }
  

        public void Add(HasarDosyasi dosya)
        {
            _dosyalar.Add(dosya);
        }

        public List<HasarDosyasi> GetAll()
        {

            return _dosyalar.ToList();
        }

        public HasarDosyasi GetByDosyaNo(string dosyaNo)
        {

            return _dosyalar.FirstOrDefault(d => d.DosyaNo == dosyaNo);
        }
    }
}
