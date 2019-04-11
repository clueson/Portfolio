using System.ComponentModel;
using Expenses.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("LPA")]
[assembly: ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace Expenses.iOS.Effects
{
    public class SelectedEffect : PlatformEffect
    {
        UIColor selectColour;

        #region implemented mebers from abstract class PlatformEffect
        protected override void OnAttached()
        {
            selectColour = new UIColor(200/255, 157/255, 224/255, 255/255);
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
                if(Control.BackgroundColor != selectColour)
                {
                    Control.BackgroundColor = selectColour;
                }
                else
                {
                    Control.BackgroundColor = UIColor.White;
                }
            }
        }
        #endregion
    }
}