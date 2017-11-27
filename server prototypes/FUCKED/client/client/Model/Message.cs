using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace client.Model
{
    public class Message : INotifyPropertyChanged
    {
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

        #region Property of datatype PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Method to handle updating the view

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
#endregion
    }
}
