namespace SigortaHasar.Entities
{
    public class Police
    {
        public string PoliceNo { get; set; }
        public int ZeyilNo { get; set; }
        public Arac Arac { get; set; }

        public int SureGun => (BitisTarihi - BaslangicTarihi).Days;

        public int  HasarsizlikKademe { get; set; }
        public List<PoliceTeminat> Teminatlar { get; set; }
        public List<Taksit> Taksitler { get; set; }

        public decimal BrutPrim { get; set; }
        public Musteri SigortaEttiren { get; set; }
        public Musteri Sigortali { get; set; }

        public string PoliceTuru { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
    }
}
