using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Bu kütüphane eklenerek text dosyalarını System.IO kodu yazmadan kullanılabilir

namespace Labirent
{
    internal class Labirent
    {
        public static int[,] matris = new int[30, 30];
        public static void DosyaOku(string dosya_yolu)
        {

            string[] dosya = File.ReadAllLines(dosya_yolu);


            int satir = 0;
            int sutun = 0;

            foreach (var str in dosya)        // Dosyadaki tüm satırları okuması için foreach döngüsü kullanılır.
            {
                foreach (var harf in str)
                {
                    if (satir == 30)        // 30 satırlık bir matris oluşumunu kontrol eder.
                        break;

                    if (harf == '0' || harf == '1')      //  Text dosyasındaki 1 ve 0 değerlerini matrisde sıralar.
                    {
                        matris[satir, sutun] = harf == '0' ? 0 : 1;

                        if (sutun == 29)
                        {
                            sutun = 0;
                            satir++;
                        }
                        else
                        {
                            sutun++;
                        }
                    }
                }


            }
        }


        public static void MatrisiYazdir()       // MAtrisi yazdırmak için metot oluşturulur.
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                    Console.Write($"{matris[i, j]} ");
                Console.Write("\n");
            }

        }

        public static void BombaUret()    // Matris üzerinden rastgele konumlar belirlenir ve bu hücrelere bomba görevini görmesi için 2 değeri atanır.
        {
            int x = 0;
            int y = 0;
            Random rast = new Random();
            for (int i = 0; i < 3; i++)
            {
                x = rast.Next(0, 30);
                y = rast.Next(0, 30);
                matris[x, y] = 2;


            }
        }

    }
}
