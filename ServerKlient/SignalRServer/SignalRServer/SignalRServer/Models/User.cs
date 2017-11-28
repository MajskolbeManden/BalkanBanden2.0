using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServer.Models
{
    public class User
    {
        public int userID;
        public string username;
        public string password;

        public User(int userID, string userName, string userPassword)
        {
            this.userID = userID;
            this.username = userName;
            this.password = userPassword;
        }
    }
}
