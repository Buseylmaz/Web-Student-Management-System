using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class OgretmenListesiForm : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(@"data source=LAPTOP-RLQS6GBM\SQLEXPRESS;initial catalog=StudentManagementSystem1;integrated security=True");
  
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                try
                {
                    SqlCommand komut = new SqlCommand("INSERT INTO Teacher(OgretmenAdi,TelefonNumarasi , TC,Mail,Sifre) VALUES(@TN, @TT,@TC,@TP,@S)", baglanti);
                    komut.Parameters.AddWithValue("@TN", TextBox1.Text);
                    komut.Parameters.AddWithValue("@TT", TextBox2.Text);
                    komut.Parameters.AddWithValue("@TC", TextBox3.Text);
                    komut.Parameters.AddWithValue("@TP", TextBox4.Text);
                    komut.Parameters.AddWithValue("@S", TextBox5.Text);

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Response.Write("Kayıt Başarılı");
                    Response.Redirect("http://localhost:51541/YoneticiIndex.html#!/OgretmenListesi");


                }
                catch (Exception ex)
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
