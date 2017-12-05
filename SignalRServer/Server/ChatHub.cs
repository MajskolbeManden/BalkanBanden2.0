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
        
        public void SendExtendedMessage(string name, string message, DateTime time)
        {
            var msg = string.Format("{0}: {1} \n >{2}", name, time, message);
            Clients.All.newMessage(msg);
        }

        public void SendMessageData(SendData data)
        {
            Clients.All.newData(data);
        }

        public override Task OnConnected()
        {
            SendMonitorData("Connected", Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            SendMonitorData("Disconnected", Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            SendMonitorData("Reconnected", Context.ConnectionId);
            return base.OnReconnected();
        }

        private void SendMonitorData(string eventType, string connection)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
            context.Clients.All.newEvent(eventType, connection);
        }
    }

    public class SendData
    {
        public int ID { get; set; }
        public string Data { get; set; }
    }
}
