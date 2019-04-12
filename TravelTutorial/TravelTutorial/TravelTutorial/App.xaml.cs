using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TravelTutorial
{
	public partial class App : Application
	{
        #region Fields
        public static string Databaselocation = string.Empty;
        #endregion

        public App ()
		{
			InitializeComponent();

			//MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaselocation)
        {
            //non default constructor
            InitializeComponent();
            //initialises the class object and then assigns the "databaselocation" string
            Databaselocation = databaselocation;
            //creates the mainpage from the PCL
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
