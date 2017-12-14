using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRServer.Models;
using Microsoft.AspNet.SignalR.Client;
using SignalRServer.Handlers;

namespace SignalRServer.Services
{
    public class ChatService : IChatService
    {
        private readonly HubConnection connection;
        private readonly IHubProxy proxy;

        public event EventHandler<ChatMessage> OnMessageReceived;

        public ChatService()
        {

            connection = new HubConnection("http://sameh.webdesk-dev.dk/");
            proxy = connection.CreateHubProxy("chat");

        }

        public async Task Connect()
        {
            await connection.Start();
            proxy.On("newMessage", (string message) => OnMessageReceived(this, new ChatMessage
            {
                Message = message
            }));
        }

        public async Task AddToGroup(string userName, string groupName)
        {
            await proxy.Invoke("AddToGroup", userName, groupName);
        }

        public async Task Send(ChatMessage message, string groupName)
        {
            await proxy.Invoke("SendExtendedMessage",message.Sender, message.Message, message.Time, groupName);            
        }
    }
}
