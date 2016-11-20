using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopomo.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordGeneratedDate { get; set; }
    }
}