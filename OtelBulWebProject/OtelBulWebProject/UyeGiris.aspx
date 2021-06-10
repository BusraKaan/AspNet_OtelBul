<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="OtelBulWebProject.UyeGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/GirisFormStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="GirisForm">
            <div class="fotograf" style="float: left;">
                <img src="images/password.png" />
            </div>
            <div class="form">
                <asp:Panel ID="pnl_mesaj" runat="server" CssClass="mesajPanel" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <br />
                <label>Mail Adresiniz</label><br />
                <asp:TextBox ID="tb_mail" runat="server" CssClass="MetinKutu" AutoCompleteType="None"></asp:TextBox><br />
                <br />
                <label>Şifre</label><br />
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="MetinKutu" TextMode="Password"></asp:TextBox><br />
                <br />
                <asp:LinkButton runat="server" ID="lbtn_Giris" CssClass="GirisButon" Text="Giris Yap" OnClick="lbtn_Giris_Click"></asp:LinkButton>
                <br />
            </div>
            <div class="fixed"></div>
        </div>
    </form>
</body>
</html>
