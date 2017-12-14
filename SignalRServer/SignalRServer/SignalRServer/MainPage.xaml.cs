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
        public MainPage(string name, string password)
        {
            
            InitializeComponent();
            chatlist.ItemsSource = App.hest.ChatList;
            var ChatMessage1 = App.hest.Cm;
            ChatMessage1.Sender = name;
            ChatMessage1.GroupName = password;
            App.hest.AddtoGroup();

        }

      
    }
}
