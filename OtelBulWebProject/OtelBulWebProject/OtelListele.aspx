<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OtelListele.aspx.cs" Inherits="OtelBulWebProject.OtelListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/ListelemeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="icerikTasiyici">
        <asp:Panel ID="pnl_Kriterbasarisiz" runat="server" CssClass="basarisizmesaj" Visible="false">
            <label>Başarısız</label>
            Aradığınız kriterlere uygun otel bulunamadı.
        </asp:Panel>
        <asp:Panel ID="pnl_KriterBasarili" runat="server" Visible="true">
            <asp:ListView ID="lv_oteller" runat="server" OnPagePropertiesChanging="lv_oteller_PagePropertiesChanging">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="kutu">
                        <div class="fotograf">
                            <a href='OtelDetail.aspx?oId=<%# Eval("ID") %>'>
                                <%--<img src="../images/img2.jpg" />--%>
                                <image src='OtelResim/<%# Eval("FotografUzati") %>' />
                            </a>
                        </div>
                        <div class="icerikAciklama">
                            <a href='OtelDetail.aspx?oId=<%# Eval("ID") %>'>
                                <div class="baslik"><strong><%# Eval("OtelAdi") %></strong></div>
                                <div class="kisaAciklama"><%# Eval("Sehir") %> / <%#Eval("ilce") %></div>
                                <div class="puanBilg"><%# Eval("KullaniciPuani") %></div>
                                <div class="yildiz">
                                    <img src="images/star.png" />
                                </div>
                                <div class="Ozet"><%# Eval("Ozet") %></div>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>

            <div class="pagerTasiyici">
                <asp:DataPager ID="dp_sayfalama" runat="server" PageSize="3" PagedControlID="lv_oteller" OnPreRender="dp_sayfalama_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonCssClass="numarabuton" />
                        <asp:NumericPagerField NumericButtonCssClass="numarabuton" CurrentPageLabelCssClass="secilibuton" />
                        <asp:NextPreviousPagerField ShowPreviousPageButton="false" ShowNextPageButton="true" ButtonCssClass="numarabuton" />
                    </Fields>
                </asp:DataPager>
            </div>
        </asp:Panel>
    </div>

    <div class="sagMenu">
        <h3>Konuma Göre</h3>
        <asp:DropDownList runat="server" ID="dd_sehirler" AutoPostBack="true" AppendDataBoundItems="true" DataValueField="SehirID" DataTextField="Sehir" CssClass="sagMenuDropDown"
            OnSelectedIndexChanged="dd_sehirler_SelectedIndexChanged">
            <asp:ListItem Text="Sehir Seçiniz" Value="0"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddl_ilceler" AutoPostBack="true" AppendDataBoundItems="false" DataValueField="IlceID" DataTextField="Ilce" CssClass="sagMenuDropDown"
            OnSelectedIndexChanged="ddl_ilceler_SelectedIndexChanged">
            <asp:ListItem Text="İlçe Seçiniz" Value="0"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="fixed"></div>





    <%--    <div style="clear:both">
        <div class="fotograf">
            <a href="#">
                <img src="../images/img2.jpg" />
            </a>
        </div>
        <div class="icerikAciklama">
            <a href="#">
                <div class="baslik">Otel Adı</div>
                <div class="kisaAciklama">Bulunduğu şehir/ilçe</div>
                <div class="puanBilg">Puan(10)</div>
                <div class="Ozet">Nam quis nulla. Integer malesuada. In in enim a arcu imperdiet malesuada. Sed vel lectus. Donec odio urna, tempus molestie, porttitor ut, iaculis quis</div>
            </a>
        </div>
    </div>--%>
</asp:Content>
