using SignalRServer.Models;
using SignalRServer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SignalRServer.ViewModels
{
    public class MainViewModel
    {
        private ChatService chatservice = new ChatService();
        public ObservableCollection<ChatMessage> ChatList { get; set; }

        #region Message Property
        private ChatMessage cm;
        public ChatMessage Cm
        {
            get { return cm; }
            set
            {
                cm = value;
                OnPropertyChanged(nameof(Cm));
            }
        }
#endregion

        public MainViewModel()
        {

            Cm = new ChatMessage();
            ChatList = new ObservableCollection<ChatMessage>();
            ChatList.Add(new ChatMessage { LineOne = "abc" });
            chatservice.Connect();
            chatservice.OnMessageReceived += chatservice_OnMessageReceived;
            SendMessageCommand = new RelayCommand(ExecuteSendMessageCommand);
        }

        private void chatservice_OnMessageReceived(object sender, ChatMessage e)
        {
            Device.BeginInvokeOnMainThread(() =>
            ChatList.Add(new ChatMessage { LineOne = e.LineOne }));
        }

        #region Property of datatype PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Method to handle updating the view
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region send text messages

        public RelayCommand SendMessageCommand { get; set; }
        async void ExecuteSendMessageCommand()
        {
            await chatservice.Send(new ChatMessage { LineTwo = Cm.LineTwo });
        }
        #endregion
    }
}
