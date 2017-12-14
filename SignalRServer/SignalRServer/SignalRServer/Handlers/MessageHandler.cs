using SignalRServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServer.Handlers
{
    public class MessageHandler
    {
        public ViewModels.MainViewModel Mvm { get; set; }
        public MessageHandler(ViewModels.MainViewModel mvm)
        {
            Mvm = mvm;
        }
        public MessageHandler()
        {

        }
        public void AddMessage(ChatMessage tempMessage)
        {
            tempMessage.GroupID = 8;
            
            CRUD.PostMessage(tempMessage);
        }
    }
}
