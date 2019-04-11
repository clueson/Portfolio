using Expenses.Models;
using Expenses.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Expenses.ViewModels
{
    public class ExpensesVm
    {
        #region Properties
        /// <summary>
        /// Binds a xaml list obj to the property
        /// </summary>
        public ObservableCollection<Expense> Expenses { get; set; }

        /// <summary>
        /// Binds the xaml to a Command property
        /// </summary>
        public Command AddExpenseCommand
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public ExpensesVm()
        {
            //intialises the collection
            Expenses = new ObservableCollection<Expense>();
            //initialises the command and assigns a target method
            AddExpenseCommand = new Command(AddExpense);
            //Moves to the method to populate the collection
            GetExpenses();
        }
        #endregion

        #region Class Methods
        /// <summary>
        /// Internal to class only, gets the data from the database
        /// </summary>
        private void GetExpenses()
        {
            //Assertion that the binding would be lost?
            //if the data from the database is directly sourced
            //from the database class method, if the method changed/deleted/modified
            //maybe better to use an interface instead?

            //clears the collection
            Expenses.Clear();
            //gets the list of expenses from the database
            var expenses = Expense.GetExpenses();
            //iterates the values in the list from the database
            foreach (var thexpense in expenses)
            {
                Expenses.Add(thexpense);
            }
        }

        /// <summary>
        /// Allows public access to the Method
        /// </summary>
        public void GetTheExpenses()
        {
            GetExpenses();
        }

        /// <summary>
        /// Receives a command and navigates to the xaml NewExpensePage
        /// </summary>
        public void AddExpense()
        {
            //test method to demonstrate the the dependancy works
            //calls the Method to create and inject dependancy objects
            //ShareReport();

            //receives a command from the view to navigate to a page
            //using the Application class (Mainpage inherits from application)
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }

        #endregion
    }
}
