using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SignalRServer.Services;
using SignalRServer.Models;
using Xamarin.Forms;
using UserNotifications;


[assembly: Dependency(typeof(SignalRServer.iOS.Notify))]
namespace SignalRServer.iOS
{
    public class Notify : INotify
    {
        public void NotifyUser(ChatMessage message)
        {
            var content = new UNMutableNotificationContent();
            content.Title = "New Message";
            content.Subtitle = "From" + message.Sender;
            content.Body = message.Message;
            content.Badge = 1;

            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(1, false);

            var requestID = "sampleRequest";
            var request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                if (err != null)
                {
                    // Do something with error...
                }
            });
        }
    }
}