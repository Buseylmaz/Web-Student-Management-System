using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentManagementSystem.Controllers
{
    public class AnnouncementController : ApiController
    {
        StudentManagementSystem1Entities1 sms = new StudentManagementSystem1Entities1();



        [HttpGet]
        public List<AnnouncementInformation> TumIcerikleriGetir()
        {
            return sms.Announcement.Select(p => new AnnouncementInformation()
            {
                ANID=p.ANID,
                Baslik=p.Baslik,
                Konu=p.Konu,
                Icerik=p.Icerik,
                YayinlanmaTarihi=p.YayinlanmaTarihi
               
            }).ToList();
        }

       

        [HttpGet]
        public List<AnnouncementInformation> DuyuruSil(int ANID)
        {
            
            sms.Announcement.Remove(sms.Announcement.Find(ANID));
            sms.SaveChanges();
            return TumIcerikleriGetir();
        }

        [HttpPost]
        public List<AnnouncementInformation> DuyuruKayitEkle(Announcement announcement)
        {
            try
            {
                sms.Announcement.Add(announcement);
                sms.SaveChanges();
                return TumIcerikleriGetir();
            }
            catch (Exception)
            {

                return null;
            }

        }

        [HttpPost]
        public bool DuyuruGuncelle(Announcement yeni)
        {
            try
            {
                Announcement eski = sms.Announcement.Where(p => p.ANID == yeni.ANID).SingleOrDefault();
                eski.Baslik = yeni.Baslik;
                eski.Konu = yeni.Konu;
                eski.Icerik = yeni.Icerik;
                sms.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

    }


    public class AnnouncementInformation
    {
        public short ANID { get; set; }
        public string Baslik { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public System.DateTime YayinlanmaTarihi { get; set; }

    }
}