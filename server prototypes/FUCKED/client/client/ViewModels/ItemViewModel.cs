using client.Model;
using client.Services;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace client.ViewModels
{
    public class ItemViewModel
    {
        #region props
        //private IHubProxy chat;
        ChatService _chatServices;
        #endregion

        public ItemViewModel()
        {
            _chatServices = new ChatService();
            Message etnavn = new Message();

            
            //();
            _chatServices.OnMessageReceived += _chatServices_OnMessageReceived;
        }
        void _chatServices_OnMessageReceived(object sender, Message e)
        {
            ChatView.ChatList.Add(new Message {  LineOne = e.LineOne });
        }

    }
}
