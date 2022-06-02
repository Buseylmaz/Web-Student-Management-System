using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Frontend
{
    public partial class OgretmenForm : System.Web.UI.Page
    {
        SqlConnection baglantı = new SqlConnection(@"data source=LAPTOP-RLQS6GBM\SQLEXPRESS;initial catalog=StudentManagementSystem1;integrated security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Teacher WHERE TC=@TTC AND Sifre=@TP", baglantı);
            komut.Parameters.AddWithValue("@TTC", TextBox1.Text);
            komut.Parameters.AddWithValue("@TP", TextBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Response.Redirect("OgretmenIndex.html");

            }
            else
            {
                Response.Write("Hatalı TC Numarası veya Şifre Girdiniz");

            }
            baglantı.Close();

        }
    }
}