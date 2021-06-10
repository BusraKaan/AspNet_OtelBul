using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OtelModel
    {
        public int ID { get; set; }
        public string OtelAdi { get; set; }
        public int SehirID { get; set; }
        public string Sehir { get; set; }
        public int ilceID { get; set; }
        public string ilce { get; set; }
        public int YildizSayisi { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }
        public double KullaniciPuani { get; set; }
        public bool OnayDurumu { get; set; }
        public string Ozet { get; set; }
        public string FotografUzati { get; set; }

    }
}
