using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace client.Models
{
    public class ChatMessage : INotifyPropertyChanged
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
        private string lineTwo;
        public string LineTwo
        {
            get { return lineTwo; }
            set
            {
                if (value != lineTwo)
                {
                    lineTwo = value;
                    OnPropertyChanged(nameof(LineTwo));
                }
            }
        }
#endregion
    }
}
