using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OtelHizmetleri
    {
        public int ID { get; set; }
        public int OtelID { get; set; }
        public int HizmetID { get; set; }
        public string HizmetAdi { get; set; }
        public bool HizmetDurumu { get; set; }
    }
}
