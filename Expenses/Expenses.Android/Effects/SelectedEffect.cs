using System;
using System.ComponentModel;
using Android.Graphics.Drawables;
using Expenses.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("LPA")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace Expenses.Droid.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        //the assembly attribute resolves the effects name to this class?
        //the effect is exported to the control using the effects identifier.

        #region Fields
        Android.Graphics.Color selectedColour;
        #endregion

        #region Asbract class members from PlatformEffect class
        protected override void OnAttached()
        {
            //selects the colour for the effect
            selectedColour = new Android.Graphics.Color(200, 157, 224);
        }

        protected override void OnDetached()
        {
            ;
        }

        /// <summary>
        /// Event handler for the property changed event
        /// </summary>
        /// <param name="args"></param>
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            //in the tutorial his selection background colour did not change
            //but mine does! there is still a fault, the last selection does not revert back to
            //the default background unless its clicked outside of the selection.

            //detects a change to the control
            base.OnElementPropertyChanged(args);
            //Checks to see if the control is a focus control
            if (args.PropertyName == "IsFocused")
            {
                //if the control is in focus
                if (Control.IsFocused)
                {
                    //then set the background colour to the filed setting
                    Control.SetBackgroundColor(selectedColour);
                }
                else
                {
                    //if not focused set it the default colour.
                    Control.SetBackgroundColor(Android.Graphics.Color.Wheat);
                }
            }
        }
        #endregion

        #region Alternate Code for OnElementPropertyChanged method to catch an exception on a failed cast
        private void AlternateCode(PropertyChangedEventArgs args)
        {
            //wrapped in try/catch block
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    //detecting if the colour is not the new colour!
                    if (((ColorDrawable)Control.Background).Color != selectedColour)
                    {
                        Control.SetBackgroundColor(selectedColour);
                    }
                    else
                    {
                        //if not focused set it the default colour.
                        Control.SetBackgroundColor(Android.Graphics.Color.Wheat);
                    }
                }
            }
            catch (InvalidCastException)
            {
                Control.SetBackgroundColor(selectedColour);
            }


        }
        #endregion
    }
}