namespace SigortaHasar.Entities
{
    public  class DurumGecmisi
    {
        public HasarDurumu EskiDurum { get; set; }
        public HasarDurumu YeniDurum { get; set; }
        public DateTime Tarih { get; set; }
        public string IslemiYapan { get; set; }
    }
}
