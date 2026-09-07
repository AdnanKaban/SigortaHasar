using SigortaHasar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigortaHasar.Business
{
    public class GecIhbarKurali : IHasarKurali
    {
        public KuralSonucu Kontrol(HasarDosyasi dosya)
        {
            const int maksIbarSuresi= 5;
            if ((dosya.IhbarTarihi - dosya.OlayTarihi).Days > maksIbarSuresi)
                return new KuralSonucu { Basarili = false, Mesaj = "İhbar Süresi Geçmiş" };
            else
                return new KuralSonucu {Basarili=true,Mesaj="İhbar Süresi içinde" };
        }
    }
}
