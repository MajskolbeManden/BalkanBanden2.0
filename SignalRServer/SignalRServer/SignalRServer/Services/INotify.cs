using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRServer.Models;

namespace SignalRServer.Services
{
    public interface INotify
    {
        void NotifyUser(ChatMessage message);
    }
}
