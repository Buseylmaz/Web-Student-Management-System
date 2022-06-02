using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class NotForm1 : System.Web.UI.Page
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
                    SqlCommand komut = new SqlCommand("INSERT INTO Note(OgrenciAdi,OgrenciNumarasi,DersAdi,Vize,Final,But) VALUES(@OD,@ON,@DA,@V,@F,@B)", baglanti);
                    komut.Parameters.AddWithValue("@OD", TextBox4.Text);
                    komut.Parameters.AddWithValue("@ON", TextBox5.Text);
                    komut.Parameters.AddWithValue("@DA", TextBox6.Text);
                    komut.Parameters.AddWithValue("@V", TextBox1.Text);
                    komut.Parameters.AddWithValue("@F", TextBox2.Text);
                    komut.Parameters.AddWithValue("@B", TextBox3.Text);
                    

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    Response.Write("Kayıt Başarılı");
                    Response.Redirect("http://localhost:51541/OgretmenIndex.html#!/Not");


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