using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labirent
{
    internal class Labirent_Uret
    {
        public static void MatrisUretme()  // Rastgele 0 ve 1 ile matris üretilir.

        {
            Random rast1 = new Random();
            int x = 0, y = 0;

            for (x = 0; x <= 29; x++)
            {
                for (y = 0; y <= 29; y++)
                {

                    Labirent.matris[x, y] = rast1.Next(0, 2);
                    Console.Write($"{Labirent.matris[x, y]} ");
                }

                Console.Write("\n");

            }

        }


        public static void YolCizme()  // Başlangıç satırı random seçilir ve daha sonra komşularına giderek 0 yazarak yol çizer. Bu da labirentin en az bir çözümü olmasını sağlar.
        {
            int sutun = 0;
            Random rast2 = new Random();
            int baslangic = rast2.Next(0, 30);
            Labirent.matris[baslangic, sutun] = 0;
           

            while (sutun != 29)

            {
                int gidisat = rast2.Next(0, 4);

                if (gidisat == 0)
                {

                    Labirent.matris[baslangic, sutun + 1] = 0;
                    sutun = sutun + 1;

                }

                if (gidisat == 1 && baslangic + 1 != 30)
                {


                    Labirent.matris[baslangic + 1, sutun] = 0;
                    baslangic = baslangic + 1;


                }
                if (gidisat == 2 && baslangic - 1 != -1)
                {

                    Labirent.matris[baslangic - 1, sutun] = 0;
                    baslangic = baslangic - 1;




                }
                if (gidisat == 3 && sutun - 1 != -1)
                {

                    Labirent.matris[baslangic, sutun - 1] = 0;
                    sutun = sutun - 1;
                }



            }
        }
 
    }
}
