using SigortaHasar.DataAccess;
using SigortaHasar.Entities;
namespace SigortaHasar.Business
{
    public  class HasarManager:IHasarService
    {
       private IHasarDal _hasarDal;
       

        public HasarManager(IHasarDal hasarDal)
        {
            _hasarDal = hasarDal;
        }
        private const int IhbarSuresiGun = 5;
        public List<HasarDosyasi> GetAll()
        {
            return _hasarDal.GetAll();
        }
        public HasarDosyasi GetByDosyaNo(string DosyaNo)
        {
            return _hasarDal.GetByDosyaNo(DosyaNo);
        }
        public List<HasarDosyasi> GetAcikDosyalar()
        {
            return _hasarDal.GetAll().Where(d => d.Durum == HasarDurumu.Acik).ToList();
        }
        public List<HasarDosyasi> GetReddedilenDosyalar() 
        { 
                return _hasarDal.GetAll().Where(d => d.Durum == HasarDurumu.Reddedildi).ToList();
        }
        public List<HasarDosyasi> GetGecIhbarEdilenler()
        {
            return _hasarDal.GetAll().Where(d =>( d.IhbarTarihi-d.OlayTarihi).Days > IhbarSuresiGun).ToList();
        }
    }
}
