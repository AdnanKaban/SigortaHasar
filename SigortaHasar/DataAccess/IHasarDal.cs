using SigortaHasar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigortaHasar.DataAccess
{
    public  interface IHasarDal
    {
        List<HasarDosyasi> GetAll();
        HasarDosyasi GetByDosyaNo(string dosyaNo);
        public void Add(HasarDosyasi dosya);


    }
}
