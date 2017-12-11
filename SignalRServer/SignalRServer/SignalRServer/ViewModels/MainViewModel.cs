﻿using SignalRServer.Models;
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
        #region User Property
        private User u;
        public User U
        {
            get { return u; }
            set
            {
                u = value;
                OnPropertyChanged(nameof(U));
            }
        }
        #endregion

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
            ChatList = new ObservableCollection<ChatMessage>();
            LoadChatList();
            chatservice.Connect();
            chatservice.AddToGroup(Cm.Message, U.password);
            chatservice.OnMessageReceived += chatservice_OnMessageReceived;
            SendMessageCommand = new RelayCommand(ExecuteSendMessageCommand);
        }

        private void chatservice_OnMessageReceived(object sender, ChatMessage e)
        {
            Device.BeginInvokeOnMainThread(() =>
            ChatList.Add(new ChatMessage { Message = e.Message, SenderName = e.SenderName, Time = e.Time}));
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
            await chatservice.Send(new ChatMessage { Message= Cm.Message, SenderName = cm.GroupID, Time = DateTime.Now }, U.password);
        }
        #endregion
    }
}
