using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Frontend
{
    public partial class YoneticiForm : System.Web.UI.Page
    {
        SqlConnection baglantı = new SqlConnection(@"data source=LAPTOP-RLQS6GBM\SQLEXPRESS;initial catalog=StudentManagementSystem1;integrated security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Admin WHERE YoneticiAdi=@YA AND Sifre=@S", baglantı);
            komut.Parameters.AddWithValue("@YA", TextBox1.Text);
            komut.Parameters.AddWithValue("@S", TextBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Response.Redirect("YoneticiIndex.html");

            }
            else
            {
                Response.Write("Hatalı Ad-Soyad veya Şifre Girdiniz");

            }
            baglantı.Close();

        }
    }
}