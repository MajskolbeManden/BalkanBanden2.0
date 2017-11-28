using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServer.Models
{
    public class Admin
    {
        public int adminID;
        public string username;
        public string password;

        public Admin(int adminID, string username, string password)
        {
            this.adminID = adminID;
            this.username = username;
            this.password = password;
        }
    }
}
