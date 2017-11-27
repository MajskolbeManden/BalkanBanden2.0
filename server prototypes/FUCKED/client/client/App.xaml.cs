using client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace client
{
    public partial class App : Application
    {

        private static ItemViewModel viewModel = null;
        public static ItemViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (viewModel == null)
                    viewModel = new ItemViewModel();

                return viewModel;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new client.MainPage();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
