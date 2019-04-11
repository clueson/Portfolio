using Expenses.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CatagoriesPage : ContentPage
	{
        #region Fields
        CatagoriesVm ViewModel;
        #endregion

        public CatagoriesPage ()
		{
			InitializeComponent ();
            //assigns the vm object and casts it to the type
            ViewModel = Resources["vm"] as CatagoriesVm;
        }

        protected override void OnAppearing()
        {
            //loads everytime the page appears
            base.OnAppearing();
            //assighns the Viewmodel the data
            ViewModel.GetThePercentPerCat();

        }
    }
}