using Expenses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expenses.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewExpensePage : ContentPage
	{
        #region Fields
        NewExpensesVm ViewModel;
        #endregion

        public NewExpensePage ()
		{
			InitializeComponent ();
            //Assigns the ViewModel obj as a VM class (to access all it members)
            ViewModel = Resources["vm"] as NewExpensesVm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetExpenseStatus();

            //counter variable for the collection
            int counter = 0;

            //creates a switchcell obj
            var cell = new SwitchCell();

            //iterates all of the state objes and then assigns a binding to each iteration
            foreach (var item in ViewModel.ExpensesStates)
            {
                //Assigns the 'text' property
                //to the observable collection 'Name' property 
                cell = new SwitchCell() { Text = item.Name };

                //creates a binding object
                Binding bindingSWcell = new Binding();

                //Assigns the binding and fills the properties
                bindingSWcell.Source = ViewModel.ExpensesStates[counter]; //the source of the data in the cell
                bindingSWcell.Path = "Status"; // what the cell binds to in xaml
                bindingSWcell.Mode = BindingMode.TwoWay; //creates a two way data binding

                //Adds the binding to the cell obj 
                cell.SetBinding(SwitchCell.OnProperty, bindingSWcell);
                //changes the height?
                cell.Height = 25d;
                //adds the bindable object (cell) to the section object
                //-->var section = new TableSection() { cell };
                var section = new TableSection() { cell };
                //section.Add(cell);

                //adds the cell with its binding to the element in the view
                tbvDisplayExpenses.Root.Add(section);

                //increments the count before the next iteration
                counter++;
            }


        }
    }
}