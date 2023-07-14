using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirent
{
    internal class Hucre
    {
        public Hucre(int hsatir, int hsutun)       // HÜcrenin satır ve sütun gibi özellikleir olduğu için obje olarak tanımlanır.
        {
            this.hsatir = hsatir;
            this.hsutun = hsutun;
        }
        public int hsatir;
        public int hsutun;

        public List<Hucre> Komsular = new List<Hucre>();  // Komşular listesi oluşturulur.

    }

}

