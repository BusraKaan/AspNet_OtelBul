using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorumlar
    {
        public string Baslik { get; set; }
        public string Yorum { get; set; }
        public DateTime YorumTarihi { get; set; }
        public int OtelID { get; set; }
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
    }
}
