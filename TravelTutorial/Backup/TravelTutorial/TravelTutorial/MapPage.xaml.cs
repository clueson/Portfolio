using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelTutorial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
		}

        #region Methods

        /// <summary>
        /// to make the app more responsive to the user
        /// from nuget, load the xamarin forms goelocator plugin.
        /// uses the overidden "OnAppearing()" method to repaint the map
        /// when it changes location
        /// </summary>

        protected async override void OnAppearing()
        {
            //Onappearing reloads everytime the page is accessed
            //since one of the statements is awaitable the method 
            //should be async

            //uses the base class to intiialise the object
            base.OnAppearing();

            //using the geolocator plugin class to assign a geolocator obj
            var myLocater = CrossGeolocator.Current;

            //event handler for the location change event
            myLocater.PositionChanged += MyLocater_PositionChanged;

            //assigns a timespan variable
            TimeSpan intervaltime = new TimeSpan(0, 0, 0);

            //listens for a change of location sets the time
            //interval for the "positionchanged" event to be fired
            //and the minimum distance of 100m, awaitable task.
            await myLocater.StartListeningAsync(intervaltime, 100);

            //assign the geolocation value to a variable
            var position = await myLocater.GetPositionAsync();

            //moves to the region map place define by the location
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            LocationsMaps.MoveToRegion(span);
        }
        private void MyLocater_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            //moves to the region. map place defined by your location
            LocationsMaps.MoveToRegion(new Xamarin.Forms.Maps.MapSpan
                (new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude), 2, 2));
        }
        #endregion
    }
}