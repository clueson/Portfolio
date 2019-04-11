using Expenses.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Expenses.ViewModels
{
    public class NewExpensesVm : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        private string _expenseName;
        private string _expenseDescription;
        private int _expenseAmount;
        private DateTime _expenseDate;
        private string _expenseCatagory;
        #endregion

        #region Properties
        /// <summary>
        /// Binding property for the xaml view
        /// </summary>
        public string ExpenseName
        {
            get { return _expenseName; }
            set { _expenseName = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Binding property for the xaml view
        /// </summary>
        public string ExpenseDescription
        {
            get { return _expenseDescription; }
            set { _expenseDescription = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Binding property for the xaml view
        /// </summary>
        public int ExpenseAmount
        {
            get { return _expenseAmount; }
            set { _expenseAmount = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Binding property for the xaml view
        /// </summary>
        public DateTime ExpenseDate
        {
            get { return _expenseDate; }
            set { _expenseDate = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Binding property for the xaml view
        /// </summary>
        public string ExpenseCatagory
        {
            get { return _expenseCatagory; }
            set { _expenseCatagory = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Binds the Save xaml control to a command
        /// </summary>
        public Command SaveExpenseCommand { get; set; }

        /// <summary>
        /// Extracts the catagories to the bound xaml control
        /// </summary>
        public ObservableCollection<string> Catagories { get; set; }

        /// <summary>
        /// Binds to the xaml form of a collection of status objects
        /// </summary>
        public ObservableCollection<ExpensesStatus> ExpensesStates { get; set; }
        #endregion

        #region Constructor
        public NewExpensesVm()
        {
            //upon intialisation the current date is set in the porperty
            ExpenseDate = DateTime.Today;
            //assigns the command delegate with the target method
            SaveExpenseCommand = new Command(InsertExpense);
            //Initialises the collections
            Catagories = new ObservableCollection<string>();
            ExpensesStates = new ObservableCollection<ExpensesStatus>();
            //Populates the collection
            GetCatagories();

        }
        #endregion

        #region class Methods
        /// <summary>
        /// Assigns the binding property values on the xaml form to the Expense class database properties
        /// </summary>
        public void InsertExpense()
        {
            //assigns a vm varaible for runtime inspection
            //-->var vm = this;

            //creates a new expense object and assigns the properties
            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Description = ExpenseDescription,
                Amount = ExpenseAmount,
                Date = ExpenseDate,
                Catagory = ExpenseCatagory
            };

            //gets the number of affected rows
            int response = Expense.InsertExpense(expense);
            //checks that the rows affected is more than 1
            if (response > 0)//uses the response variable
            {
                //navigates back the the top level page
                Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "No items inserted", "Ok");
            }
        }

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
        /// Populates the Collection ExpensesStates
        /// </summary>
        public void GetExpenseStatus()
        {
            //clears the collection
            ExpensesStates.Clear();

            //adds objects to the collection
            ExpensesStates.Add(new ExpensesStatus { Name = "Random", Status = true });
            ExpensesStates.Add(new ExpensesStatus { Name = "Random 1", Status = true });
            ExpensesStates.Add(new ExpensesStatus { Name = "Random 2", Status = false });
        }
        #endregion

        #region INotifyPropertyChanged implementation
        /// <summary>
        /// Binding property update event
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //updates the xaml binding when a property changes
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region ExpensesStatus Class
        public class ExpensesStatus
        {
            //the tableview xaml control does not have an items source property
            //or a source property to bind to
            //So we have to create a way of binding to the tableview xaml object
            //We need to create a bindable object in c# to bind to the tableview manually

            #region Properties
            public string Name { get; set; }
            public bool Status { get; set; }
            #endregion
        }
        #endregion
    }
}
