using Expenses.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Expenses
{
    public partial class App : Application
    {
        //accessable glabally to set from the native os's
        public static string DatabasePath;

        public App()
        {
            InitializeComponent();

            //-->old code MainPage = new MainPage();
            //sets the navigation object to the main page
            MainPage = new NavigationPage(new MainPage());
        }

        /// <summary>
        /// Overload accepts the string database location for all platforms.
        /// </summary>
        /// <param name="thedatabasepath"></param>
        public App(string thedatabasepath)
        {
            InitializeComponent();
            //assigning the variable a local/native database path
            DatabasePath = thedatabasepath;
            //setting the startup page in the navigation object
            MainPage = new NavigationPage(new MainPage());
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
