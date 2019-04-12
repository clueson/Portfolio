using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelTutorial.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelTutorial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            //overridden method comes from the page, 
            //every time the page is accessed this method is executed.
            //reading from the database in the history page

            //loads the base implementation
            base.OnAppearing();

            //establishes a connection object for the history page
            using (SQLiteConnection conn = new SQLiteConnection(App.Databaselocation))
            {
                //using automatically calls dispose instead
                //of manaully calling close on the conn object

                //creates a table or skips if exists
                conn.CreateTable<Post>();

                //creates a list from the table
                var posts = conn.Table<Post>().ToList();
                postListView.ItemsSource = posts;
            }
        }
    }
}