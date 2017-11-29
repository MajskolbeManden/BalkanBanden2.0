using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ServerSide
{
    public class MonitorHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}