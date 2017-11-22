using chatshit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace chatshit
{
    public partial class App : Application
    {
        //private static MainViewModel viewModel = null;
        //public static MainViewModel ViewModel
        //{
        //    get
        //    {
        //        if (ViewModel == null)
        //            viewModel = new MainViewModel();
        //        return viewModel;
        //    }
        //}
        private static readonly MainViewModel viewModel = new MainViewModel();
        public static MainViewModel ViewModel
        {
            get { return viewModel; }
        }
        public App()
        {
            InitializeComponent();
            MainViewModel mvm = new MainViewModel();
            MainPage = new chatshit.MainPage();
            MainPage = new NavigationPage(new chatshit.MainPage());
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
