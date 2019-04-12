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
    public partial class HomePage : TabbedPage
    {
        public HomePage ()
        {
            InitializeComponent();
        }

        #region Events
        private void ToolBarItem_Clicked(object sender, EventArgs e)
        {
            //event from menu toolbar
            //uses the navigation "PushAsync" methods to load a new page
            Navigation.PushAsync(new NewTravelPage());
        }
        private void ToolBarClosed_Clicked(object sender, EventArgs e)
        {
            // does not execute? Application.Current.Quit();
            DisplayAlert("Exit application", "Do you want to close", "enter");
        }
        #endregion
    }
}