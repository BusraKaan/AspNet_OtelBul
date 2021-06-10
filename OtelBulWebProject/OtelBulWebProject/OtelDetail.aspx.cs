using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtelBulWebProject
{
    public partial class OtelDetail : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["oId"]);
                OtelModel o = dm.OtelGetir(id);
                ltrl_otelAdi.Text = o.OtelAdi;
                ltrl_aciklama.Text = o.Aciklama;
                ltrl_sehir.Text = o.Sehir + " / " + o.ilce;
                ltrl_adres.Text = o.Adres;
                ltrl_yildiz.Text = o.YildizSayisi.ToString();

                List<OtelHizmetleri> oh = dm.OtelHizmetleriListele(id);
                lv_hizmetler.DataSource = oh;
                lv_hizmetler.DataBind();

                List<OtelKategorileri> ok = dm.OtelKategorileriListele(id);
                lv_Otelkategori.DataSource = ok;
                lv_Otelkategori.DataBind();

                OtelFotograflari fotograf = dm.FotografGetir(id);
                string uzanti = (fotograf.FotografUzati == null) ? "no-camera.png" : fotograf.FotografUzati;
                img_resim.ImageUrl = "OtelResim/" + uzanti;

                rp_yorum.DataSource = dm.YorumListele(id);
                rp_yorum.DataBind();
            }

            Kullanicilar k = (Kullanicilar)Session["Uye"];
            if (Session["Uye"] != null)
            {
                pnl_girisVar.Visible = true;
                pnl_girisYok.Visible = false;
            }
            else
            {
                pnl_girisVar.Visible = false;
                pnl_girisYok.Visible = true;
            }
        }

        protected void lbtn_yorumYap_Click(object sender, EventArgs e)
        {
            Kullanicilar k = (Kullanicilar)Session["Uye"];
            if (!string.IsNullOrEmpty(tb_yorum.Text))
            {
                if (tb_yorum.Text.Length <= 200 && tb_yorumBaslik.Text.Length <= 100)
                {
                    int id = Convert.ToInt32(Request.QueryString["oId"]);
                    Yorumlar y = new Yorumlar();
                    y.Baslik = tb_yorumBaslik.Text;
                    y.Yorum = tb_yorum.Text;
                    y.YorumTarihi = DateTime.Now;
                    y.OtelID = id;
                    y.KullaniciID = k.KullaniciID;
                    if (dm.YorumEkle(y))
                    {
                        lbl_mesaj.Text = "Yorumunuz başarı ile alınmıştır.";
                    }
                    else
                    {
                        lbl_mesaj.Text = "Hata var.";
                    }
                }
                else
                {
                    lbl_mesaj.Text = "Mesaj en fazla 200 karakter olabilir ve Başlık en fazla 100 karakter olabilir.";
                }
            }
            else
            {
                lbl_mesaj.Text = "Mesaj kısmı boş bırakılamaz";
            }
        }
    }
}