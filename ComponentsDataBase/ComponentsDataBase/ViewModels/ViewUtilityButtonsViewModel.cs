using ComponentsDataBase.Events;
using ComponentsDataBase.Helpers;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace ComponentsDataBase.ViewModels
{
    class ViewUtilityButtonsViewModel : BindableBase
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
        public SolidColorBrush EllipseStroke
        {
            get { return _ellipsestroke; }
            set { SetProperty(ref _ellipsestroke, value); }
        }
        public SolidColorBrush ButtonMouseOverForeground
        {
            get { return _buttonmouseoverforeground; }
            set { SetProperty(ref _buttonmouseoverforeground, value); }
        }
        public SolidColorBrush ButtonIsPressStroke
        {
            get { return _buttonispressstroke; }
            set { SetProperty(ref _buttonispressstroke, value); }
        }
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
        public LinearGradientBrush Lineargb
        {
            get { return _lineargb; }
            set { SetProperty(ref _lineargb, value); }
        }
        IChangeViewColours ViewColours { get; set; }
        IChangeGradient ILinearGB { get; set; }
        public IEventAggregator _aggregator { get; set; }
        public DelegateCommand<MouseEventArgs> mousenterCommand2 { get; set; }
        #endregion

        #region Constructor
        public ViewUtilityButtonsViewModel(IEventAggregator agg)
        {
            //intilaises the events aggregator service
            _aggregator = agg;

            //Intialises the mouse over command delegate that points to a method
            mousenterCommand2 = new DelegateCommand<MouseEventArgs>(MouseEnterAction);

            //intialises the interfaces
                //ViewColours = new ChangeViewColours();
                //ILinearGB = new ChangeGradient();
            ViewColours = CreateInterface.ReturnTheChangeViewColoursProperty();
            ILinearGB = CreateInterface.ReturnTheChangeGradientProperty();

            //Intialises the event listner for the event
            _aggregator.GetEvent<UpdateColourEvent>().Subscribe(SetNewBackgroundColour);

            //initialises the buttons
            Lineargb = ILinearGB.CreateLinearGradientFill(GradstopColour1, GradstopColour2);
        }
        #endregion

        #region Methods
        private void SetNewBackgroundColour(string thetag)
        {
            //Extracts the solidcolourbrushs from the dictionary and applies them to the style
            
            //Assigns an dictionary object
            Dictionary<string, SolidColorBrush> Buttonstyles = ViewColours.ColourDictionaryChangeEntry(thetag);
            
            //Checks to see if the dictionary object is empty - move this to the class!
            if(Buttonstyles.Count == 0)
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

        #region Unused code
        private void UnusedCodeViewUtilityButtonViewModel()
        {
            #region Gets the solid colour brushes from the ColourDictionaryChangeColourEntry Object
            //private void SetNewBackgroundColour(string thetag)
            //{
            //foreach (KeyValuePair<string, SolidColorBrush> col in ViewColours.ColourDictionaryChangeEntry(thetag))
            //{
            //    if (col.Key == "_EllipseStroke") //|| col.Key ==  || col.Key == ")
            //    {
            //        EllipseStroke = col.Value;
            //    }
            //    else if (col.Key == "_ButtonMouseOverForeground")
            //    {
            //        ButtonMouseOverForeground = col.Value;
            //    }
            //    else if (col.Key == "_ButtonIsPressStroke")
            //    {
            //        ButtonIsPressStroke = col.Value;
            //    }
            //    else if (col.Key == "_EllipseGradientStopColour1")
            //    {
            //        GradstopColour1 = col.Value;
            //    }
            //    else if (col.Key == "_EllipseGradientStopColour2")
            //    {
            //        GradstopColour2 = col.Value;
            //    }
            //    else if (col.Value == null || col.Key == null)
            //    {
            //        _aggregator.GetEvent<UpdateTagEvent>().Publish("ERROR - The Property was not set in the View!");
            //    }
            //}
            //}
            #endregion

            #region iterating thorugh a solidcolour list object
            ////sets the colour of the menu dynamically using colour pairs
            //foreach (SolidColorBrush col in ViewColours.ColourChangeEntry(thetag))
            //{

            //}
            #endregion
        }
        #endregion

        #endregion
    }


}

