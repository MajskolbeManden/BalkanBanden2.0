using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace server
{
    [HubName("monitor")]
    public class MonitorHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}