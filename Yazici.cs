using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Labirent
{
    internal class Yazici
    {
        public static void MatrisiYazdir()        // Matrisi yazdırabilmek için iç içe döngülerden olmuşmuş bir metot yazılır.
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (Labirent.matris[i, j] == 2 || Labirent.matris[i, j] == 3 || Labirent.matris[i, j] == 4)
                        Console.Write("0 ");
                    else
                        Console.Write($"{Labirent.matris[i, j]} ");

                }
                Console.Write("\n");

            }
        }


        public static void GorselMod()   // Görsel olarak ve adım adım çözümü görebilmek için metot oluşturulur.
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (Labirent.matris[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X ");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (Labirent.matris[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Write("B ");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }


                    else
                        Console.Write($"{Labirent.matris[i, j]} ");
                }
                Console.Write("\n");
            }
            Thread.Sleep(5000);
            Console.Clear();
        }



        public static void BombalarıGoster()   // Bombaların konumunu kullanıcıya "B" harfiyle gösterebilmek için metot yazılır.
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (Labirent.matris[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("B ");
                        Console.ForegroundColor = ConsoleColor.Green;


                    }
                    else if (Labirent.matris[i, j] == 3 || Labirent.matris[i, j] == 4)
                        Console.Write("0 ");
                    else
                        Console.Write($"{Labirent.matris[i, j]} ");
                }
                Console.Write("\n");
            }

        }




        public static void dogruyoluYazdir()  // Matris üzerinden doğru çıkış hücrelerini "X" biçiminde gösterebilmek için metot yazılır.
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (Labirent.matris[i, j] == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("X ");
                        Console.ForegroundColor = ConsoleColor.Green;

                    }
                    else if (Labirent.matris[i, j] == 3)
                        Console.Write("0 ");


                    else
                        Console.Write($"{Labirent.matris[i, j]} ");
                }
                Console.Write("\n");
            }
        }


        public static void CikisKoordinatYazdir()    // Doğru Çıkış yolunun koordinatlarını yazdırmak için hazırlanmış mtot.
        {
            Cozucu.cikisyolukoordinat.Reverse();   // HÜcreler çıkış noktasından true ya döndüğü için yazdırırken tersten yazdırılır.

            foreach (Hucre yol in Cozucu.cikisyolukoordinat)    // Gittiği hüreleri teker teker yazdırmak için foreach kullanılır.
            {
                Console.WriteLine($"[{yol.hsatir},{yol.hsutun}]");

            }

        }
        public static void DosyayaYazdirma(int[,] matris, string dosya_adi)
        {
            string dosya = "";
            dosya += "{";

            for (int i = 0; i < 30; i++)
            {
                dosya += "{";
                for (int j = 0; j < 30; j++)
                {
                    if (j == 29)
                        dosya += $"{matris[i, j]}";
                    else
                        dosya += $"{matris[i, j]},";

                }
                if (i == 29)
                    dosya += "}";
                else
                    dosya += "}\n";
            }

            dosya += "}";


            File.WriteAllText(dosya_adi, dosya);

        }


    }
}
