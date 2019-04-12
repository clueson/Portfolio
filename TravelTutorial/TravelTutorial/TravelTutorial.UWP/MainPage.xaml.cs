using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TravelTutorial.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            //device specific code to load the database from a file in UWP
            string dbname = "travel_db.sqlite";
            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fullpath = Path.Combine(folderpath, dbname);

            //Xamarin forms map
            Xamarin.FormsMaps.Init();

            //LoadApplication(new TravelTutorial.App());
            LoadApplication(new TravelTutorial.App((fullpath)));
            
        }
    }
}
