using Xam_sqlite.Services;
using Xam_sqlite.Views;
using Xamarin.Forms;

namespace Xam_sqlite
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DbService.Instance.CreateAppTables();
            MainPage = new NavigationPage(new HomePage());

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
