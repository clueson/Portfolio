using System.ComponentModel;
using Expenses.UWP.Effects;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("LPA")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace Expenses.UWP.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        #region fields
        SolidColorBrush theBackgroundColour;
        #endregion

        #region Constructor
        public SelectedEffect()
        {

        }
        
        #endregion

        #region abstract class members from PlatformEffects class
        protected override void OnAttached()
        {
            //sets the backgound colour
           theBackgroundColour = new SolidColorBrush(Colors.Salmon);
        }

        protected override void OnDetached()
        {
            ;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if(args.PropertyName == "IsFocused")
            {
                //using reflection which is too heavy!
                //Control.Parent.GetType().GetProperty("Background").SetValue(Control.Parent, theBackgroundColour);

                //Casting the Control to a Windows.UI.Controls object to extract the background
                Control thepicker = (Control)Control;
                //sets the selection background (not the parent)
                thepicker.Background = theBackgroundColour;
            }
            else
            {
                //default colour.
                Control thepicker = (Control)Control;
                thepicker.Background = new SolidColorBrush(Colors.Beige) ;
            }
            
        }
        
        #endregion
    }
}
