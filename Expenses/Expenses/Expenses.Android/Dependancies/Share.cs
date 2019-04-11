using System.Threading.Tasks;
using Android.Content;
using Android.Support.V4.Content;
using Expenses.Droid.Dependancies;
using Expenses.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace Expenses.Droid.Dependancies
{
    class Share : IShare
    {
        //[Java.Lang.Deprecated]
        ///// <summary>
        ///// Sharing a file in Android
        ///// </summary>
        ///// <param name="theTitle"></param>
        ///// <param name="theMessage"></param>
        ///// <param name="theFilePath"></param>
        ///// <returns></returns>
        //public Task Show(string theTitle, string theMessage, string theFilePath)
        //{
        //    /* Sharing files from ths shared project on each platform */

        //    //Make sure in the android manifest to set the permissions to the following properties
        //    //Read_External_Storage, Write_External_Storage
        //    //make sure in the android manifest file in the properties folder
        //    //to create an xml element inside of the application tags = 
        //    //<provider android:name="android.support.v4.content.Fileprovider" android:authorities="com.companyname.ExpensesApp.provider" android:exported ="false" android:grantUriPermissions="true">
        //    //< meta - data android: name = "android.support.FILE_PROVIDE_PATHS" android.resource = "@xml/file_provider_paths" ></ meta - data >
        //    //</ provider >
        //    //So that the file provider and permissions are set properly
        //    //Also create an xml blank file under resource/xml folder called xml/file_provider_paths.xml


        //    //In android an Activity communicates via intents, creates
        //    var intent = new Intent(Intent.ActionSend);
        //    //sets the type of file that being sent with the intent
        //    intent.SetType("text/plain");
        //    //context is handled by xamarin forms
        //    //to create a file path for the document to be loaded
        //    //with the correct permissions

        //    //gets the context and the filepath
        //    var documentUri = FileProvider.GetUriForFile(Android.App.Application.Context.ApplicationContext,
        //        "com.companyname.ExpensesApp.fileprovider", new Java.IO.File(theFilePath));

        //    //sets up the bundle to be sent inside of the intent.
        //    intent.PutExtra(Intent.ExtraStream, documentUri);
        //    intent.PutExtra(Intent.ExtraText, theTitle);
        //    intent.PutExtra(Intent.ExtraSubject, theMessage);

        //    //Creates the View using a chooser obj chooses where to save the files
        //    var chooserIntent = Intent.CreateChooser(intent, theTitle);
        //    //setting the properties of the intent
        //    chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission);
        //    //starts the activity
        //    Android.App.Application.Context.StartActivity(chooserIntent);
        //    //since this is not a async method we have to return something (a task).
        //    return Task.FromResult(true);
        //}

        /// <summary>
        /// Sharing data in Android
        /// </summary>
        /// <param name="theTitle"></param>
        /// <param name="theMessage"></param>
        /// <param name="theFilePath"></param>
        /// <returns></returns>
        public Task Show(string theTitle, string theMessage, string theFilePath)
        {
            /* Sharing files from ths shared project on each platform 
             modified because the fileprovider did not work for some reason*/

            //In android an Activity communicates via intents, creates
            var intent = new Intent(Intent.ActionSend);
            //sets the type of file that being sent with the intent
            intent.SetType("text/plain");
            //context is handled by xamarin forms
            //to create a file path for the document to be loaded
            //with the correct permissions

            //gets the context and the filepath from the local device
            var documentUri = FileProvider.GetUriForFile(Android.App.Application.Context.ApplicationContext,
                "com.companyname.Expenses.provider", new Java.IO.File(theFilePath));

            //sets up the bundle to be sent inside of the intent.
            //Also sets up the file content, a title, and the message
            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraText, theTitle);
            intent.PutExtra(Intent.ExtraSubject, theMessage);

            //Creates the View using a chooser obj chooses where to save the files
            var chooserIntent = Intent.CreateChooser(intent, theTitle);
            //setting the properties of the intent for granting permissions
            chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission);
            //starts the activity opens a file chooser object
            Android.App.Application.Context.StartActivity(chooserIntent);
            //since this is not a async method we have to return something (a task).
            return Task.FromResult(true);
        }

        #region OldeCode
        private void Oldcode()
        {
            //string[] theData = new string[50];
            //int counter = 0;
            //string line = string.Empty;
            //try
            //{
            //    using (StreamReader reader = new StreamReader(theFilePath))
            //    {
            //        if (reader != null)
            //        {
            //            while ((line = reader.ReadLine()) != null)
            //            {
            //                theData[counter] = line;
            //                counter++;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string errormessage = ex.Message;
            //}
        }
        #endregion
    }
}