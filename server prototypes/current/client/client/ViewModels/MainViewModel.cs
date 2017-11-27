using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.Models;

namespace client.ViewModels
{
    public class MainViewModel
    {
        private IHubProxy chat;

        public ObservableCollection<ChatMessage> ChatList { get; private set; }

        public MainViewModel()
        {
            ChatList = new ObservableCollection<ChatMessage>();
        }
    }
}
