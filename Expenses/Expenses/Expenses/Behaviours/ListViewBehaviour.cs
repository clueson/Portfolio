using Expenses.Models;
using Expenses.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Expenses.Behaviours
{
    /// <summary>
    /// Defines an attached behaviour to activate an event on any listview object
    /// </summary>
    class ListViewBehaviour : Behavior<ListView>
    {
        #region Fields
        ListView listview;
        #endregion

        #region Class Methods
        protected override void OnAttachedTo(ListView bindable)
        {
            //uses the onattached to a listview obj
            base.OnAttachedTo(bindable);
            listview = bindable;
            listview.ItemSelected += ListView_ItemSelected;
        }

        #endregion

        #region Event Handling
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //conditions the type to an expense object
            Expense selectedExpense = listview.SelectedItem as Expense;
            //opens the ExpenseDetailsPage passing the selected expense obj
            Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailsPage(selectedExpense));
        }
        protected override void OnDetachingFrom(ListView bindable)
        {
            //removes the event from the invocation list
            base.OnDetachingFrom(bindable);
            listview.ItemSelected -= ListView_ItemSelected;
        }
        #endregion
    }
}
