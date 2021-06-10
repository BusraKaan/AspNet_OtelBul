using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtelBulWebProject
{
    public partial class OtelEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Kullanicilar k = (Kullanicilar)Session["Uye"];
            if (Session["Uye"] != null && k.YetkiID!=2 )
            {
                if (!IsPostBack)
                {
                    dd_sehirler.DataSource = dm.SehirListele();
                    dd_sehirler.DataBind();
                    ddl_ilceler.DataSource = dm.IlceListele();
                    ddl_ilceler.DataBind();
                    ddl_ilceler.Items.Insert(0, "İlçe Seciniz");
                    lsb_hizmetler.DataSource = dm.HizmetListele();
                    lsb_hizmetler.DataBind();
                    lsb_kategoriler.DataSource = dm.KategoriListele();
                    lsb_kategoriler.DataBind();
                }
            }
            else
            {
                Response.Redirect("OtelListele.aspx");
            }
        }

        protected void dd_sehirler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_ilceler.DataSource = dm.IlceListele(Convert.ToInt32(dd_sehirler.SelectedItem.Value));
            ddl_ilceler.DataBind();
            ddl_ilceler.Items.Insert(0, "İlçe Seciniz");
        }

        protected void btn_OtelEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_YildizSayisi.Text))
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                ltrl_basarisiz.Text = "Otel Yıldız Bilgisi Boş Bırakıldı.";
            }
            else
            {
                bool kontol = false;
                ltrl_basarisiz.Text = "";
                OtelModel otel = new OtelModel();
                otel.OtelAdi = tb_OtelAdi.Text;
                otel.Aciklama = tb_OtelAciklama.Text;
                otel.Ozet = tb_ozet.Text;
                otel.YildizSayisi = Convert.ToInt32(tb_YildizSayisi.Text);
                otel.Adres = tb_adres.Text;
                otel.SehirID = Convert.ToInt32(dd_sehirler.SelectedItem.Value);
                otel.ilceID = Convert.ToInt32(ddl_ilceler.SelectedItem.Value);
                otel.KullaniciPuani = 0;
                otel.OnayDurumu = false;
                int NewID = dm.OtelEkle(otel);
                if (NewID != 0)
                {
                    #region Fotoğraf Ekleme
                    if (fu_resim.HasFile)//resim atılmışsa
                    {
                        OtelFotograflari of = new OtelFotograflari();
                        of.OtelID = NewID;
                        FileInfo resim = new FileInfo(fu_resim.FileName);
                        string uzanti = resim.Extension;
                        string dosyaIsim = Guid.NewGuid().ToString() + uzanti;
                        fu_resim.SaveAs(Server.MapPath("OtelResim/" + dosyaIsim));
                        of.FotografUzati = dosyaIsim;
                        if (!dm.OtelFotografEkle(of))
                        {
                            pnl_basarisiz.Visible = true;
                            pnl_basarili.Visible = false;
                            ltrl_basarisiz.Text += "Fotoğraf Kayıt edilirken bir hata oluştu. ";
                            kontol = true;
                        }
                    }
                    #endregion

                    #region Hizmetler Ekleme
                    List<OtelHizmetleri> hizmetler = new List<OtelHizmetleri>();
                    foreach (ListItem item in lsb_hizmetler.Items)
                    {
                        if (item.Selected)
                        {
                            OtelHizmetleri h = new OtelHizmetleri();
                            h.OtelID = NewID;
                            h.HizmetID = Convert.ToInt32(item.Value);
                            h.HizmetDurumu = true;
                            hizmetler.Add(h);
                        }
                    }
                    if (!dm.OtelHizmetiEkle(hizmetler))
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        ltrl_basarisiz.Text += "Hizmetler Kayıt edilirken bir hata oluştu. ";
                        kontol = true;
                    }
                    #endregion

                    #region Otel Kategorisi Ekleme
                    List<OtelKategorileri> kategoriler = new List<OtelKategorileri>();
                    foreach (ListItem item in lsb_kategoriler.Items)
                    {
                        if (item.Selected)
                        {
                            OtelKategorileri k = new OtelKategorileri();
                            k.OtelID = NewID;
                            k.KategoriID = Convert.ToInt32(item.Value);
                            kategoriler.Add(k);
                        }
                    }
                    if (!dm.OtelKategorisiEkle(kategoriler))
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        ltrl_basarisiz.Text += "Kategoriler Kayıt edilirken bir hata oluştu. ";
                        kontol = true;
                    }
                    #endregion
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    ltrl_basarisiz.Text = "Otel Kayıt edilirken bir hata oluştu.";
                    kontol = true;
                }
                if (kontol == false)
                {
                    pnl_basarisiz.Visible = false;
                    pnl_basarili.Visible = true;
                    ltrl_basarili.Text = "Kayıt Başarıyla Gerçekleştirildi..";
                }
            }

        }

        protected void lv_hizmetler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
    }
}