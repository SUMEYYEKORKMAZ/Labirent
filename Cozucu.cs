using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirent
{
    internal class Cozucu
    {

        public static List<Hucre> cikisyolukoordinat = new List<Hucre>(); // Doğru çıkış yolu bulunduğu zaman gezilen hücreler daha sonradan çıktı vermek için burada liste içerisinde tutulur.
        public static bool Coz(Hucre hucre, bool gorselmod)
        {

            if (Labirent.matris[hucre.hsatir, hucre.hsutun] == 2)    // Koşul bloklarıyla bombaya rastlandığında oyunun durması sağlanmıştır.
            {
                Console.WriteLine("Bombaya rastlandı");
                Console.Beep(2000, 1000);
                Environment.Exit(0);

            }
            Labirent.matris[hucre.hsatir, hucre.hsutun] = 3;    // Gezilen hücrelere 3 değeri atanarak tekrar gezmesi engellenmiştir
            if (hucre.hsutun == 29)
            {
                Labirent.matris[hucre.hsatir, hucre.hsutun] = 4;     // Daha sonradan doğru çıkış yolunun gösterilebilmesi için doğru yol hücrelerine 4 değeri atanmıştır.
                cikisyolukoordinat.Add(hucre);
                return true;

            }



            KomsulariEkle(hucre);


            if (gorselmod)
                Yazici.GorselMod();


            foreach (Hucre komsu in hucre.Komsular)
            {
                if (Labirent.matris[komsu.hsatir, komsu.hsutun] == 0 || Labirent.matris[komsu.hsatir, komsu.hsutun] == 2)
                {
                    bool isFound = Coz(komsu, gorselmod); // 4 veya 3 nolu hücreleri gezmez sadece daha önce gitmediği (0 veya 2(bomba) olan yerlere gider.)
                    if (isFound == true)
                    {
                        Labirent.matris[hucre.hsatir, hucre.hsutun] = 4;  // Doğru çıkış yolu hücrelerine 4 değerini atar.
                        cikisyolukoordinat.Add(hucre);   // Çıkış yolu hücrelerinin koordinatlarını tutmak için liste oluştur ve koordinantları buraya atar.
                        return true;
                    }

                }

            }

            return false;
        }



        private static void KomsulariEkle(Hucre hucre)  // Komşu hücreleri bulur ve bu hücreleri Komşular listesine ekler.


        {
            if (hucre.hsatir - 1 >= 0)   // Matrisin dışına çıkmaması için kontrol sağlanır.
            {
                Hucre yukari = new Hucre(hucre.hsatir - 1, hucre.hsutun);
                hucre.Komsular.Add(yukari);   //Listeye ekleme işlemi yapılır.

            }
            if (hucre.hsutun + 1 < 30)
            {
                Hucre sag = new Hucre(hucre.hsatir, hucre.hsutun + 1);
                hucre.Komsular.Add(sag);
            }
            if (hucre.hsatir + 1 < 30)
            {
                Hucre asagi = new Hucre(hucre.hsatir + 1, hucre.hsutun);
                hucre.Komsular.Add(asagi);
            }
            if (hucre.hsutun - 1 >= 0)
            {
                Hucre sol = new Hucre(hucre.hsatir, hucre.hsutun - 1);
                hucre.Komsular.Add(sol);
            }
        }
    }
}
