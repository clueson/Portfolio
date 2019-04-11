using Expenses.Models;
using Expenses.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expenses.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseDetailsPage : ContentPage
    {
        #region Field
        private ExpenseDetailsVM TheViewModel;
        #endregion

        #region Constructors

        /// <summary>
        /// default constructor
        /// </summary>
        public ExpenseDetailsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Second Contructor
        /// </summary>
        /// <param name="expense"></param>
        public ExpenseDetailsPage(Expense expense)
        {
            InitializeComponent();
            //better to do this in xaml! using the bindingcontext attribute
            TheViewModel = Resources["vm"] as ExpenseDetailsVM;
            TheViewModel.Expense = expense;
        }
        #endregion
    }
}