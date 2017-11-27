using SignalRServer.ViewModels;
using Xamarin.Forms;

namespace SignalRServer
{
    public partial class App : Application
    {

        private static MainViewModel viewModel = null;
        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (viewModel == null)
                    viewModel = new MainViewModel();

                return viewModel;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new SignalRServer.MainPage { BindingContext = new MainViewModel() };
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
