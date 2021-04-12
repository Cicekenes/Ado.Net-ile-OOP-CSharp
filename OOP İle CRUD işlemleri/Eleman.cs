using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_İle_CRUD_işlemleri
{
    public class Eleman
    {
        public short ID { get; set; } //short olma sebebi veritabanımızda smallint kullanmamızdır.
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string MESLEK { get; set; }
        public short MAAS { get; set; }
        public string SEHIR { get; set; }
        public string UNIVERSITE { get; set; }
    }
}
