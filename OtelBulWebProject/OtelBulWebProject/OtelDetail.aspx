<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OtelDetail.aspx.cs" Inherits="OtelBulWebProject.OtelDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="icerikTasiyici">
        <div class="BüyükBaslik">
            <h1>
                <asp:Literal runat="server" ID="ltrl_otelAdi"></asp:Literal></h1>
        </div>
        <div class="fotografDetail">
            <asp:Image runat="server" ID="img_resim" />
        </div>

        <div class="aciklama">
            <asp:Literal runat="server" ID="ltrl_aciklama"></asp:Literal>
        </div>
        <div class="fixed"></div>
        <asp:Panel ID="pnl_girisVar" runat="server">
            <div class="yorumPanel">
                <div>
                    <asp:TextBox ID="tb_yorumBaslik" runat="server" CssClass="yorumMetinKutu"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="tb_yorum" runat="server" TextMode="MultiLine" CssClass="yorumMetinKutu"></asp:TextBox>
                </div>
                <br />
                <asp:LinkButton ID="lbtn_yorumYap" runat="server" CssClass="yorumButon" OnClick="lbtn_yorumYap_Click">Yorum Yap</asp:LinkButton>
                <br />
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnl_girisYok" runat="server">
            <div class="yorumPanel">
                <h3>Yorum Yapabilmek İçin Lütfen <a href="UyeGiris.aspx">Giriş Yapınız</a></h3>
            </div>
        </asp:Panel>
        <asp:Repeater ID="rp_yorum" runat="server">
            <ItemTemplate>
                <div class="yorumTasiyici">
                    <div class="YorumIcerik" style="color:#9B2F53">
                       <strong><%# Eval("Baslik") %></strong>
                    </div>
                    <div class="YorumIcerik">
                        <%# Eval("Yorum") %>
                    </div>
                    <div class="YorumUye"><%# Eval("KullaniciAdi") %> - <%# Eval("YorumTarihi") %></div>
                    <div class="fixed"></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="sagMenu" style="width: 178px; margin-top: 25px; border: 1px solid lightgray;">
        <div class="KucukBaslik">
            <h3>
                <asp:Literal runat="server" ID="ltrl_sehir"></asp:Literal></h3>
        </div>
        <div class="KucukBaslik">
            <p>
                <asp:Literal runat="server" ID="ltrl_adres"></asp:Literal>
            </p>
        </div>
        <div style="margin-right: auto; margin-left: auto; width: 130px">
            <div class="PuanBilg" style="font-size: 20px">PUAN:</div>
            <div class="ikon" style="font-size: 20px">
                <img src="images/star.png" />
            </div>
            <div class="PuanBilg">
                <asp:Literal runat="server" ID="ltrl_yildiz"></asp:Literal>
            </div>

        </div>
        <div class="fixed"></div>
        <div>
            <asp:ListView runat="server" ID="lv_hizmetler">
                <LayoutTemplate>
                    <div class="KucukBaslik">
                        <h3>Hizmet</h3>
                    </div>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <%--<div class="ikon">
                        <img src="images/draw-check-mark.png" />
                    </div>
                    <div class="ikon">
                        <%# Eval("HizmetAdi") %>
                    </div>--%>
                    <div class="Hizmetler">
                        <ul>
                            <li><%# Eval("HizmetAdi") %></li>
                        </ul>
                    </div>
                    <div class="fixed"></div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="fixed"></div>
        <div>
            <asp:ListView runat="server" ID="lv_Otelkategori">
                <LayoutTemplate>
                    <div class="KucukBaslik">
                        <h3>Otel Kategorisi</h3>
                    </div>
                    <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                </LayoutTemplate>
                <ItemTemplate>
                    <%--<div class="ikon">
                        <img src="images/draw-check-mark.png" />
                    </div>
                    <div class="ikon">
                        <%# Eval("Kategori") %>
                    </div>--%>
                    <div class="Kategori">
                        <ul>
                            <li><%# Eval("Kategori") %></li>
                        </ul>
                    </div>
                    <div class="fixed"></div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
