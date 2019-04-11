using Expenses.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExpensesPage : ContentPage
	{
        #region Fields
        ExpensesVm ViewModel;
        #endregion

        public ExpensesPage ()
		{
			InitializeComponent ();
            ViewModel = Resources["vm"] as ExpensesVm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetTheExpenses();
        }

    }
}