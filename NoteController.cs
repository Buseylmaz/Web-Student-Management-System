using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace StudentManagementSystem.Controllers
{
    public class NoteController : ApiController
    {
        StudentManagementSystem1Entities1 sms = new StudentManagementSystem1Entities1();



        [HttpGet]
        public void NotSilCSIDyeGore(int CSID)
        {
            List<Note> silinecekNotlar = sms.Note.Where(p => p.CSID== CSID).ToList();
            if(silinecekNotlar != null)
            {
                sms.Note.RemoveRange(silinecekNotlar);
                sms.SaveChanges();
            }
        }

        [HttpGet]
        public List<NoteInformation> NotSil(int NID)
        {

            sms.Note.Remove(sms.Note.Find(NID));
            sms.SaveChanges();
            return TumNotlariGetir();
        }



        [HttpPost]
        public List<NoteInformation> NotKayitEkle(Note note)
        {
            try
            {
                sms.Note.Add(note);
                sms.SaveChanges();
                return TumNotlariGetir();
            }
            catch (Exception)
            {

                return null;
            }

        }


        [HttpGet]
        public List<NoteInformation> TumNotlariGetir()
        {
            return sms.Note.Select(p => new NoteInformation()
            {
                NID = p.NID,
                OgrenciAdi = p.OgrenciAdi,
                OgrenciNumarasi=p.OgrenciNumarasi,
                Final = p.Final,
                Vize = p.Vize,
                But = p.But,
                DersAdi=p.DersAdi
               // CSID=p.CSID,
                
               
            }
            ).ToList();
        }

        [HttpGet]
        public List<NoteInformation> OgrenciDersinNotlarınıGetir(int CSID)
        {
            return sms.Note.Where(p => p.CSID  == CSID) .Select(p => new NoteInformation()
            {
                NID=p.NID,
                OgrenciAdi=p.OgrenciAdi,
                OgrenciNumarasi=p.OgrenciNumarasi,
                Final = p.Final,
                Vize=p.Vize,
                But=p.But,
                
                DersAdi=p.DersAdi
                
            }).ToList();
        }

        [HttpPost]
        public bool NotGuncelle(Note yeni)
        {
            try
            {
                Note eski = sms.Note.Where(p => p.NID == yeni.NID).SingleOrDefault();
                eski.OgrenciAdi = yeni.OgrenciAdi;
                eski.OgrenciNumarasi = yeni.OgrenciNumarasi;
                eski.DersAdi = yeni.DersAdi;
                eski.Vize = yeni.Vize;
                eski.Final = yeni.Final;
                eski.But = yeni.But;
                sms.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

    }

    public class NoteInformation
    {
        public short NID { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciNumarasi { get; set; }
        public Nullable<byte> Vize { get; set; }
        public Nullable<byte> Final { get; set; }
        public Nullable<byte> But { get; set; }
        public short CSID { get; set; }
        public string DersAdi { get; set; }
    }
}