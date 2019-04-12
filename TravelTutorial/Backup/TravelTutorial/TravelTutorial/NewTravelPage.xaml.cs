using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelTutorial.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using TravelTutorial.Logic;

namespace TravelTutorial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            //gets the user current location from the Geolocator obj
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            //uses the venuelogic class to build a list from the json source script
            var venues = await VenueLogic.GetVenuesAsync(position.Latitude, position.Longitude);

            //sets the itemsource to display the data in the listview control
            venuelistview.ItemsSource = venues;
        }

        #region Events
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //initialises the Post class and sets the property coluomn with the text from
            //the entry control on the Travel application xaml.
            Post post = new Post() { Experience = entExperience.Text };

            //intialises a SQl lite connection using the Appl class object static field
            using (SQLiteConnection conn = new SQLiteConnection(App.Databaselocation))
            {
                //automatically closes the connection

                //Creates a table inside of the database
                conn.CreateTable<Post>();

                //insert a row into the table
                int rowsinserted = conn.Insert(post);

                //quick check to see if any rows were inserted into the table
                if (rowsinserted > 0)
                {
                    DisplayAlert("Success", "Experience data inserted" + "rows inserted = " + rowsinserted, "OK");
                }
                else
                {
                    DisplayAlert("Failed", "Experience data not inserted", "OK");
                }
            }
        }
        #endregion
    }
}