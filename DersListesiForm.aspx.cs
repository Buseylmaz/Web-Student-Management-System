using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class DersListesiForm : System.Web.UI.Page
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
                    SqlCommand komut = new SqlCommand("INSERT INTO Course(DersAdi,OgretmenAdi,DersIcerik,DersKredi,DersAKTS) VALUES(@DA,@OD,@DI,@DK,@DAK)", baglanti);
                    komut.Parameters.AddWithValue("@DA", TextBox2.Text);
                    komut.Parameters.AddWithValue("@OD", TextBox3.Text);
                    komut.Parameters.AddWithValue("@DI", TextBox4.Text);
                    komut.Parameters.AddWithValue("@DK", TextBox5.Text);
                    komut.Parameters.AddWithValue("@DAK", TextBox1.Text);

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Response.Write("Kayıt Başarılı");
                    Response.Redirect("http://localhost:51541/YoneticiIndex.html#!/OgrencilerinListesi");


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