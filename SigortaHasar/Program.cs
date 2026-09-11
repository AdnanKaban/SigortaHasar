using SigortaHasar.Business;
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
var dosya = hasarService.GetByDosyaNo("H001");
var gecisler = hasarService.GetGecerliGecisler(dosya);
Console.WriteLine($"Mevcut durum: {dosya.Durum}");
if (gecisler.Count == 0)
{
    Console.WriteLine("Bos dosya ");
}
for(int i=0;i<gecisler.Count; i++)
{
    Console.WriteLine($"{i + 1} - {gecisler[i]}");
}
Console.WriteLine("Yapılacak Durum değişikliğinini numara olarak secin" +
    "");
string girdi = Console.ReadLine();
if (int.TryParse(girdi, out int secim) && secim >= 1 && secim <= gecisler.Count)
{
    var sonuc = hasarService.DurumDegistir(dosya, gecisler[secim - 1]);
}
else
{
    Console.WriteLine("Geçersiz seçim");
}
Console.WriteLine($"Yeni  durum: {dosya.Durum}");
foreach (var g in dosya.DurumGecmisi)
    Console.WriteLine($"{g.Tarih:dd.MM.yyyy HH:mm} — {g.EskiDurum} durumundan  {g.YeniDurum} durumuna geçti ({g.IslemiYapan})");
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