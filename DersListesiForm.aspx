<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DersListesiForm.aspx.cs" Inherits="Frontend.DersListesiForm" %>


<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Ders Kayıt Sayfası</title>
    <link href="FormaspxStyle.css" rel="stylesheet" />
</head>
<body style="height: 674px">
    
    <form id="form1" runat="server">
        <div class="container">
        <div class="navbar">
            <div class="titlee">
                <h2>Ders Kayıt Sayfası</h2>
            </div>
           
        </div>
       
        <div class="center">
            <div class="Text" >
                
                <asp:TextBox ID="TextBox2" runat="server" Height="33px" Width="217px"  BackColor="#30231D" Font-Bold="True" Font-Overline="True" Font-Size="15px" ForeColor="#B5A397"  placeholder="Dersin Adı" ></asp:TextBox><br />
                <asp:TextBox ID="TextBox3" runat="server" Width="217px" BackColor="#30231D" Font-Bold="True" Font-Size="15px" ForeColor="#B5A397" Height="33px"  placeholder="Ogretmen Adı"></asp:TextBox><br />
                <asp:TextBox ID="TextBox4" runat="server" Width="217px" BackColor="#30231D" Font-Bold="True" Font-Size="15px" ForeColor="#B5A397" Height="33px"  placeholder="Dersin İçeriği"></asp:TextBox><br />
                <asp:TextBox ID="TextBox5" runat="server" Width="217px" BackColor="#30231D" Font-Bold="True" Font-Size="15px" ForeColor="#B5A397" Height="33px"  placeholder="Dersin Kredisi"></asp:TextBox><br />
                <asp:TextBox ID="TextBox1" runat="server" Width="217px" BackColor="#30231D" Font-Bold="True" Font-Size="15px" ForeColor="#B5A397" Height="33px"  placeholder="Dersin AKTS"></asp:TextBox><br />
                
                
           </div>
            <div class="button" >
                 <center> <asp:Button ID="Button2" runat="server" Text="Kayıt" Font-Bold="True" BackColor="#30231D" ForeColor="#B5A397" Height="42px"  OnClick="Button1_Click" /></center> 
           </div>

        </div>
    </div>
    </form>
</body>
</html>

