using client.ViewModels;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using client.Model;

namespace client
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            abe.ItemsSource = ChatView.ChatList;
            var hubConnection = new HubConnection("http://sameh.webdesk-dev.dk");
            var chat = hubConnection.CreateHubProxy("chat");
            chat.On<string>("newMessage", msg =>
            {
                Message tmp = new Message();
                tmp.LineOne += string.Format("Recieved msg: {0}", msg);
                tmp.LineOne = msg;
                ChatView.ChatList.Add(tmp);

            });

            //chat.On<string>("newMessage", msg =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        App.ViewModel.Items.Add(new ItemViewModel { LineOne = msg });
            //    });
            //});
            //chat.On<string>("newMessage", msg =>
            // {
            //     ItemViewModel
            // });


            //hubConnection.Error += ex =>
            //    {
            //        Device.BeginInvokeOnMainThread(() =>
            //        {
            //            var aggEx = (AggregateException)ex;
            //            ChatView.ChatList.Add(new Message { LineOne = aggEx.InnerExceptions[0].Message });
            //        });
            //    };

            //hubConnection.Reconnected += () =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        ChatView.ChatList.Add(new Message { LineOne = "Connection restored" });
            //    });
            //};

            //var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //hubConnection.Start().ContinueWith(task =>
            //{
            //    var ex = task.Exception.InnerExceptions[0];
            //    ChatView.ChatList.Add(new Message { LineOne = ex.Message });
            //},
            //    CancellationToken.None,
            //    TaskContinuationOptions.OnlyOnFaulted,
            //    scheduler);
        }
    }
    
}
