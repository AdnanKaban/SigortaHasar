using SigortaHasar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigortaHasar.Business.Interfaces
{
    public  interface IHasarKurali
    {
       KuralSonucu Kontrol(HasarDosyasi dosya);
       
        
         
    }
}
