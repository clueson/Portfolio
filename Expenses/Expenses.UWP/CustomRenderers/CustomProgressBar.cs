using Expenses.UWP.CustomRenderers;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms;
using Windows.UI.Xaml.Media;
using Windows.UI;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBar))]
namespace Expenses.UWP.CustomRenderers
{
    public class CustomProgressBar : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            //Fault detected where there are no catagories with no money values! upon first time construction
            //The "e" value of the progress property has a NaN value, the base class rejects the value?
            //the progress property remains as NaN, in Android does not seem to effect it.
            //The control will be rendered x times the number of catagory names, application then starts

            //base class instantiation
            base.OnElementChanged(e);

            Control.Background = new SolidColorBrush(Colors.LightGray);

            if (double.IsNaN(e.NewElement.Progress))
            {
                //sets the foreground property
                Control.Foreground = new SolidColorBrush(Colors.LightGreen);
            }
            else if (e.NewElement.Progress < 0.3)
            {
                Control.Foreground = new SolidColorBrush(Colors.LightSeaGreen); ;
            }
            else if (e.NewElement.Progress < 0.5)
            {
                Control.Foreground = new SolidColorBrush(Colors.SeaGreen);
            }
            else if (e.NewElement.Progress < 0.7)
            {
                Control.Foreground = new SolidColorBrush(Colors.DarkSeaGreen);
            }
            else if (e.NewElement.Progress < 0.9)
            {
                Control.Foreground = new SolidColorBrush(Colors.DarkGreen);
            }
            else
            {
                Control.Foreground = new SolidColorBrush(Colors.Red);
            }

            Control.Height = 5;
        }
    }
}
