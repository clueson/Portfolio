﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using UIKit;

namespace Expenses.iOS
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
            //--> old codeLoadApplication(new App());

            //defines and creates the location of the local database file
            string dbName = "expenses_db.db3";
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".", "Library");
            string fullPath = Path.Combine(folderPath, dbName);

            ////Another way to register dependancies is to 
            ////register them here 
            //DependencyService.Register<Share>();

            //uses the second overload to pass a parameter to the native local/app
            LoadApplication(new App(fullPath));

            return base.FinishedLaunching(app, options);
        }
    }
}