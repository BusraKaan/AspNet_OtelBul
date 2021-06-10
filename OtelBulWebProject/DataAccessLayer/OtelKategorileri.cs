using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OtelKategorileri
    {
        public int ID { get; set; }
        public int OtelID { get; set; }
        public int KategoriID { get; set; }
        public string Kategori { get; set; }
    }
}
