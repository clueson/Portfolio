using CoreGraphics;
using Expenses.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBar))]
namespace Expenses.iOS.CustomRenderers
{
    public class CustomProgressBar : ProgressBarRenderer
    {
        //Custom renderer that applies a new render to the Progress Bar object

        //alters the subview
        public override void LayoutSubviews()
        {
            //this method is only called once on startup or through the class
            base.LayoutSubviews();

            float x = 1.0f;
            float y = 4.0f;

            //scaling the progress bar accepts the two float values
            CGAffineTransform transform = CGAffineTransform.MakeScale(x, y);
            Transform = transform;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            //this method will be called everytime the element changes
            base.OnElementChanged(e);

            //Alters the tint colour of the Progress bar by
            //determining what percentage tint to apply to the control
            if (double.IsNaN(e.NewElement.Progress))
            {
                //sets the tint colour
                Control.ProgressTintColor = Color.FromHex("#00B9AE").ToUIColor();
            }
            else if (e.NewElement.Progress < 0.3)
            {
                Control.ProgressTintColor = Color.FromHex("#008DD5").ToUIColor();
            }
            else if (e.NewElement.Progress < 0.6)
            {
                Control.ProgressTintColor = Color.FromHex("#2D76BA").ToUIColor();
            }
            else if (e.NewElement.Progress < 0.9)
            {
                Control.ProgressTintColor = Color.FromHex("#5A5F9F").ToUIColor();
            }
            else
            {
                Control.ProgressTintColor = Color.FromHex("#B3316A").ToUIColor();
            }

            LayoutSubviews();
        }
    }
}