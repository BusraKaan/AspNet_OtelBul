using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtelBulWebProject
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        string OtelID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Uye"] != null)
            {
                Kullanicilar k = (Kullanicilar)Session["Uye"];
                ltrl_uye.Text = k.KullaniciAdi;
                li_girisYok.Visible = false;
                li_girisYok2.Visible = false;
                li_girisVar.Visible = true;
                OtelID = k.OtelID.ToString();
                if (k.YetkiID != 2)
                {
                    if (k.OtelID == 0)
                    {
                        li_girisVar2.Visible = true;
                        li_otelVar.Visible = false;
                    }
                    else
                    {
                        li_otelVar.Visible = true;
                        li_girisVar2.Visible = false;
                    }
                    
                    
                }
                else
                {
                    li_girisVar2.Visible = false;
                    li_otelVar.Visible = false;
                }
            }
            else
            {
                li_girisYok.Visible = true;
                li_girisYok2.Visible = true;
                li_girisVar.Visible = false;
                li_girisVar2.Visible = false;
                li_otelVar.Visible = false;
            }
        }

        protected void lbtn_cikisYap_Click(object sender, EventArgs e)
        {
            Session["Uye"] = null;
            li_girisYok.Visible = true;
            li_girisYok2.Visible = true;
            li_girisVar.Visible = false;
            li_girisVar2.Visible = false;
            li_otelVar.Visible = false;
            ltrl_uye.Text = "";
        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            string url = "OtelGuncelle.aspx?Oid=" + OtelID;
            Response.Redirect(url);
        }
    }
}