using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class OgrencilerinListesiForm : System.Web.UI.Page
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
                    SqlCommand komut = new SqlCommand("INSERT INTO Student(OgrenciAdi,OgrenciNumarasi,Mail,TC,TelefonNumarasi,Sifre) VALUES(@SN,@SNo,@SM,@ST,@TN,@Sp)", baglanti);
                    komut.Parameters.AddWithValue("@SN", TextBox1.Text);
                    komut.Parameters.AddWithValue("@SNo", TextBox2.Text);
                    komut.Parameters.AddWithValue("@SM", TextBox3.Text);
                    komut.Parameters.AddWithValue("@ST", TextBox4.Text);
                    komut.Parameters.AddWithValue("@TN", TextBox5.Text);
                    komut.Parameters.AddWithValue("@Sp", TextBox6.Text);

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Response.Write("Kayıt Başarılı");
                    Response.Redirect("http://localhost:51541/YoneticiIndex.html#!/DersListesi");


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