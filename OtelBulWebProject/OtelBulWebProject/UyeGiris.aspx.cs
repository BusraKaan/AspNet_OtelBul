using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtelBulWebProject
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Giris_Click(object sender, EventArgs e)
        {
            Kullanicilar k = dm.UyeGiris(tb_mail.Text, tb_sifre.Text);
            if (k != null)
            {
                if (k.KullaniciID != 0)
                {
                    Session["Uye"] = k;
                    Response.Redirect("OtelListele.aspx");
                }
                else
                {
                    pnl_mesaj.Visible = true;
                    lbl_mesaj.Text = "Kullanıcı Bulunamadı.";
                }
            }
            else
            {
                pnl_mesaj.Visible = true;
                lbl_mesaj.Text = "Opps!! Bir Hata ile karşılaştık. Lütfen daha sonra tekrar deneyin.";
            }
        }
    }
}