using SigortaHasar.Business.Interfaces;
using SigortaHasar.Entities;


namespace SigortaHasar.Business.Kurallar
{
    public class PrimBorcuKurali : IHasarKurali
    {
        public KuralSonucu Kontrol(HasarDosyasi dosya)
        {
            if (dosya.Police.Taksitler == null) 
            {
                return new KuralSonucu { Basarili = true, Mesaj = "" };

            }
            if (dosya.Police.Taksitler.Any(t => t.Odendimi == false &&t.VadeTarihi<DateTime.Now))
            {
                return new KuralSonucu { Basarili = false, Mesaj = "Taksit ödenmedi" };
            }
            
            
                return new KuralSonucu { Basarili = true, Mesaj = "Prim Bilgisi Bulundu " };
            

        }
    }
}
