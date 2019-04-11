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

namespace Expenses.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            //defines and creates the location of the local database file
            string dbName = "expenses_db.db3";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fullPath = Path.Combine(folderPath, dbName);

            //LoadApplication(new Expenses.App());
            ////Another way to register dependancies is to 
            ////register them here 
            //DependencyService.Register<Share>();
            //starts the new mainpage

            LoadApplication(new Expenses.App(fullPath));
        }
    }
}
