using ComponentsDataBase.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Media;
using ComponentsDataBase.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace ComponentsDataBase.ViewModels
{
    public class ViewStatusBarViewModel : BindableBase
    {
        #region Fields
        private string _statusbartext;
        private SolidColorBrush _statusbarborderbackground = new SolidColorBrush(Colors.LightGray);
        #endregion

        #region Properties
        public SolidColorBrush StatusBarBorderBackground
        {
            get { return _statusbarborderbackground; }
            set { SetProperty(ref _statusbarborderbackground, value); }
        }
        public string Statusbartext
        {
            get { return _statusbartext; }
            set { SetProperty(ref _statusbartext, value); }
        }
        public IEventAggregator _eventaggregator { get; set; }
        public IChangeViewColours ViewColours { get; set; }
        #endregion

        #region Constructor
        public ViewStatusBarViewModel(IEventAggregator aggregator)
        {
            //loads the data and starts the events listener from the prism engine
            _eventaggregator = aggregator;

            //Initialises the interface
                //ViewColours = new ChangeViewColours();
            ViewColours = CreateInterface.ReturnTheChangeViewColoursProperty();
            
            //subscribes to the event
            _eventaggregator.GetEvent<UpdateTagEvent>().Subscribe(UpdateTagSensed);

            //Changes the colour of the background by listening for the event
            _eventaggregator.GetEvent<UpdateColourEvent>().Subscribe(SetNewBackgroundColour);

        }
        #endregion

        #region Methods
        private bool CanExecute()
        {
            return true;
        }
        private void Execute()
        {
            
        }
        private void SetNewBackgroundColour(string thetag)
        {
            //Extracts the solidcolourbrushs from the dictionary and applies them to the style

            //Assigns a dictionary object
            Dictionary<string, SolidColorBrush> Statusbarstyles = ViewColours.ColourDictionaryChangeEntry(thetag);

            //Checks to see if the dictionary object is empty - move this to the class!
            if (Statusbarstyles.Count == 0)
            {
                _eventaggregator.GetEvent<UpdateTagEvent>().Publish("ERROR - The Property was not set in the View!");
            }
            else
            {
                StatusBarBorderBackground = Statusbarstyles.SingleOrDefault(x => x.Key == "_StatusBarBorderBackground").Value;
            }

        }
        private void UpdateTagSensed(string obj)
        {
            Statusbartext = obj;
        }
        
        #endregion

    }

}
 