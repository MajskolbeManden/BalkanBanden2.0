using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServer.Models
{
    class Group
    {
        public int groupID;
        public int adminID;

        public Group(int userID, int adminID)
        {
            this.groupID = userID;
            this.adminID = adminID;
        }
    }
}
