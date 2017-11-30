﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRServer.Models;
using Microsoft.AspNet.SignalR.Client;

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
            proxy.On("newMessage", (string lineOne) => OnMessageReceived(this, new ChatMessage
            {
                LineOne = lineOne
            }));
        }

        public async Task Send(ChatMessage message)
        {
<<<<<<< HEAD
            await proxy.Invoke("SendExtendedMessage", message.ID, message.LineTwo);
=======
            await proxy.Invoke("SendMessage", message.LineOne);
>>>>>>> cadda579432d38df9bd8ef86c00ee235963bb1ac
        }
    }
}
