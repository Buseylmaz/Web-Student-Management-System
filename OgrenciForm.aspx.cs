using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Frontend
{
    public partial class OgrenciFrom : System.Web.UI.Page
    {
        
        SqlConnection baglantı = new SqlConnection(@"data source=LAPTOP-RLQS6GBM\SQLEXPRESS;initial catalog=StudentManagementSystem1;integrated security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Student WHERE OgrenciNumarasi=@SNo AND Sifre=@SP", baglantı);
            komut.Parameters.AddWithValue("@SNo", TextBox1.Text);
            komut.Parameters.AddWithValue("@SP", TextBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Response.Redirect("OgrenciIndex.html");

            }
            else
            {
                Response.Write("Hatalı Tc numarası veya Şifre Girdiniz");

            }
            baglantı.Close();
        }

       
        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {

        }
    }
    }