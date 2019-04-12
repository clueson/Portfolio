using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace TravelTutorial.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            //initialises the map class, 
            //dont forget to edit the info.plist file to alert the user 
            //to allow the location of the device to be used.
            //to modify the alert regarding location tracking 
            //on the device.

            //icon8.com for IOS icons packs hve been added to the resources folder

            //creates a formsmap obj.
            Xamarin.FormsMaps.Init();

            //device specific code to load the database from a file
            string dbname = "travel_db.sqlite";

            //for IOS the folder used to store the file will be stored in the "Library" folder using PATH.Combine
            string folderpath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
            string fullpath = Path.Combine(folderpath, dbname);

            //uses the default constructor of the APP class to initialise the PCL

            //LoadApplication(new App());
            LoadApplication(new App(fullpath));

            return base.FinishedLaunching(app, options);
        }
    }
}
