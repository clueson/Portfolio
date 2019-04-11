using Expenses.Interfaces;
using Expenses.Models;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Expenses.ViewModels
{
    public class CatagoriesVm
    {
        #region Events
        //public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        //private ObservableCollection<CatagoryExpenses> _catagoryExpensesCollection;
        #endregion

        #region Properties
        /// <summary>
        /// Binds to the xaml obj
        /// </summary>
        public ObservableCollection<string> Catagories { get; set; }

        /// <summary>
        /// Binds to the xaml obj
        /// </summary>
        public ObservableCollection<CatagoryExpenses> CatagoryExpensesCollection
        {
            get;
            set;
        }

        /// <summary>
        /// Runs a command to Generate a report
        /// </summary>
        public Command ExportCommand { get; set; }
        #endregion

        #region Constructor
        public CatagoriesVm()
        {
            //intialises the collections
            CatagoryExpensesCollection = new ObservableCollection<CatagoryExpenses>();
            Catagories = new ObservableCollection<string>();
            //Intialises the Command and assigns a target method
            ExportCommand = new Command(ShareReport);
            //moves to the method to populate the data
            GetCatagories();
            //moves to the method to calculate
            //the % of expenses per catagory
            GetExpensesPerCatagory();
        }

        #endregion

        #region Class Methods
        /// <summary>
        /// Extracts the Catagories from the collection
        /// </summary>
        private void GetCatagories()
        {
            Catagories.Clear();
            //adds the data to the collection
            Catagories.Add("Housing");
            Catagories.Add("Debt");
            Catagories.Add("Health");
            Catagories.Add("Food");
            Catagories.Add("Personal");
            Catagories.Add("Travel");
            Catagories.Add("Work Related");
            Catagories.Add("Other");
        }

        /// <summary>
        /// Populates the CatagoryExpensesCollection
        /// </summary>
        private void GetExpensesPerCatagory()
        {
            //clears the collection every time this method is called
            CatagoryExpensesCollection.Clear();
            //gets the total amount per catagory
            float totalExpensesAmount = Expense.TotalExpensesAmount();
            //iterates the collection to extract the amount property in the database
            foreach (string item in Catagories)
            {
                //Gets the sum of each catories Amount
                var expenses = Expense.GetExpenses(item);
                float expenseAmountInCatagory = expenses.Sum(e => e.Amount);

                //Places the Sum and Catogory name from the class
                CatagoryExpenses ce = new CatagoryExpenses()
                {
                    //assigns the properties
                    Catagory = item,
                    ExpensesPercentage = expenseAmountInCatagory / totalExpensesAmount
                };

                //returns the object which adds to the collection
                CatagoryExpensesCollection.Add(ce);
            }
        }

        /// <summary>
        /// Public access to the GetExpensesPerCatagory Method
        /// </summary>
        public void GetThePercentPerCat()
        {
            GetExpensesPerCatagory();
        }

        /// <summary>
        ///Creates Expenses report and saves the file locally
        /// </summary>
        public async void ShareReport()
        {
            //gets the file location on each platform and sets the rootfolder on each platform.
            IFileSystem filesystem = FileSystem.Current;
            IFolder rootFolder = filesystem.LocalStorage;
            //creates a rootfolder in each platform.
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.ReplaceExisting);

            //creates a empty file
            var txtFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

            //writes the data from the Collection into the file to be shared
            using (StreamWriter sw = new StreamWriter(txtFile.Path))
            {
                //iterates the collection
                foreach (var item in CatagoryExpensesCollection)
                {
                    //adds the values from the properties into the streamwriter using the new stg formatter
                    sw.WriteLine($"{ item.Catagory} - { item.ExpensesPercentage:p}");
                }
            }

            //creates an intance of the interface for the specific classes from the dependancy service.
            var shareDependancy = DependencyService.Get<IShare>();

            //calls the show method to show file selection dialog box.
            await shareDependancy.Show("Expense report", "Here is your expense report", txtFile.Path);
        }
        #endregion

        #region Nested class CatagoryExpenses
        //A bindable class object for the catagories page in xaml
        public class CatagoryExpenses
        {
            public string Catagory { get; set; }

            public double ExpensesPercentage { get; set; }
        }
        #endregion

        #region OldCode
        //public CatagoriesVm()
        //{
        //    if (Catagories == null)
        //    {
        //        Catagories = new ObservableCollection<string>();
        //    }
        //}
        #endregion

        #region Implemented INotifyPropertyChanged
        //private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        //{
        //    //updates the property specified in this class
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        #endregion

    }
}
