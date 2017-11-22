using client.ViewModels;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace client
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); var hubConnection = new HubConnection("http://sameh.webdesk-dev.dk");
            var chat = hubConnection.CreateHubProxy("chat");
            chat.On<string>("newMessage", msg =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    App.ViewModel.Items.Add(new ItemViewModel { LineOne = msg });
                });
            });

            hubConnection.Error += ex =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var aggEx = (AggregateException)ex;
                    App.ViewModel.Items.Add(new ItemViewModel { LineOne = aggEx.InnerExceptions[0].Message });
                });
            };

            hubConnection.Reconnected += () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    App.ViewModel.Items.Add(new ItemViewModel { LineOne = "Connection restored" });
                });
            };

            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            hubConnection.Start().ContinueWith(task =>
            {
                var ex = task.Exception.InnerExceptions[0];
                App.ViewModel.Items.Add(new ItemViewModel { LineOne = ex.Message });
            },
                CancellationToken.None,
                TaskContinuationOptions.OnlyOnFaulted,
                scheduler);
        }
    }
}
