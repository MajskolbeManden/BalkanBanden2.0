using SignalRServer.Handlers;
using SignalRServer.Models;
using SignalRServer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
        MessageHandler Mh = new MessageHandler();
        public ObservableCollection<ChatMessage> ChatList { get; set; }

        /// <summary>
        /// testing purposes
        /// </summary>
        public async void LoadChatList()
        {
            try
            {
                ChatList = await Handlers.CRUD.GetMessages();
            }
            catch (Exception)
            {

                throw;
            }
        }

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

        private static MainViewModel ghost = new MainViewModel();
        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (ghost == null)
                    ghost = new MainViewModel();

                return ghost;
            }
        }

        private  MainViewModel()
        {
            Cm = new ChatMessage();
            Mh = new MessageHandler();
            ChatList = new ObservableCollection<ChatMessage>();
            LoadChatList();
            chatservice.Connect();
            chatservice.OnMessageReceived += chatservice_OnMessageReceived;
            SendMessageCommand = new RelayCommand(ExecuteSendMessageCommand);
        }

        public void AddtoGroup()
        {
            chatservice.AddToGroup(Cm.Sender, Cm.GroupName);
        }
        public virtual void NotifyUser(ChatMessage message)
        {
            if(message.Sender != null)
            {
                INotify notify = DependencyService.Get<INotify>();
                if (notify != null)
                {
                    notify.NotifyUser(message);
                }
            }
            else
            {
                if(message != null)
                {
                    if(message.Message != null)
                    {
                        if (message.Message.Contains(":"))
                        {
                            int index = message.Message.IndexOf(":");
                            message.Sender = message.Message.Remove(index);
                            INotify notify = DependencyService.Get<INotify>();
                            if (notify != null)
                            {
                                notify.NotifyUser(message);
                            }
                        }
                    }
                }
            }
        }

        private void chatservice_OnMessageReceived(object sender, ChatMessage e)
        {
            ChatMessage message = new ChatMessage();
            if (e.Message.Contains(":"))
            {
                int index = e.Message.IndexOf(":");
                message.Sender = e.Message.Remove(index);
                if (e.Message.Contains("\n"))
                {
                    IFormatProvider culture = new CultureInfo("da-DK");
                    string time = e.Message.Substring(index + 2, 19);
                    message.Time = DateTime.Parse(time,culture, System.Globalization.DateTimeStyles.AdjustToUniversal);
                }
                index = e.Message.IndexOf("\n");
                message.Message = e.Message.Substring(index+3);
            }
            Device.BeginInvokeOnMainThread(() =>
            ChatList.Add(new ChatMessage { Message = message.Message, Sender = message.Sender, Time = message.Time}));
            NotifyUser(new ChatMessage {Message = message.Message, Sender = message.Sender, Time = message.Time});
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
            Mh.AddMessage(new ChatMessage { Message = Cm.Message, Sender = Cm.Sender, Time = DateTime.Now, GroupName = Cm.GroupName });
            await chatservice.Send(new ChatMessage { Message= Cm.Message, Sender = Cm.Sender, Time = DateTime.Now, GroupName = Cm.GroupName }, Cm.GroupName);

        }
#endregion
    }
}
