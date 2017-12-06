using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServer.Models
{
    public class ChatMessage
    {
        #region Property of datatype PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Method to handle updating the view

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region props

        /* UserID used as groupID */
        private string groupID;
        public string GroupID
        {
            get { return groupID; }
            set
            {
                if (value != groupID)
                {
                    groupID = value;
                    OnPropertyChanged(nameof(GroupID));
                }
            }
        }

        /* Users message sent as a string */
        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                if (value != message)
                {
                    message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }

        /* Users name sent as a string */
        private string senderName;
        public string SenderName
        {
            get { return senderName; }
            set
            {
                if (value != senderName)
                {
                    senderName = value;
                    OnPropertyChanged(nameof(SenderName));
                }
            }
        }

        /* MessageID given by the database to keep multiple messages in order */
        private int messageID;
        public int MessageID
        {
            get { return messageID; }
            set
            {
                if (value != messageID)
                {
                    messageID = value;
                    OnPropertyChanged(nameof(MessageID));
                }
            }
        }

        /* Date and time for when the message was sent */
        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set
            {
                if (value != time)
                {
                    time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }
        #endregion
    }
}
