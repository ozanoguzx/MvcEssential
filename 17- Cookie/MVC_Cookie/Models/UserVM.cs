using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Cookie.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}