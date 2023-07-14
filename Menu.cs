using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Labirent
{
    internal class Menu
    {

        public static void Giris()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("LABİRENTE HOŞGELDİNİZ...");
            Thread.Sleep(600);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Labireti çözmek için : 1 'e basınız.");
            Console.WriteLine("labirent oluşturmak için :2 'e basınız.");       
            Console.WriteLine("Görsel moda geçmek için : 3'e basınız");

            string input = KullaniciInput(); // Kullanıcıda girdi alınır.
            Console.Clear(); // Ekranı temizler.

            if (input == "1")             
            {
                try  // Herhangi bir hata oluşursa çıktı verir.
                {

                    string dosya_yolu = DosyaYoluAL();
                    Labirent.DosyaOku(dosya_yolu);         // Text dosyasını okur ve matrise atar.
                    Labirent.BombaUret();       // Rstgele bomba üretir ve matriste rastgeler hücrelere yrleştirir.

                    CozucuMenusuYaz();


                    while (true)     // Kullanıcı birden fazla istekte bulunduğunda uygulama kapanmasın diye sonsuz döngü oluştur.
                    {
                        while ((input = KullaniciInput()) != "Q")   // Girilen harflere göre metotlar çağırırlır.
                        {
                            Console.Clear();

                            if (input == "X")
                            {
                                if (CozmeyiBaslat(false))
                                {

                                    Yazici.dogruyoluYazdir();
                                    Console.WriteLine("\n\n\n\n\n\n");

                                }
                                else
                                    Console.WriteLine("ÇIKIŞ YOK\n\n\n\n\n\n");

                            }

                            else if (input == "B")
                            {
                                Yazici.BombalarıGoster();
                                Console.WriteLine("\n\n\n\n\n\n");
                            }
                            else if (input == "L")
                            {
                                Yazici.MatrisiYazdir();
                                Console.WriteLine("\n\n\n\n\n\n");
                            }
                            else if (input == "K")
                            {
                                if (CozmeyiBaslat(false))
                                {
                                    Yazici.CikisKoordinatYazdir();
                                    Console.WriteLine("\n\n\n\n\n\n");
                                }
                                else
                                    Console.WriteLine("ÇIKIŞ YOK\n\n\n\n\n\n");
                            }
                            CozucuMenusuYaz();
                        }
                        Console.Clear();
                        CozucuMenusuYaz();
                    }


                }
                catch
                {
                    Console.WriteLine("Bir hata alındı.");

                }



            }
            else if (input == "2")  //********** labirent oluştur kısmını yap ************
            {
                Labirent_Uret.MatrisUretme();
                Labirent_Uret.YolCizme();
                Console.WriteLine("Dosya adını giriniz:");
                string dosya_adi = KullaniciInput();
                Yazici.DosyayaYazdirma(Labirent.matris, dosya_adi);
                Console.WriteLine("Dosyanız oluşturuldu.");
                Thread.Sleep(3000);

            }
            else if (input == "3")  //Görsel olarak çözümü görüntüleme seçeneği eklenir.
            {
                string dosya_yolu = DosyaYoluAL();
                Labirent.DosyaOku(dosya_yolu);
                Labirent.BombaUret();
                CozmeyiBaslat(true);
                Yazici.dogruyoluYazdir();
                Thread.Sleep(600);
                Yazici.GorselMod();       // Labirent üzerinden çıkış yolunu bulma olayı gösterilir.


            }


        }


        public static string KullaniciInput()
        {
            return Console.ReadLine();
        }


        public static string DosyaYoluAL()
        {
            Console.WriteLine("Dosya yolunu giriniz");
            return Console.ReadLine();
        }

        public static void CozucuMenusuYaz()
        {
            Console.WriteLine("Labirent üzerinde çıkış yolunu görmek istiyorsanız : X 'e basınız.");
            Console.WriteLine("Labirent üzerinde bombaları görmek istiyorsanız : B 'e basınız.");
            Console.WriteLine("Labirentin orjinalini görmek istiyorsanız : L 'e basınız.");
            Console.WriteLine("Çıkış yolu koordinatları için : K ' ye basınız");
            Console.WriteLine("Temizlemek için : Q 'e basınız.");



        }

        public static bool CozmeyiBaslat(bool gorselmod)
        {
            for (int i = 0; i < 30; i++)
            {
                if (Labirent.matris[i, 0] == 0)
                {
                    Hucre giris = new Hucre(i, 0);
                    if (Cozucu.Coz(giris, gorselmod) == true)
                        return true;


                }
            }
            return false;


        }
    }
}
