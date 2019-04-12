using ComponentsDataBase.Events;
using ComponentsDataBase.Helpers;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace ComponentsDataBase.ViewModels
{
    public class ViewLeftLBViewModel : BindableBase
    {
        #region Fields
        private SolidColorBrush _listviewborderackground = new SolidColorBrush(Colors.LightGray);
        private SolidColorBrush _listviewborderbrush = new SolidColorBrush(Colors.Gray);
        #endregion

        #region Properties
        public SolidColorBrush ListViewBorderBackground
        {
            get { return _listviewborderackground; }
            private set { SetProperty(ref _listviewborderackground, value); }
        }
        public SolidColorBrush ListViewBorderBrush
        {
            get { return _listviewborderbrush; }
            private set { SetProperty(ref _listviewborderbrush, value); }
        }
        IChangeViewColours ViewColours { get; set; }
        IEventAggregator _aggregator { get; set; }
        public IEventAggregator aggregator { get; set; }
        public DelegateCommand<MouseEventArgs> mousenterCommand2 { get; set; }
        #endregion

        #region Constructor
        public ViewLeftLBViewModel(IEventAggregator aggregator)
        {
            //intilaises the events aggregator service
            _aggregator = aggregator;

            //Intialises the mouse over command delegate that points to a method
            mousenterCommand2 = new DelegateCommand<MouseEventArgs>(MouseEnterAction);

            //intialises the interface
            //ViewColours = new ChangeViewColours();
            //no longer used!    //ViewColours = CreateInterface.ReturnTheChangeViewColoursProperty();

            //Intialises the event listener for the event
            _aggregator.GetEvent<UpdateColourEvent>().Subscribe(SetNewBackgroundColourNew);

        }
        #endregion

        #region Methods
        [Obsolete("Use the new method 'SetNewBackgroundColourNew'")]
        private void SetNewBackgroundColour(string thetag)
        {
            //Extracts the solidcolourbrushs from the dictionary and applies them to the style

            //Assigns an dictionary object
            Dictionary<string, SolidColorBrush> Listboxstyles = ViewColours.ColourDictionaryChangeEntry(thetag);

            //Checks to see if the dictionary object is empty - move this to the class!
            if (Listboxstyles.Count == 0)
            {
                _aggregator.GetEvent<UpdateTagEvent>().Publish("ERROR - The Property was not set in the View!");
            }
            else
            {
                ListViewBorderBackground = Listboxstyles.SingleOrDefault(x => x.Key == "_ListViewBorderBackground").Value;
                ListViewBorderBrush = Listboxstyles.SingleOrDefault(x => x.Key == "_ListViewBorderBrush").Value;
            }
        }
        private void MouseEnterAction(MouseEventArgs obj)
        {
            //extracts the Tag property value from the menu items on the main menu
            //sends the property contents to a method
            SendTagToViewModel(obj.Source.GetType().GetProperty("Tag").GetValue(obj.Source).ToString());
        }
        private void SendTagToViewModel(string thetag)
        {
            //Publishes an event aggregator object for recieving into another viewmodel(messaging)
            _aggregator.GetEvent<UpdateTagEvent>().Publish(thetag);
        }
        private void SetNewBackgroundColourNew(string thetag)
        {
            ListViewBorderBackground = ListviewColourProps.GetProperties(thetag).listViewBorderBackground;
            ListViewBorderBrush = ListviewColourProps.GetProperties(thetag).listViewBorderBrush;
            //ListViewContainerBackground = ListviewColourProps.GetProperties(thetag).listViewContainerBackground;
        }
        #endregion
    }
 
}
