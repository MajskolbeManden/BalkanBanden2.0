using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace chatshit
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(Username.Text))
            //{
            //    await DisplayAlert("chat", "giv mig dit navn", "Ok!");
            //    return;
            //}
            await Navigation.PushAsync(new chatpage());
        }
    }
}
