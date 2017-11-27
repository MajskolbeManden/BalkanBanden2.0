using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace server
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            var msg = string.Format("{0}: {1}", Context.ConnectionId, message);
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