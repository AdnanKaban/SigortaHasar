using SigortaHasar.Business.Interfaces;
using SigortaHasar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigortaHasar.Business.Kurallar
{
    public class PoliceGecerlilikKurali : IHasarKurali
    {
        public KuralSonucu Kontrol(HasarDosyasi dosya)
        {
          
            if (dosya.OlayTarihi < dosya.Police.BaslangicTarihi ||
        dosya.OlayTarihi > dosya.Police.BitisTarihi)
            {
                return new KuralSonucu { Basarili = false, Mesaj = "Olay poliçe süresinin dışında gerçekleşmiş " };
            }
            else { return new KuralSonucu { Basarili = true, Mesaj = "Olay poliçe süresi içinde gerçekleşmiş" }; }
        }
    }
}
