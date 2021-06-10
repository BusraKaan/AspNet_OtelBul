<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OtelGuncelle.aspx.cs" Inherits="OtelBulWebProject.OtelGuncelle" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <asp:Panel runat="server" ID="pnl_basarisiz" CssClass="basarisizPanel" Visible="false">
        <label>Opps!! Kayıt işlemi sırasında bir hata oldu.
            <asp:Literal runat="server" ID="ltrl_basarisiz"></asp:Literal></label>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnl_basarili" CssClass="basariliPanel" Visible="false">
        <label>Tebrikler!!
            <asp:Literal runat="server" ID="ltrl_basarili"></asp:Literal></label>
    </asp:Panel>
    <div class="icerikTasiyici">
        <div class="satir">
            <label>Otel Adı: </label>
            <asp:TextBox ID="tb_OtelAdi" runat="server" CssClass="MetinKutu"></asp:TextBox>
        </div>
        <div class="fotografDetail">
            <%--<img src="../images/img2.jpg" />--%>
            <asp:Image runat="server" ID="img_resim"/>
        </div>
        <div class="satir">
            <label>Açıklama:</label><br />
            <asp:TextBox TextMode="MultiLine" runat="server" CssClass="ckeditor MetinKutu" ID="tb_OtelAciklama"></asp:TextBox>
        </div>
        <div class="satir">
            <label>Özet Bilgi:</label>
            <asp:TextBox ID="tb_ozet" runat="server" CssClass="MetinKutu" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="satir">
            <label>Resim: </label>
            <asp:FileUpload ID="fu_resim" runat="server" />
        </div>
        <div class="satir">
            <label>Adres:</label>
            <asp:TextBox ID="tb_adres" runat="server" CssClass="MetinKutu" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="satir" style="float: right;">
            <asp:LinkButton runat="server" ID="btn_OtelGuncelle" Text="Otel Güncelle" CssClass="buton" OnClick="btn_OtelGuncelle_Click"></asp:LinkButton>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <div class="sagMenu">
        <div>
            <label>Şehir:</label><br />
            <asp:DropDownList runat="server" ID="dd_sehirler" AutoPostBack="true" AppendDataBoundItems="true" DataValueField="SehirID" DataTextField="Sehir" CssClass="sagMenuDropDown"
                OnSelectedIndexChanged="dd_sehirler_SelectedIndexChanged">
                <asp:ListItem Text="Sehir Seçiniz" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <label>İlçe:</label><br />
            <asp:DropDownList runat="server" ID="ddl_ilceler" AutoPostBack="true" AppendDataBoundItems="false" DataValueField="IlceID" DataTextField="Ilce" CssClass="sagMenuDropDown">
                <asp:ListItem Text="İlçe Seçiniz" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <label>Yıldız Sayısı:</label><br />
            <asp:TextBox ID="tb_YildizSayisi" runat="server" CssClass="sagMenuDropDown"></asp:TextBox>
        </div>
        <div>
            <asp:ListBox runat="server" ID="lsb_hizmetler" AutoPostBack="false" AppendDataBoundItems="true" DataValueField="HizmetID" DataTextField="HizmetAdi" SelectionMode="Multiple" CssClass="sagMenuDropDown sagMenuListView" >
            </asp:ListBox>
        </div>
        <div>
            <asp:ListBox runat="server" ID="lsb_kategoriler" AutoPostBack="false" AppendDataBoundItems="true" DataValueField="KategoriID" DataTextField="Kategori" SelectionMode="Multiple" CssClass="sagMenuDropDown sagMenuListView">
            </asp:ListBox>
        </div>
    </div>

</asp:Content>
