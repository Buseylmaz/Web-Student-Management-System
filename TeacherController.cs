using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentManagementSystem.Controllers
{
    public class TeacherController : ApiController
    {
        StudentManagementSystem1Entities1 sms = new StudentManagementSystem1Entities1();

        StudentCourseController scc2 = new StudentCourseController();

        [HttpGet]
        public List<TeacherInformation> TumOgretmenleriGetir()
        {
            return sms.Teacher.Select(p => new TeacherInformation()
            {
                TID = p.TID,
                OgretmenAdi = p.OgretmenAdi,
                TelefonNumarasi = p.TelefonNumarasi,
                TC = p.TC,
                Mail = p.Mail,
                Sifre = p.Sifre

            }).ToList();
        }


        [HttpGet]
        public List<TeacherInformation> OgretmenKayitSil(int TID)
        {
            scc2.CSIDyeGoreOgretemenKayıtSil(TID);
            sms.Teacher.Remove(sms.Teacher.Find(TID));
            sms.SaveChanges();
            return TumOgretmenleriGetir();
        }

        [HttpPost]
        public List<TeacherInformation> OgretmenKayitEkle(Teacher teacher)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(teacher);
                sms.Teacher.Add(teacher);
                sms.SaveChanges();
                return TumOgretmenleriGetir();
            }
            catch (Exception)
            {

                return null;
            }

        }


        [HttpGet]
        public List<TeacherInformation> DersinOgretmeniGetir(int TID)
        {
            List<TeacherInformation> OgretmenListesi = sms.StudentCourse.Where(p => p.TID == TID).Select(p => new TeacherInformation()
            {
                OgretmenAdi = p.Teacher.OgretmenAdi,
                TID = p.Teacher.TID,
                Mail = p.Teacher.Mail
            }).ToList();
            return OgretmenListesi;
        }



        [HttpPost]
        public bool OgretmenGuncelle(Teacher yeni)
        {
            try
            {
                Teacher eski = sms.Teacher.Where(p => p.TID == yeni.TID).SingleOrDefault();
                eski.OgretmenAdi = yeni.OgretmenAdi;
                eski.Sifre = yeni.Sifre;
                eski.TelefonNumarasi = yeni.TelefonNumarasi;
                eski.Mail = yeni.Mail;
                eski.TC = yeni.TC;
                eski.Sifre = yeni.Sifre;
                sms.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }


    }

    public class TeacherInformation
    {
        public short TID { get; set; }
        public string OgretmenAdi { get; set; }
        public string Sifre { get; set; }
        public string TelefonNumarasi { get; set; }
        public string TC { get; set; }
        public string Mail { get; set; }
        public byte AID { get; set; }

    }
}
