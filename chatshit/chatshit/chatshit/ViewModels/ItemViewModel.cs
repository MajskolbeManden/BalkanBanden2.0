using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace chatshit.ViewModels
{
    public class ItemViewModel: INotifyPropertyChanged
    {
        private string pickMe;
        public ItemViewModel()
        {
        }
        private string id;
        public string ID
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                   // NotifyPropertyChanged("ID");
                }
            }
        }
        public string PickMe
        {
            get { return pickMe; }
            set
            {
                pickMe = value;
                OnPropertyChanged(nameof(PickMe));
            }
        }
        private string lineOne;
        public string LineOne
        {
            get { return lineOne; }
            set
            {

                if (value  != lineOne)
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
                    lineOne = value;
                   OnPropertyChanged(nameof(LineTwo));
                }
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void NotifyPropertyChanged(string propertyName)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (null != handler)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
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
