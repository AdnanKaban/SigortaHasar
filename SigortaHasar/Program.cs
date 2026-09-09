using SigortaHasar.Business;
using SigortaHasar.Business.Constructor;
using SigortaHasar.Business.Interfaces;
using SigortaHasar.DataAccess;

IHasarDal hasarDal = new InMemoryHasarDal();
var dosyalar = hasarDal.GetAll();

foreach (var d in dosyalar)
    Console.WriteLine(d.DosyaNo);
IHasarService hasarService = new HasarManager(hasarDal);

foreach (var d in hasarService.GetAll())
{
    var s = hasarService.HasarIhbariniDegerlendir(d);
    if (s.Basarili)
        Console.WriteLine($"{d.DosyaNo}: Kabul edildi");
    else
        Console.WriteLine($"{d.DosyaNo}: Reddedildi - {s.Mesaj}");
}


// ... diğer sorgular ...
//foreach (var d in dosyalar.Where(d => d.Durum == HasarDurumu.Acik))
//    Console.WriteLine(d.DosyaNo);
//Console.WriteLine("--------------------------------------------------");
//Console.WriteLine("Reddedilen Hasar Dosyaları:");
//foreach (var d in dosyalar.Where(d => d.Durum == HasarDurumu.Reddedildi))
//    Console.WriteLine($"{d.DosyaNo} - {d.RedSebebi}");
//Console.WriteLine("--------------------------------------------------");
//Console.WriteLine("Ödenen Hasar Dosyaları Tutarları:");
//foreach (var d in dosyalar.Where(d => d.Durum == HasarDurumu.Odendi))
//    Console.WriteLine($"{d.DosyaNo} - Ödenen Tutar: {d.OdenenTutar:C}");
//Console.WriteLine("--------------------------------------------------");
//Console.WriteLine("Geç ihbar bildirimi nedeniyle reddedilen dosyalar:");
//foreach (var d in dosyalar.Where(d =>(d.IhbarTarihi - d.OlayTarihi).Days > 5))
//    Console.WriteLine($"{d.DosyaNo} - {d.RedSebebi}");
//Console.WriteLine("--------------------------------------------------");
//Console.WriteLine("Bugün geçerli olan poliçeler:");
//foreach (var p in policeler.Where(
//    p => p.BaslangicTarihi <= DateTime.Now && 
//    p.BitisTarihi >= DateTime.Now))
//    Console.WriteLine($"{p.PoliceNo} - Sigortalı: {p.Sigortali.AdSoyad}" +
//                         $" - Araç: {p.Arac.Marka} {p.Arac.ModelYili}");