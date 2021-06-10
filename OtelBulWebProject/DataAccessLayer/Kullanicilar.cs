using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Kullanicilar
    {
        public int KullaniciID { get; set; }
        public string AdSoyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int YetkiID { get; set; }
        public int OtelID { get; set; }
        public string Adres { get; set; }
    }
}
