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
    public partial class OtelGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        int OtelID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                Kullanicilar k = (Kullanicilar)Session["Uye"];
                if (Session["Uye"] != null && k.YetkiID != 2)
                {
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.QueryString["Oid"]);
                        OtelModel otel = dm.OtelGetir(id);
                        OtelID = otel.ID;
                        tb_OtelAdi.Text = otel.OtelAdi;
                        tb_OtelAciklama.Text = otel.Aciklama;
                        tb_ozet.Text = otel.Ozet;
                        tb_YildizSayisi.Text = otel.YildizSayisi.ToString();
                        tb_adres.Text = otel.Adres;

                        OtelFotograflari fotograf = dm.FotografGetir(id);
                        string uzanti = (fotograf.FotografUzati == null) ? "no-camera.png" : fotograf.FotografUzati;
                        img_resim.ImageUrl = "OtelResim/" + uzanti;


                        dd_sehirler.DataSource = dm.SehirListele();
                        dd_sehirler.DataBind();
                        ddl_ilceler.DataSource = dm.IlceListele();
                        ddl_ilceler.DataBind();
                        ddl_ilceler.Items.Insert(0, new ListItem("İlçe Seciniz", "0"));

                        dd_sehirler.SelectedValue = otel.SehirID.ToString();
                        ddl_ilceler.SelectedValue = otel.ilceID.ToString();

                        lsb_hizmetler.DataSource = dm.HizmetListele();
                        lsb_hizmetler.DataBind();
                        lsb_kategoriler.DataSource = dm.KategoriListele();
                        lsb_kategoriler.DataBind();

                        List<OtelHizmetleri> oh = dm.OtelHizmetleriListele(id);
                        foreach (OtelHizmetleri item in oh)
                        {
                            lsb_hizmetler.Items[item.ID - 1].Selected = true;
                        }

                        List<OtelKategorileri> ok = dm.OtelKategorileriListele(id);
                        foreach (OtelKategorileri item in ok)
                        {
                            lsb_kategoriler.Items[item.KategoriID - 1].Selected = true;
                        }
                    }
                }
                else
                {
                    Response.Redirect("OtelListele.aspx");
                }


            }
        }

        protected void dd_sehirler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_OtelGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_YildizSayisi.Text))
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                ltrl_basarisiz.Text = "Otel Yıldız Bilgisi Boş Bırakıldı.";
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["Oid"]);
                OtelModel o = dm.OtelGetir(id);
                OtelID = o.ID;

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

                if (dm.OtelGuncelle(otel))
                {
                    #region Fotoğraf Güncelleme
                    if (fu_resim.HasFile)//resim atılmışsa
                    {
                        OtelFotograflari of = new OtelFotograflari();
                        of.OtelID = OtelID;
                        FileInfo resim = new FileInfo(fu_resim.FileName);
                        string uzanti = resim.Extension;
                        string dosyaIsim = Guid.NewGuid().ToString() + uzanti;
                        fu_resim.SaveAs(Server.MapPath("OtelResim/" + dosyaIsim));
                        of.FotografUzati = dosyaIsim;
                        if (!dm.OtelFotograflariGuncelle(of))
                        {
                            pnl_basarisiz.Visible = true;
                            pnl_basarili.Visible = false;
                            ltrl_basarisiz.Text += "Fotoğraf güncellenirken edilirken bir hata oluştu. ";
                            kontol = true;
                        }
                    }
                    #endregion

                    #region Hizmetler Güncelleme
                    List<OtelHizmetleri> hizmetler = new List<OtelHizmetleri>();
                    foreach (ListItem item in lsb_hizmetler.Items)
                    {
                        if (item.Selected)
                        {
                            OtelHizmetleri h = new OtelHizmetleri();
                            h.OtelID = OtelID;
                            h.HizmetID = Convert.ToInt32(item.Value);
                            h.HizmetDurumu = true;
                            hizmetler.Add(h);
                        }
                    }
                    if (!dm.OtelHizmetlerGuncelle(hizmetler))
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        ltrl_basarisiz.Text += "Hizmetler güncellenirken edilirken bir hata oluştu. ";
                        kontol = true;
                    }
                    #endregion

                    #region Otel Kategorisi Güncelleme
                    List<OtelKategorileri> kategoriler = new List<OtelKategorileri>();
                    foreach (ListItem item in lsb_kategoriler.Items)
                    {
                        if (item.Selected)
                        {
                            OtelKategorileri k = new OtelKategorileri();
                            k.OtelID = OtelID;
                            k.KategoriID = Convert.ToInt32(item.Value);
                            kategoriler.Add(k);
                        }
                    }
                    if (!dm.OtelKategorileriGuncelle(kategoriler))
                    {
                        pnl_basarisiz.Visible = true;
                        pnl_basarili.Visible = false;
                        ltrl_basarisiz.Text += "Kategoriler Kayıt edilirken bir hata oluştu. ";
                        kontol = true;
                    }
                    #endregion
                }

            }

        }
    }
}