using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class GroupModel
    {
        public int UserID { get; set; }
        public int AdminID { get; set; }
        public string GroupName { get; set; }
    }
}