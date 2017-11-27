using System;
using SignalRServer.Models;
using System.Threading.Tasks;

namespace SignalRServer.Services
{
    interface IChatService
    {
        Task Connect();
        event EventHandler<ChatMessage> OnMessageReceived;
        Task Send(ChatMessage message);
    }
}
