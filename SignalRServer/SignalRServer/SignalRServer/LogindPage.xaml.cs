using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRServer.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignalRServer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIndPage : ContentPage
    {
        public LogIndPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Password.Text))
            {
                await DisplayAlert("support", "Please enter username and/or password", "OK");

                return;
            }
            await Navigation.PushAsync(new MainPage(Username.Text, Password.Text) { BindingContext = MainViewModel.ViewModel });

        }
    }
}