using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentManagementSystem.Controllers
{
    public class AdminController:ApiController
    {
        StudentManagementSystem1Entities1 sms = new StudentManagementSystem1Entities1();
    }


    public class AdminInformation
    {
        public byte AID { get; set; }
        public string YoneticiAdi { get; set; }
        public string Sifre { get; set; }
    }
}