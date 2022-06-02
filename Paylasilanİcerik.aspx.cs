using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;



namespace Frontend
{
    public partial class Paylasilanİcerik : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(@"data source=LAPTOP-RLQS6GBM\SQLEXPRESS;initial catalog=StudentManagementSystem1;integrated security=True");
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                try
                {
                    SqlCommand komut = new SqlCommand("INSERT INTO Announcement (Baslik, Konu, YayinlanmaTarihi,Icerik) VALUES(@B, @K,@YT,@I)", baglanti);
                    komut.Parameters.AddWithValue("@B", TextBox1.Text);
                    komut.Parameters.AddWithValue("@K", TextBox2.Text);
                    komut.Parameters.AddWithValue("@YT", TextBox3.Text);
                    komut.Parameters.AddWithValue("@I", TextBox4.Text);

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Response.Write("Kayıt Başarılı");
                    Response.Redirect("http://localhost:51541/OgretmenIndex.html#!/PaylasilanIcerik");
                     

                }
                catch(Exception ex)
                {
                    Response.Write(ex);
                    Response.Write("Kayıt Başarısız.Lütfen bütün alanları doldurduğunuzdan emin olunuz!!!");
                }
                finally
                {

                    baglanti.Close();
                }
            }


        }
    }
}
