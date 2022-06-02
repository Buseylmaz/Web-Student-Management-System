using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentManagementSystem.Controllers
{
    public class StudentCourseController : ApiController
    {
        StudentManagementSystem1Entities1 sms = new StudentManagementSystem1Entities1();

        NoteController nc = new NoteController();


        public void CSIDyeGoreOgretemenKayıtSil(int TID)
        {
            List<StudentCourse> silinecekOgretmen = sms.StudentCourse.Where(p => p.TID == TID).ToList();
            if (silinecekOgretmen != null)
            {
                sms.StudentCourse.RemoveRange(silinecekOgretmen);
                sms.SaveChanges();
            }
        }


        public void OgrenciDersSilDersIDGore(int CID)//derse göre sil
        {
            List<StudentCourse> silenecekDers = sms.StudentCourse.Where(p => p.CID == CID).ToList();
            foreach (StudentCourse item in silenecekDers)
            {
                nc.NotSilCSIDyeGore(item.CSID);
                sms.StudentCourse.Remove(item);
                sms.SaveChanges();
            }
        }

        public void OgrenciDersSilOgrenciIDGore(int SID)//ögrenciye göre sil
        {
            List<StudentCourse> silenecek = sms.StudentCourse.Where(p => p.SID == SID).ToList();
            foreach (StudentCourse item in silenecek)
            {
                nc.NotSilCSIDyeGore(item.CSID);
                sms.StudentCourse.Remove(item);
                sms.SaveChanges();
            }
        }

        [HttpGet]
        public bool OgrenciDersSilOgrenciDersIDGore(int CSID)
        {
            try
            {
                sms.StudentCourse.Remove(sms.StudentCourse.Find(CSID));
                sms.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        [HttpGet]
        public List<StudentInformation> DersiAlanOgrencileriGetir(int CID)
        {
            List<StudentInformation> DersListesi = sms.StudentCourse.Where(p => p.CID == CID).Select(p => new StudentInformation()
            {
                OgrenciNumarasi=p.Student.OgrenciNumarasi,
                OgrenciAdi = p.Student.OgrenciAdi,
                OgretmenAdi=p.OgretmenAdi,
                DersAdi=p.DersAdi,
                DersiAlmaZamani=p.DersiAlmaZamani,

                
                 
            }).ToList();

            return DersListesi;
        }




        public class StudentCourseInformation
        {
            public short CSID { get; set; }
            public System.DateTime DersiAlmaZamani { get; set; }
            public string OgrenciAdi { get; set; }
            public string OgretmenAdi { get; set; }
            public string DersAdi { get; set; }
            public short SID { get; set; }
            public short CID { get; set; }
            public short TID { get; set; }
            public string OgrenciNumarasi { get; set; }

        }
    }
}