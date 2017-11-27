using client.Model;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Services
{
    class ChatService : IChatServices
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy chat;

        public event EventHandler<Message> OnMessageReceived;

        public ChatService()
        {
            _connection = new HubConnection("http://sameh.webdesk-dev.dk");
            chat = _connection.CreateHubProxy("chat");
            _connection.Start();
        }
      

        #region IChatServices implementation

        public async Task Connect()
        {

            chat.On<string>("newMessage", msg =>
            {
                Message tmp = new Message();
                tmp.LineOne += string.Format("Recieved msg: {0}", msg);
                tmp.LineOne = msg;
                ChatView.ChatList.Add(tmp);

            });

        }

        public async Task Send(Message message)
        {
            //chat.On("newMessage", (string lineOne) => OnMessageReceived(this, new Message
            //{
            //    LineOne = lineOne
            //}));
            //await chat.Invoke("newMessage", message.LineOne);
        }

        #endregion
    }
}
