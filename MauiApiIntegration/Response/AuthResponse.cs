using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauimyApp3.Models.Response
{
    public class AuthResponse
    {
        public string userId { get; set; }
        public string jwtToken { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string emailId { get; set; }
    }
}
