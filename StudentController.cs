 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : ApiController //Extends(Kalıtım)
    {
        StudentManagementSystem1Entities1 sms = new StudentManagementSystem1Entities1();
        StudentCourseController scc1 = new StudentCourseController();



        [HttpGet]
        public List<StudentInformation> TumOgrencileriGetir()
        {
            return sms.Student.Select(p => new StudentInformation()
            {
                OgrenciAdi=p.OgrenciAdi,
                OgrenciNumarasi=p.OgrenciNumarasi,
                Mail=p.Mail,
                TelefonNumarasi=p.TelefonNumarasi,
                TC=p.TC,
                Sifre=p.Sifre
            }
            ).ToList();
        }


        [HttpPost]
        public List<StudentInformation> OgrenciKayitEkle(Student student)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(student);
                sms.Student.Add(student);
                sms.SaveChanges();
                return TumOgrencileriGetir();
            }
            catch (Exception)
            {

                return null;
            }
            
        }


        [HttpGet]
        public List<StudentInformation> OgrenciSil(int SID)
        {
            scc1.OgrenciDersSilOgrenciIDGore(SID);
            sms.Student.Remove(sms.Student.Find(SID));
            sms.SaveChanges();
            return TumOgrencileriGetir();

        }

        [HttpPost]
        public bool OgrenciGuncelle(Student yeni)
        {
            try
            {
                Student eski = sms.Student.Where(p => p.SID == yeni.SID).SingleOrDefault();
                eski.OgrenciAdi = yeni.OgrenciAdi;
                eski.Sifre = yeni.Sifre;
                eski.OgrenciNumarasi = yeni.OgrenciNumarasi;
                eski.Mail = yeni.Mail;
                eski.TC = yeni.TC;
                eski.TelefonNumarasi = yeni.TelefonNumarasi;
                sms.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }

    public class StudentInformation
    {
        public short SID { get; set; }
        public string OgrenciAdi { get; set; }
        public string Sifre { get; set; }
        public string OgrenciNumarasi { get; set; }
        public string Mail { get; set; }
        public string TC { get; set; }
        public string TelefonNumarasi { get; set; }
        public System.DateTime DersiAlmaZamani { get; set; }
        public string OgretmenAdi { get; set; }
        public string DersAdi { get; set; }

    }
}