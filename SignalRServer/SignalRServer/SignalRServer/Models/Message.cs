using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServer.Models
{
    class Message
    {
        public int messageID;
        public int groupID;
        public DateTime dateTime;
        public string message;
        public string senderName;

        public Message(int messageID, int groupID, DateTime dateTime, string message, string senderName)
        {
            this.messageID = messageID;
            this.groupID = groupID;
            this.dateTime = dateTime;
            this.message = message;
            this.senderName = senderName;
        }
    }
}
