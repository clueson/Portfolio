using Expenses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Expenses.ViewModels
{
    public class ExpenseDetailsVM : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        private Expense expense;
        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets the related expense class properties
        /// </summary>
        public Expense Expense
        {
            get { return expense; }
            set
            {
                expense = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public ExpenseDetailsVM()
        {
            //default constructor
        }
        #endregion

        #region INotifyPropertyChanged implementaion
        private void OnPropertyChanged([CallerMemberName] string theProperty = null)
        {
            //invokes the property after checking the event is not null and updates the xaml properties
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(theProperty));
        }
        #endregion
    }
}
