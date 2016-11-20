using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.Models
{
    public class InvalidLogin
    {
        public string Username { get; set; }
        public DateTime Attempt { get; set; }
    }
}
