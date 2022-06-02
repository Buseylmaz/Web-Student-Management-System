using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentManagementSystem.Controllers
{
    public class CourseController: ApiController
    {

        StudentManagementSystem1Entities1 sms = new StudentManagementSystem1Entities1();


        StudentCourseController scc1 = new StudentCourseController();
        

        [HttpGet]
        public List<CourseInformation> DersSil(int CID)
        {
            scc1.OgrenciDersSilOgrenciIDGore(CID);
            sms.Course.Remove(sms.Course.Find(CID));
            sms.SaveChanges();
            return TumDersleriGetir();

        }

        [HttpPost]
        public List<CourseInformation> DersKayitEkle(Course course)
        {
            try
            {
                sms.Course.Add(course);
                sms.SaveChanges();
                return TumDersleriGetir();
            }
            catch (Exception)
            {

                return null;
            }

        }

        [HttpGet]
        public List<CourseInformation> TumDersleriGetir()
        {
            return sms.Course.Select(p => new CourseInformation()
            {
                CID=p.CID,
                DersAdi=p.DersAdi,
                OgretmenAdi=p.OgretmenAdi,
                DersIcerik=p.DersIcerik,
                DersKredi=p.DersKredi,
                DersAKTS=p.DersAKTS
            }
            ).ToList(); 
        }


        [HttpPost]
        public bool DersGuncelle(Course yeni)
        {
            try
            {
                Course eski = sms.Course.Where(p => p.CID==yeni.CID).SingleOrDefault();
                eski.DersAdi = yeni.DersAdi;
                eski.DersAKTS = yeni.DersAKTS;
                eski.DersIcerik = yeni.DersIcerik;
                eski.DersKredi = yeni.DersKredi;
                eski.OgretmenAdi = yeni.OgretmenAdi;
                sms.SaveChanges();       
                return true;
            }
            catch(Exception)
            {
                return false;

            }
        }

    }



    public class CourseInformation
    {
        public short CID { get; set; }
        public string DersAdi { get; set; }
        public string DersIcerik { get; set; }
        public byte DersKredi { get; set; }
        public byte DersAKTS { get; set; }
        public string OgretmenAdi { get; set; }


    }
}