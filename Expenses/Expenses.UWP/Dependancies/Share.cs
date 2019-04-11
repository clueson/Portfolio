using Expenses.Interfaces;
using Expenses.UWP.Dependancies;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Xamarin.Forms;
using System;

[assembly: Dependency(typeof(Share))]
namespace Expenses.UWP.Dependancies
{
    /// <summary>
    /// Shares a file with UWP/Windows applications
    /// </summary>
    public class Share : IShare
    {
        public async Task Show(string theTitle, string theMessage, string theFilePath)
        {
            //to do for UWP
            //as we are not awaiting we have to return something

            //Possible logic is
            // 1.Get the documents folder
            // 2.Create a new file
            // 3.Use a reader to get the contents of the file
            // 4.Write the data into the a variable
            // 5.Create a fileSavePicker to then save the variable to a location specified by the user.
            // 6.Create and alert ot tell the user the file was saved.

            StorageFolder theFolder = ApplicationData.Current.LocalFolder;

            //skips if the file exists in the current folder
            if (!File.Exists("report.txt"))
            {
                StorageFile newFile = await theFolder.CreateFileAsync("report.txt");
            }

            //gets the file
            StorageFile sampleFile = await theFolder.GetFileAsync("report.txt");

            string theText = string.Empty;

            //reads the contents of the file and then write to a new file
            using (var fileData = new StreamReader(theFilePath))
            {
                //checks to see if the file is null
                if (fileData!=null)
                {
                    //checks for the end of file
                    while (!fileData.EndOfStream)
                    {
                        //updates the string variable
                        theText += fileData.ReadLine();
                    }
                }
                //writes to the file
                await FileIO.WriteTextAsync(sampleFile, theText);
            };

            //return Task.FromResult(true);
            var theTask = Task.FromResult(true);
            return;
        }

        private class OldeCode
        {
            #region Using the file picker
            private void FilePicker()
            {
                Picker thePickerView = new Picker();

                FileSavePicker pickerSave = new FileSavePicker();

                IList<string> fileTypes = new List<string>();
                fileTypes.Add(".txt");
                fileTypes.Add(".doc");

                pickerSave.SuggestedFileName = "anything";
                pickerSave.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                pickerSave.FileTypeChoices.Add("text", fileTypes);
            }
            #endregion
        }
    }

}
