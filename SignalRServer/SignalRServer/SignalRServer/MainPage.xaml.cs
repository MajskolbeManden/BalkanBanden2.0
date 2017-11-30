using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SignalRServer.Models;

namespace SignalRServer
{
    public partial class MainPage : ContentPage
    {
        string Name;
        public MainPage(string name)
        {
            Name = name;
            
            InitializeComponent();
            chatlist.ItemsSource = App.ViewModel.ChatList;
            var ChatMessage1 = new ChatMessage();
            ChatMessage1.ID = Name;

        }

      
    }
}
