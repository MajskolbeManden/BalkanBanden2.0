using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}