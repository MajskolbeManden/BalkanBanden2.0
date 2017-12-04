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
        private string id;
        public string ID
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        /* Users message sent as a string */
        private string lineOne;
        public string LineOne
        {
            get { return lineOne; }
            set
            {
                if (value != lineOne)
                {
                    lineOne = value;
                    OnPropertyChanged(nameof(LineOne));
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
        private DateTime dateTime;
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                if (value != dateTime)
                {
                    dateTime = value;
                    OnPropertyChanged(nameof(DateTime));
                }
            }
        }
        #endregion
    }
}
