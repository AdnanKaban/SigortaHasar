using SigortaHasar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigortaHasar.Business.Interfaces
{
    public interface IHasarService
    {
        List<HasarDosyasi> GetAll();
        HasarDosyasi GetByDosyaNo(string dosyaNo);
        List<HasarDosyasi> GetAcikDosyalar();
        List<HasarDosyasi> GetReddedilenDosyalar();
        List<HasarDosyasi> GetGecIhbarEdilenler();
        KuralSonucu HasarIhbariniDegerlendir(HasarDosyasi dosya);
    }
}
