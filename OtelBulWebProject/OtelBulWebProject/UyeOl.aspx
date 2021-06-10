<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="OtelBulWebProject.UyeOl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/GirisFormStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="pnl_basarisiz" CssClass="basarisizPanel" Visible="false">
            <label>Opps!! Kayıt işlemi sırasında bir hata oldu. Lütfen şifre bilgilerinizin aynı olduğundan emin olunuz yada daha sonra tekrar deneyiniz.</label>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnl_basarili" CssClass="basariliPanel" Visible="false">
            <label>Tebrikler!! Aramıza katıldın. Şimdi giriş yaparak dilediğin otel için rezervasyon yapabilirsin.</label>
        </asp:Panel>
        <div class="GirisForm">
            <div class="fotograf" style="width:128px">
                <img src="images/push-pin.png" style="width:128px;"/>
            </div>
            <div class="form">
                <br />
                <label>Adınız-Soyadınız:</label><br />
                <asp:TextBox ID="tb_adSoyad" runat="server" CssClass="MetinKutu" AutoCompleteType="None"></asp:TextBox><br />
                <br />
                <label>Mail Adresiniz:</label><br />
                <asp:TextBox ID="tb_mail" runat="server" CssClass="MetinKutu" AutoCompleteType="None"></asp:TextBox><br />
                <br />
                <label>Kullanıcı Adınız:</label><br />
                <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="MetinKutu" AutoCompleteType="None"></asp:TextBox><br />
                <br />
                <label>Telefon Numaranız:</label><br />
                <asp:TextBox ID="tb_telefon" runat="server" CssClass="MetinKutu" AutoCompleteType="None"></asp:TextBox><br />
                
            </div>
            <div class="form">
                <br />
                <label>Adresiniz:</label><br />
                <asp:TextBox ID="tb_adres" runat="server" CssClass="MetinKutu" AutoCompleteType="None"></asp:TextBox><br />
                <br />
                <label>Şifreniz:</label><br />
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="MetinKutu" TextMode="Password"></asp:TextBox><br />
                <br />
                <label>Şifreniz (Tekrar):</label><br />
                <asp:TextBox ID="tb_sifreTekrar" runat="server" CssClass="MetinKutu" TextMode="Password"></asp:TextBox><br />
                <br />

                <label>Kullanıcı Türü:</label><br />
                <asp:DropDownList runat="server" ID="ddl_yetki" AutoPostBack="true" AppendDataBoundItems="true" DataValueField="YetkiID" DataTextField="Yetki" CssClass="MetinKutu">
                    <asp:ListItem Text="Kullanıcı Seçiniz" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Müşteri" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Otel" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <br />
                
            </div>
            <div class="fixed"></div>
            <asp:LinkButton runat="server" ID="lbtn_Kayit" CssClass="GirisButon" Text="Kayıt Ol" OnClick="lbtn_Kayit_Click"></asp:LinkButton>
            
        </div>
    </form>
</body>
</html>
