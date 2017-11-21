using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.AspNet.SignalR.Client;

namespace chatshit.ViewModels
{
    public class MainViewModel
    {
        private IHubProxy chat;

        public MainViewModel() { this.Items = new ObservableCollection<ItemViewModel>(); }
            

        public ObservableCollection<ItemViewModel> Items { get; private set; }
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
