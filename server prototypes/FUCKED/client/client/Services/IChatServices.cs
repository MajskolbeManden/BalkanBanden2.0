using client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    public interface IChatServices
    {
        Task Connect();
        Task Send(Message message);        
        event EventHandler<Message> OnMessageReceived;
    }
}
