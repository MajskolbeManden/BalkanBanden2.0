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
//using Microsoft.Toolkit.Uwp.Notifications; //this is a xml to C# library, that helps creating notifications in C#

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
        }
    }
}
