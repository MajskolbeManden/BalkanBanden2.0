using System.ComponentModel;

namespace chatshit.ViewModels
{
    public class ItemViewModel
    {
        private string id;
        public string ID
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged("ID");
                }
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
                    NotifyPropertyChanged("LineOne");
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
                    NotifyPropertyChanged("LineTwo");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
