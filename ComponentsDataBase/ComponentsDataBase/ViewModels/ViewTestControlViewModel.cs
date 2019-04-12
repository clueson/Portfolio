using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Windows.Input;

namespace ComponentsDataBase.ViewModels
{
    public class ViewTestControlViewModel : BindableBase
    {
        #region Fields
        private string _firstname = "Cunt";
        private string _lastname = "Bastard";
        #endregion

        #region Properties
        //public ICommand PopulateTextBoxCommand { get; set; }
        public DelegateCommand PopulateTextBoxCommand{get;set;}
        public IEventAggregator _aggregator { get; set; }
        public string Firstname
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }
        public string Lastname
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }
        #endregion

        #region Methods
        public ViewTestControlViewModel()
        {
            //_aggregator = agg;
            
            PopulateTextBoxCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => Firstname).ObservesProperty(() => Lastname);
        }
        private bool CanExecute()
        {
           return !string.IsNullOrWhiteSpace(Firstname) && !string.IsNullOrWhiteSpace(Lastname);
        }
        private void Execute()
        {
            Firstname = "Colin";
            Lastname = "Coulson";
        }
        #endregion
    }
}
