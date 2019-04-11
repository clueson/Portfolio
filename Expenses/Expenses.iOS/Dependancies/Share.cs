using System.Threading.Tasks;
using Expenses.Interfaces;
using Expenses.iOS.Dependancies;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace Expenses.iOS.Dependancies
{
    /// <summary>
    /// Sharing a file within IOS
    /// </summary>
    public class Share : IShare
    {
        public async Task Show(string theTitle, string theMessage, string theFilePath)
        {
            //gets the current viewcontroller type
            var viewController = GetVisibleViewController();
            //takes the 'theFilePath value and 'theTitle' and places both objects into an array (IOS type)
            var items = new NSObject[] { NSObject.FromObject(theTitle), NSUrl.FromFilename(theFilePath) };
            //shared view you see on IOS
            var activityController = new UIActivityViewController(items, null);

            //Tests to see if the view is a popover type? 
            if (activityController.PopoverPresentationController != null)
            {
                activityController.PopoverPresentationController.SourceView = viewController.View;
            }

            //returns the awaited task passing the view with the array
            await viewController.PresentViewControllerAsync(activityController, true);
        }

        private UIViewController GetVisibleViewController()
        {
            //Retreives the current view controller
            var rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            //Test for null obj in the Presented viewcontroller which may consist of a navigation page.
            if (rootViewController.PresentedViewController == null)
            {
                return rootViewController;
            }

            //Test to see if the controller is a viewcontroller and returns a navigation view controller
            if (rootViewController.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)rootViewController.PresentedViewController).TopViewController;
            }

            //Test to see if the viewcontroller is part of a tabbar
            if (rootViewController.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)rootViewController.PresentedViewController).SelectedViewController;
            }

            //returns if any of the above is not valid.
            return rootViewController.PresentedViewController;
        }
    }
}