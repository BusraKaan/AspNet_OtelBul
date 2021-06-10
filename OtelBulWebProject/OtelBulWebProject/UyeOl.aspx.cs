using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtelBulWebProject
{
    public partial class UyeOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Kayit_Click(object sender, EventArgs e)
        {
            if (tb_sifre.Text != tb_sifreTekrar.Text)
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
            }
            else
            {
                Kullanicilar kul = new Kullanicilar();
                kul.AdSoyad = tb_adSoyad.Text;
                kul.Email = tb_mail.Text;
                kul.Sifre = tb_sifre.Text;
                kul.KullaniciAdi = tb_kullaniciAdi.Text;
                kul.Telefon = tb_telefon.Text;
                kul.YetkiID = Convert.ToInt32(ddl_yetki.SelectedItem.Value);
                kul.Adres = tb_adres.Text;
                if (dm.UyeKayit(kul))//True İse
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                }
            }
        }
    }
}