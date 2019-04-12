using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace TravelTutorial.Droid
{
    [Activity(Label = "TravelTutorial", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //initalises the maps, and device specific location
            //change permissions in the android manifest
            //to access the map properties
            //google maps api key is required to access the google map properties.
            //the credential key for the api must be put into the AndroidManifest.xml file
            //https://console.developers.google.com/apis/credentials?project=xamarintutorial-204521
            //android assett studio has images of icons to use in the amdroid applications.

            Xamarin.FormsMaps.Init(this, bundle);

            //device specific code to load the database from a file in android
            string dbname = "travel_db.sqlite";
            string folderpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(folderpath, dbname);

            //passes the database to a new instance of the PCL constructor
            //LoadApplication(new App());
            LoadApplication(new App(fullpath));

        }
    }
}