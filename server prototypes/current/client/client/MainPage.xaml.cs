using client.ViewModels;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using client.Models;

namespace client
{
    public partial class MainPage : ContentPage
    {
        //private async void asd(ChatMessage msg)
        //{
        //    chat.On<string>("newMessage", msg);
        //}
        public MainPage()
        {
            
            InitializeComponent();
            var hubConnection = new HubConnection("http://sameh.webdesk-dev.dk");
            var chat = hubConnection.CreateHubProxy("chat");
            chat.On<string>("newMessage", msg =>
            {
                ChatMessage tmp = new ChatMessage();
                tmp.LineOne += string.Format("Recieved msg: {0}", msg);
                App.ViewModel.ChatList.Add(tmp);
            });

            abe.ItemsSource = App.ViewModel.ChatList;

            //    hubConnection.Error += ex =>
            //    {
            //        Device.BeginInvokeOnMainThread(() =>
            //        {
            //            var aggEx = (AggregateException)ex;
            //            App.ViewModel.ChatList.Add(new ChatMessage { LineOne = aggEx.InnerExceptions[0].Message });
            //        });
            //    };

            //    hubConnection.Reconnected += () =>
            //    {
            //        Device.BeginInvokeOnMainThread(() =>
            //        {
            //            App.ViewModel.ChatList.Add(new ChatMessage { LineOne = "Connection restored" });
            //        });
            //    };

            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            hubConnection.Start().ContinueWith(task =>
            {
                var ex = task.Exception.InnerExceptions[0];
                App.ViewModel.ChatList.Add(new ChatMessage { LineOne = ex.Message });
            },
                CancellationToken.None,
                TaskContinuationOptions.OnlyOnFaulted,
                scheduler);
        }
    }
}
