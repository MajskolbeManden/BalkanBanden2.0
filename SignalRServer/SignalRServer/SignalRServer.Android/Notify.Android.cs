using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SignalRServer.Models;
using SignalRServer.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SignalRServer.Droid.Notify))]
namespace SignalRServer.Droid
{
    public class Notify : INotify
    {
        public void NotifyUser(ChatMessage message)
        {
            Notification.Builder builder = new Notification.Builder(Android.App.Application.Context);
            builder.SetContentTitle("New Message");
            builder.SetContentText("From " + message.Sender);
            builder.SetSmallIcon(Resource.Drawable.icon);

            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager = Android.App.Application.Context.GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);

        }
    }
}