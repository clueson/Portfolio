using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelTutorial
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        #region Fields
        private Color whitecolour = Color.White;
        private Color yellowcolour = Color.Yellow;
        private Color redcolour = Color.Red;
        #endregion

        #region Events
        private void Login_clicked(Object sender, EventArgs e)
        {
            CheckForEmptyFields();
        }
        #endregion

        #region Methods
        private void CheckForEmptyFields()
        {
            bool emailempty = string.IsNullOrWhiteSpace(entEmailAddress.Text);
            bool passwordempty = string.IsNullOrWhiteSpace(entPassword.Text);

            if (emailempty && passwordempty)
            {
                BothFieldsEmpty();
            }
            else if (emailempty)
            {
                //uses the nameof keyword to extract the "name" property, then moves to the method
                OneFieldEmpty(nameof(entEmailAddress));
                //-->Color thecolval = entEmailAddress.BackgroundColor.Equals(BackgroundColorProperty) ? entPassword.BackgroundColor = Color.White  
                //-->: entEmailAddress.BackgroundColor = Color.Yellow;
            }
            else if (passwordempty)
            {
                //uses the nameof keyword to extract the "name" property, then moves to the method
                OneFieldEmpty(nameof(entPassword));
                //-->Color thecolval = entPassword.BackgroundColor.Equals(BackgroundColorProperty) ? entEmailAddress.BackgroundColor = Color.White
                //--> :entPassword.BackgroundColor = Color.Yellow;
            }
            else
            {
                //moves to the method
                BothFieldsWithVal();
                //starts a navigation object and points to a new page
                Navigation.PushAsync(new HomePage());

            }
        }

        private void BothFieldsEmpty()
        {
            //sets the label properties and unhides the control
            lblError.IsVisible = true;
            lblError.BackgroundColor = Color.Yellow;
            lblError.Text = "one or more boxes are not completed!";

            //highlights the affected fields
            entEmailAddress.BackgroundColor = Color.Yellow;
            entPassword.BackgroundColor = Color.Yellow;

            //moves the focus
            entEmailAddress.Focus();
        }

        private void OneFieldEmpty(string thefield)
        {
            switch (thefield)
            {
                case "entEmailAddress":
                    {
                        entEmailAddress.BackgroundColor = Color.Yellow;
                        entPassword.BackgroundColor = Color.White;
                        entEmailAddress.Focus();
                        break;
                    }
                case "entPassword":
                    {
                        entPassword.BackgroundColor = Color.Yellow;
                        entEmailAddress.BackgroundColor = Color.White;
                        entPassword.Focus();
                        break;
                    }
                default: { break; }
            }
        }

        private void BothFieldsWithVal()
        {
            lblError.IsVisible = false;
            entEmailAddress.BackgroundColor = Color.White;
            entPassword.BackgroundColor = Color.White;
        }

        private Color SetBackGroundColor(bool emptyistrueorfalse, string thefieldname)
        {
            //prototype method for better reusability
            if (emptyistrueorfalse)
            {
                return yellowcolour;
            }
            else if (!emptyistrueorfalse)
            {
                return whitecolour;
            }
            else
            {
                string error = "no boolean condition found for an unknown colour";
                DisplayAlert("User Field Problem", error, "cancel");
                return whitecolour;
            }
        }
        #endregion

        #region OldCode
        private void OldCode()
        {

            if (string.IsNullOrWhiteSpace(entEmailAddress.Text))//type is of bool
            {
                //type is of colour
                entEmailAddress.BackgroundColor = Color.Yellow;
            }
            else
            {
                entEmailAddress.BackgroundColor = Color.White;
            }

            //ternary expression
            bool isemptyornot = string.IsNullOrWhiteSpace(entEmailAddress.Text) ? true : false;
            bool emptyistrueorfalse = true;
            Color thecolval = entEmailAddress.BackgroundColor.Equals(emptyistrueorfalse) ? entEmailAddress.BackgroundColor = Color.Yellow
                : entEmailAddress.BackgroundColor = Color.White;

            int x = 4 > 5 ? x : x = +5;

        }
        #endregion
    }
}
