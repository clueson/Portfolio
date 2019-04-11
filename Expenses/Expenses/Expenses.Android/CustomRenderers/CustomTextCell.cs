using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Expenses.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCell))]
namespace Expenses.Droid.CustomRenderers
{
    /// <summary>
    /// Receives the TextCell object and alters it style
    /// CustomTextCell obj receives a text parameter from the styleId property in Xaml
    /// Which identifyies which type of accessory button is requested.
    /// The button will be diplayed on the extreme right of the
    /// TextCell object.
    /// The TextCell obj is then exported back into the Xaml control
    /// of a specific type where it originated from.
    /// </summary>
    public class CustomTextCell : TextCellRenderer
    {
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            //Calls the base class to instatiate and configure the renderer
            var thecell = base.GetCellCore(item, convertView, parent, context);

            //extracts the passed in parameter from the StyleId property and sets the background of the cell
            switch (item.StyleId)
            {
                case "none": thecell.SetBackgroundColor(Android.Graphics.Color.LightGray); break;
                case "checkmark": thecell.SetBackgroundColor(Android.Graphics.Color.LightSteelBlue); break;
                case "detail-button": thecell.SetBackgroundColor(Android.Graphics.Color.LightSlateGray); break;
                case "disclosure": thecell.SetBackgroundColor(Android.Graphics.Color.LightSkyBlue); break;
                default:
                    break;
            }

            //returns the TextCell object to caller
            return thecell;
        }
    }
}