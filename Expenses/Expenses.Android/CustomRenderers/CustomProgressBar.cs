using Android.Content;
using Expenses.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBar))]
namespace Expenses.Droid.CustomRenderers
{
    public class CustomProgressBar : ProgressBarRenderer
    {
        //custom renderer for android.

        public CustomProgressBar(Context context) : base(context)
        {
            //default constructor when the class inherits from ProgressBarRenderer in android

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (double.IsNaN(e.NewElement.Progress))
            {
                Control.ProgressDrawable.SetTint(Color.FromHex("#00B9AE").ToAndroid());
            }
            else if (e.NewElement.Progress < 0.3)
            {
                Control.ProgressDrawable.SetTint(Color.FromHex("#008DD5").ToAndroid());
            }
            else if (e.NewElement.Progress < 0.6)
            {
                Control.ProgressDrawable.SetTint(Color.FromHex("#2D76BA").ToAndroid());
            }
            else if (e.NewElement.Progress < 0.9)
            {
                Control.ProgressDrawable.SetTint(Color.FromHex("#5A5F9F").ToAndroid());
            }
            else
            {
                Control.ProgressDrawable.SetTint(Color.FromHex("#B3316A").ToAndroid());
            }

            Control.ScaleX = 1f;
            Control.ScaleY = 3f;
        }
    }
}