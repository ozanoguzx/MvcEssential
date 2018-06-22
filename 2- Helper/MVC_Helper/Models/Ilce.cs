using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Helper.Models
{
    public class Ilce
    {
        public int ID { get; set; }
        public string IlceAdi { get; set; }
        public int SehirID { get; set; }
    }
}