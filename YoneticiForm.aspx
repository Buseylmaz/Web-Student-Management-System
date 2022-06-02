<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiForm.aspx.cs" Inherits="Frontend.YoneticiForm" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Yönetici Giriş Sayfası</title>
    <link href="Form.css" rel="stylesheet" />
</head>
<body style="height: 554px">
    <form id="form2" runat="server">
        <div class="container">
        <div class="navbar">
            <div class="titlee">
                <h2>Yönetici Giriş Sayfası</h2>
            </div>
            <ul>
                <li><a href="#">Anasayfa</a></li>
                <li><a href="#">Hakkımızda</a></li>
                <li><a href="#">İletişim</a></li>
            </ul>
        </div>
       
        <div class="center">
            <div class="Text" >
                <asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="150px" placeholder="Ad-Soyad"></asp:TextBox> <br />
                <asp:TextBox  type="password" ID="TextBox2" runat="server" Height="24px" Width="150px" placeholder="Şifre"></asp:TextBox>
           </div>
            <div class="buttons">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Giriş Yap" BackColor="#30231D" ForeColor="#F6F1ED" Height="31px" Width="114px"   />
                <a href="YoneticiIndex.html"></a>
            </div>

        </div>
    </div>
    </form>
</body>
</html>


