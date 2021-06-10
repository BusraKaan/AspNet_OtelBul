using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtelBulWebProject
{
    public partial class OtelListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        List<OtelModel> oteller = new List<OtelModel>();
        string Sorgu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Sorgu = "";
                oteller = dm.OtelListele();

                dd_sehirler.DataSource = dm.SehirListele();
                dd_sehirler.DataBind();
                ddl_ilceler.DataSource = dm.IlceListele();
                ddl_ilceler.DataBind();
                ddl_ilceler.Items.Insert(0, new ListItem("İlçe Seciniz", "0"));


            }
            else
            {
                if (ddl_ilceler.SelectedItem.Value != "0")
                {
                    IlceyeGoreListele();
                }
                else
                {
                    SehireGoreListele();
                }
            }

            lv_oteller.DataSource = oteller;
            lv_oteller.DataBind();
        }

        protected void lv_oteller_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dp_sayfalama.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            if (!IsPostBack)
            {

                oteller = dm.OtelListele();
                lv_oteller.DataSource = oteller;
                lv_oteller.DataBind();
            }
            else
            {
                if (ddl_ilceler.SelectedItem.Value != "0")
                {
                    IlceyeGoreListele();
                }
                else
                {
                    SehireGoreListele();
                }
            }

        }

        protected void dp_sayfalama_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oteller = dm.OtelListele();
                lv_oteller.DataSource = oteller;
                lv_oteller.DataBind();
            }
            else
            {
                if (ddl_ilceler.SelectedItem.Value != "0")
                {
                    IlceyeGoreListele();
                }
                else
                {
                    SehireGoreListele();
                }
            }
        }
        public void SehireGoreListele()
        {
            if (dd_sehirler.SelectedItem.Value == "0" && string.IsNullOrEmpty(Sorgu))
            {
                oteller = dm.OtelListele();
                pnl_Kriterbasarisiz.Visible = false;
                pnl_KriterBasarili.Visible = true;
            }
            else
            {
                Sorgu += "S.ID=" + dd_sehirler.SelectedItem.Value + " AND ";
                oteller = dm.OtelListele(Sorgu);
                ddl_ilceler.DataSource = dm.IlceListele(Convert.ToInt32(dd_sehirler.SelectedItem.Value));
                ddl_ilceler.DataBind();
                ddl_ilceler.Items.Insert(0, new ListItem("İlçe Seciniz", "0"));
                if (oteller.Count == 0)
                {
                    pnl_Kriterbasarisiz.Visible = true;
                    pnl_KriterBasarili.Visible = false;
                }
                else
                {
                    pnl_Kriterbasarisiz.Visible = false;
                    pnl_KriterBasarili.Visible = true;
                }
            }
            lv_oteller.DataSource = oteller;
            lv_oteller.DataBind();
        }
        public void IlceyeGoreListele()
        {
            if (ddl_ilceler.SelectedItem.Value == "0" && string.IsNullOrEmpty(Sorgu))
            {
                oteller = dm.OtelListele();
                pnl_KriterBasarili.Visible = true;
                pnl_Kriterbasarisiz.Visible = false;
            }
            else
            {
                Sorgu += "I.ID=" + ddl_ilceler.SelectedValue + " AND ";
                oteller = dm.OtelListele(Sorgu);
                if (oteller.Count == 0)
                {
                    pnl_Kriterbasarisiz.Visible = true;
                    pnl_KriterBasarili.Visible = false;
                }
                else
                {
                    pnl_Kriterbasarisiz.Visible = false;
                    pnl_KriterBasarili.Visible = true;
                }
                lv_oteller.DataSource = oteller;
                lv_oteller.DataBind();
            }
        }
        protected void dd_sehirler_SelectedIndexChanged(object sender, EventArgs e)
        {
            SehireGoreListele();
            #region sehirSorgu
            //if (dd_sehirler.SelectedItem.Value == "0" && string.IsNullOrEmpty(Sorgu))
            //{
            //    oteller = dm.OtelListele();
            //    pnl_Kriterbasarisiz.Visible = false;
            //    pnl_KriterBasarili.Visible = true;
            //}
            //else
            //{
            //    Sorgu += "S.ID=" + dd_sehirler.SelectedItem.Value + " AND ";
            //    oteller = dm.OtelListele(Sorgu);
            //    ddl_ilceler.DataSource = dm.IlceListele(Convert.ToInt32(dd_sehirler.SelectedItem.Value));
            //    ddl_ilceler.DataBind();
            //    ddl_ilceler.Items.Insert(0, "İlçe Seciniz");
            //    if (oteller == null)
            //    {
            //        pnl_Kriterbasarisiz.Visible = true;
            //        pnl_KriterBasarili.Visible = false;
            //    }
            //    else
            //    {
            //        pnl_Kriterbasarisiz.Visible = false;
            //        pnl_KriterBasarili.Visible = true;
            //    }
            //}
            //lv_oteller.DataSource = oteller;
            //lv_oteller.DataBind();
            #endregion
        }

        protected void ddl_ilceler_SelectedIndexChanged(object sender, EventArgs e)
        {
            IlceyeGoreListele();
        }

    }
}