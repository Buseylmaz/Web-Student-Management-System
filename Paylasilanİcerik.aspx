<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paylasilanİcerik.aspx.cs" Inherits="Frontend.Paylasilanİcerik" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Duyuru Paylaşım Sayfası</title>
    <link href="FormaspxStyle.css" rel="stylesheet" />
</head>
<body style="height: 674px">
    <form id="form1" runat="server">
        <div class="container">
        <div class="navbar">
            <div class="titlee">
                <h2>Duyuru Paylaşım Sayfası</h2>
            </div>
           
        </div>
       
        <div class="center">
            <div class="Text" >
                <asp:TextBox ID="TextBox1" runat="server" Height="37px" Width="220px"  BackColor="#30231D" Font-Bold="True" Font-Size="15px" ForeColor="#B5A397"  placeholder="Başlık" ></asp:TextBox><br />
                <asp:TextBox ID="TextBox2" runat="server" Height="78px" Width="217px"  BackColor="#30231D" Font-Bold="True" Font-Overline="True" Font-Size="15px" ForeColor="#B5A397"  placeholder="Konu" ></asp:TextBox><br />
                <asp:TextBox ID="TextBox3" runat="server" Width="206px" BackColor="#30231D" Font-Bold="True" Font-Size="15px" ForeColor="#B5A397" Height="22px"  placeholder="Yayınlanma Tarihi(YY-AA-GG)"></asp:TextBox><br />
                 <asp:TextBox ID="TextBox4" runat="server" Width="338px" BackColor="#30231D" Font-Bold="True" Font-Size="15px" ForeColor="#B5A397" Height="175px"  placeholder="İçerik"></asp:TextBox><br />
            </div>
            
            <div class="button" >
                
               <center> <asp:Button ID="Button2" runat="server" Text="Duyuru Yayınla" Font-Bold="True" BackColor="#30231D" ForeColor="#B5A397" Height="42px"  OnClick="Button1_Click" /></center> 
           </div>

        </div>
    </div>
    </form>
</body>
</html>


