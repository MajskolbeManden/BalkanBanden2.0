using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace Server
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);
            Clients.All.newMessage(msg);
        }
        
        public void SendExtendedMessage(string name, string message, DateTime time, string groupName)
        {
            var msg = string.Format("{0}: {1} \n >{2}", name, time, message);
            Clients.Group(groupName).newMessage(msg);
            
            //Clients.All.newMessage(msg);
        }

        public void JoinGroup(int room)
        {

        }


        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public void AddToGroup(string userName, string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
            Clients.Group(groupName).newMessage(userName + " joined.");
        }

        public override Task OnDisconnected(bool stopCalled)
        {         
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {         
            return base.OnReconnected();
        }
    }
}
