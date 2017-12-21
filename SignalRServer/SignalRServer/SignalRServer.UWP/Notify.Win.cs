using SignalRServer.Services;
using Windows.UI.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRServer.Models;
using Xamarin.Forms;
using Windows.ApplicationModel.Activation;
using Microsoft.Toolkit.Uwp.Notifications; //this is a xml to C# library, that helps creating notifications in C#. NuGet Package.

[assembly: Dependency(typeof(SignalRServer.UWP.Notify))]
namespace SignalRServer.UWP
{
    public class Notify : INotify
    {
        public void NotifyUser(ChatMessage message)
        {
            //To be Added
            //Use Toast (Universal App notification system)
            //Toast constructor needs Visual but Action and Buttons can be added, but not required.
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                        Text = "New Message"
                        },

                        new AdaptiveText()
                        {
                        Text = "From " + message.Sender
                        }
                    },
                }
            };

            ToastContent toastContent = new ToastContent()
            {
                Visual = visual
            };
            // And create the toast notification
            var toast = new ToastNotification(toastContent.GetXml());

            //Send the notification
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
