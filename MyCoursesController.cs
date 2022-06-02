using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentManagementSystem.Controllers
{
    public class MyCoursesController : ApiController
    {
        StudentManagementSystem1Entities1 sms = new StudentManagementSystem1Entities1();

        [HttpGet]
        public List<MyCoursesInformation> TumDerslerimiGetir()
        {
            return sms.MyCourses.Select(p => new MyCoursesInformation()
            {
                DersAdi=p.Course.DersAdi,
                DersIcerik=p.Course.DersIcerik,
                DersKredi=p.Course.DersKredi,
                DersAKTS=p.Course.DersAKTS,
                OgretmenAdi=p.Course.OgretmenAdi
               
            }
            ).ToList();
        }



        [HttpPost]
        public List<MyCoursesInformation> DerslerimeKaydet(MyCourses myCourses)
        {
            try
            {
                sms.MyCourses.Add(myCourses);
                sms.SaveChanges();
                return TumDerslerimiGetir();
            }
            catch (Exception)
            {

                return null;
            }

        }

    }



    public class MyCoursesInformation
    {
        public byte MID { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciNumarasi { get; set; }
        public short CID { get; set; }
        public string DersAdi { get; set; }
        public string DersIcerik { get; set; }
        public byte DersKredi { get; set; }
        public byte DersAKTS { get; set; }
        public string OgretmenAdi { get; set; }

    }

}