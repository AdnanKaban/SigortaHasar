namespace SigortaHasar.Entities
{
    public class HasarDosyasi
    {
        public string DosyaNo { get; set; }
        public Police Police { get; set; }

        public DateTime OlayTarihi { get; set; }
        public DateTime IhbarTarihi { get; set; }
        public HasarDurumu Durum { get; set; }
        public string RedSebebi { get; set; }

        public decimal TahminiHasarTutari { get; set; }
        public decimal OnaylananTutar { get; set; }
        public decimal OdenenTutar { get; set; }
       public string Aciklama { get; set; }


        public Eksper AtananEksper { get; set; }
        public EksperRaporu EksperRaporu { get; set; }
        public List<Belge> Belgeler { get; set; } = new List<Belge>();
        public List<Odeme> Odemeler { get; set; } = new List<Odeme>();
        public List<DurumGecmisi> DurumGecmisi { get; set; } = new List<DurumGecmisi>();
    }
}
