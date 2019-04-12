using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using System.Windows.Input;
using ComponentsDataBase.Events;
using System.Windows.Media;
using ComponentsDataBase.Helpers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ComponentsDataBase.ViewModels
{
    class ViewButtonsRibbonViewModel : BindableBase
    {
        #region Fields
        private SolidColorBrush _gradstopcolour1 = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush _gradstopcolour2 = new SolidColorBrush(Colors.LightGray);
        private SolidColorBrush _ellipsestroke = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush _buttonmouseoverforeground = new SolidColorBrush(Colors.White);
        private SolidColorBrush _buttonispressstroke = new SolidColorBrush(Colors.Gray);
        private LinearGradientBrush _lineargb;
        #endregion

        #region Properties
        public SolidColorBrush GradstopColour1
        {
            get { return _gradstopcolour1; }
            set { SetProperty(ref _gradstopcolour1, value); }
        }
        public SolidColorBrush GradstopColour2
        {
            get { return _gradstopcolour2; }
            set { SetProperty(ref _gradstopcolour2, value); }
        }
        public SolidColorBrush EllipseStroke
        {
            get { return _ellipsestroke; }
            private set { SetProperty(ref _ellipsestroke, value); }
        }
        public SolidColorBrush ButtonMouseOverForeground
        {
            get { return _buttonmouseoverforeground; }
            private set { SetProperty(ref _buttonmouseoverforeground, value); }
        }
        public SolidColorBrush ButtonIsPressStroke
        {
            get { return _buttonispressstroke; }
            private set { SetProperty(ref _buttonispressstroke, value); }
        }
        public LinearGradientBrush Lineargb
        {
            get {return _lineargb; }
            set {SetProperty(ref _lineargb,value); }
        }
        IChangeViewColours ViewColours { get; set; }
        IChangeGradient ILinearGB { get; set; }
        public IEventAggregator _aggregator { get; set; } 
        public DelegateCommand<MouseEventArgs> mousenterCommand1 { get; set; }

        #endregion

        #region Constructor
        public ViewButtonsRibbonViewModel(IEventAggregator agg)
        {
            //initialises the prism events listener interface
            _aggregator = agg;

            //Intialises the Interfaces
                //ViewColours = new ChangeViewColours();
                //ILinearGB = new ChangeGradient();
            ViewColours = CreateInterface.ReturnTheChangeViewColoursProperty();
            ILinearGB = CreateInterface.ReturnTheChangeGradientProperty();

            //Intilaises the event listner
            _aggregator.GetEvent<UpdateColourEvent>().Subscribe(SetNewBackgroundColourNew);

            //assigns the mouse enter events to the prism delegate command obj
            mousenterCommand1 = new DelegateCommand<MouseEventArgs>(MouseEnterAction);

            //initialises the buttons
            Lineargb = ILinearGB.CreateLinearGradientFill(GradstopColour1, GradstopColour2);

        }

        #endregion

        #region Methods
        [Obsolete("Use the 'SetNewBackgroundColourNew' method")]
        private void SetNewBackgroundColour(string thetag)
        {
            //Extracts the solidcolourbrushs from the dictionary and applies them to the style

            //Assigns an dictionary object
            Dictionary<string, SolidColorBrush> Buttonstyles = ViewColours.ColourDictionaryChangeEntry(thetag);

            //Checks to see if the dictionary object is empty - move this to the class!
            if (Buttonstyles.Count == 0)
            {
                _aggregator.GetEvent<UpdateTagEvent>().Publish("ERROR - The Property was not set in the View!");
            }
            else
            {
                EllipseStroke = Buttonstyles.SingleOrDefault(x => x.Key == "_EllipseStroke").Value;
                ButtonMouseOverForeground = Buttonstyles.SingleOrDefault(x => x.Key == "_ButtonMouseOverForeground").Value;
                ButtonIsPressStroke = Buttonstyles.SingleOrDefault(x => x.Key == "_ButtonIsPressStroke").Value;
                GradstopColour1 = Buttonstyles.SingleOrDefault(x => x.Key == "_EllipseGradientStopColour1").Value;
                GradstopColour2 = Buttonstyles.SingleOrDefault(x => x.Key == "_EllipseGradientStopColour2").Value;
            }

            //Moves to the Method to set the gradient style of the button
            SetButtonGradientStyle(GradstopColour1, GradstopColour2);

        }
        private void SetButtonGradientStyle(SolidColorBrush g1, SolidColorBrush g2)
        {
            //Sets the button gradient style
            Lineargb = ILinearGB.CreateLinearGradientFill(GradstopColour1, GradstopColour2);
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
            //Uses the 'ButtonColourProps' interface to access the properties for the buttons
            EllipseStroke = ButtonColourProps.GetProperties(thetag).ellipseStroke;
            ButtonMouseOverForeground = ButtonColourProps.GetProperties(thetag).buttonMouseOverForeground;
            ButtonIsPressStroke = ButtonColourProps.GetProperties(thetag).buttonIsPressStroke;
            GradstopColour1 = ButtonColourProps.GetProperties(thetag).ellipseGradientStopColour1;
            GradstopColour2 = ButtonColourProps.GetProperties(thetag).ellipseGradientStopColour2;

            //Moves to the Method to set the gradient style of the button
            SetButtonGradientStyle(GradstopColour1, GradstopColour2);
        }

        #endregion
    }
}