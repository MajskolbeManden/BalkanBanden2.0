using SignalRServer.ViewModels;
using Xamarin.Forms;

namespace SignalRServer
{
    public partial class App : Application
    {

      public static MainViewModel hest;

        public App()
        {
            InitializeComponent();
          hest = MainViewModel.ViewModel;
            MainPage = new NavigationPage(new LogIndPage());
           
            

          //  MainPage = new MainPage { BindingContext = new MainViewModel() };
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            /*Check for connection with SignalR
             * if connection failed, display connection error
             * and grey out boxes (if possible).
             */
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            /*Check for connection with SignalR
             * if connection failed, log out,
             * and display connection error
             * 
             * else check for new messages.
             * if there are new messages,
             * then show new messages.
             */
        }
    }
}
