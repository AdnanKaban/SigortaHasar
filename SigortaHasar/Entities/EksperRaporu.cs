namespace SigortaHasar.Entities
{
    public class EksperRaporu
    {
        public DateTime RaporTarihi { get; set; }
        public decimal TespitEdilenHasarTutari { get; set; }
        public bool PertMi { get; set; }
        public int KusurOrani { get; set; }
        public string Aciklama { get; set; }
    }
}
