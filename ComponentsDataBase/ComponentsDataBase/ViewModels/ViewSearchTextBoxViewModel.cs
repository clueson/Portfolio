using ComponentsDataBase.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ComponentsDataBase.Helpers;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ComponentsDataBase.ViewModels
{
    public class ViewSearchTextBoxViewModel : BindableBase
    {
        #region Fields
        private string _inputsearchtext = "Type your text in here";
        private SolidColorBrush _gradstopcolour1 = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush _gradstopcolour2 = new SolidColorBrush(Colors.LightGray);
        private SolidColorBrush _ellipsestroke = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush _buttonmouseoverforeground = new SolidColorBrush(Colors.White);
        private SolidColorBrush _buttonispressstroke = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush _textboxborderbrush = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush _textboxborderbackground = new SolidColorBrush(Colors.LightGray);
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
        public SolidColorBrush TextBoxBorderBrush
        {
            get {return _textboxborderbrush; }
            private set {SetProperty(ref _textboxborderbrush, value); }
        }
        public SolidColorBrush TextBoxBorderBackground
        {
            get {return _textboxborderbackground; }
            private set {SetProperty(ref _textboxborderbackground, value); }
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
        IEventAggregator _aggr { set; get; }
        IChangeViewColours ViewColours { get; set; }
        IChangeGradient ILinearGB { get; set; }
        public LinearGradientBrush Lineargb
        {
            get { return _lineargb; }
            set { SetProperty(ref _lineargb, value); }
        }
        public string Inputsearchtext
        {
            get { return _inputsearchtext; }
            set { SetProperty(ref _inputsearchtext, value); }
        }
        public DelegateCommand<MouseEventArgs> mousenterCommand3 { get; set;}
        public DelegateCommand textsearchCommand { get; set ; }
        #endregion

        #region Constructor
        public ViewSearchTextBoxViewModel(IEventAggregator aggregator)
        {
            //Assigns the global events aggregator object 
            _aggr = aggregator;

            //Assigns the command to the mouse enter event and passes the "MouseEventsArg"
            mousenterCommand3 = new DelegateCommand<MouseEventArgs>(MouseEnterAction);

            //Assigns the searchtextCommand to a delegate type points to a method
            //Observes the textsearch field.
            textsearchCommand = new DelegateCommand(CanExecute, Execute).ObservesProperty(()=> textsearchCommand);

            //intialises the interfaces
                //ViewColours = new ChangeViewColours();
                //ILinearGB = new ChangeGradient();
            ViewColours = CreateInterface.ReturnTheChangeViewColoursProperty();
            ILinearGB = CreateInterface.ReturnTheChangeGradientProperty();

            //Intialises the event listner for the event
            _aggr.GetEvent<UpdateColourEvent>().Subscribe(SetNewBackgroundColourNew);

            //initialises the buttons
            Lineargb = ILinearGB.CreateLinearGradientFill(GradstopColour1, GradstopColour2);
        }
        #endregion

        #region Methods
        [Obsolete("Use the 'SetNewBackgroundColourNew' Method")]
        private void SetNewBackgroundColour(string thetag)
        {
            //Extracts the solidcolourbrushs from the dictionary and applies them to the style

            //Assigns a dictionary object
            Dictionary<string, SolidColorBrush> Buttonstyles = ViewColours.ColourDictionaryChangeEntry(thetag);

            //Checks to see if the dictionary object is empty - move this to the class!
            if (Buttonstyles.Count == 0)
            {
                _aggr.GetEvent<UpdateTagEvent>().Publish("ERROR - The Property was not set in the View!");
            }
            else
            {
                EllipseStroke = Buttonstyles.SingleOrDefault(x => x.Key == "_EllipseStroke").Value;
                ButtonMouseOverForeground = Buttonstyles.SingleOrDefault(x => x.Key == "_ButtonMouseOverForeground").Value;
                ButtonIsPressStroke = Buttonstyles.SingleOrDefault(x => x.Key == "_ButtonIsPressStroke").Value;
                TextBoxBorderBrush = Buttonstyles.SingleOrDefault(x => x.Key == "_TextBoxBorderBrush").Value;
                TextBoxBorderBackground = Buttonstyles.SingleOrDefault(x => x.Key == "_TextBoxBorderBackground").Value;
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
        private bool Execute()
        {
            //checks to see if the string is null or has whitespace characters
            return !string.IsNullOrWhiteSpace(Inputsearchtext);
        }
        private void CanExecute()
        {
            // executes the program;
            InvokeWebSearch();
        }
        private void InvokeWebSearch()
        {
            //Extracts the text from the textbox in the view
            MessageBox.Show("The input was : " + Inputsearchtext, "The Grabbed Text", MessageBoxButton.OK);
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
            _aggr.GetEvent<UpdateTagEvent>().Publish(thetag);
        }
        private void SetNewBackgroundColourNew(string thetag)
        {
            EllipseStroke = ButtonColourProps.GetProperties(thetag).ellipseStroke;
            ButtonMouseOverForeground = ButtonColourProps.GetProperties(thetag).buttonMouseOverForeground;
            ButtonIsPressStroke = ButtonColourProps.GetProperties(thetag).buttonIsPressStroke;
            TextBoxBorderBrush = TextBoxColoursProps.GetProperties(thetag).textBoxBorderBrush;
            TextBoxBorderBackground = TextBoxColoursProps.GetProperties(thetag).textBoxBorderBackground;
            GradstopColour1 = ButtonColourProps.GetProperties(thetag).ellipseGradientStopColour1;
            GradstopColour2 = ButtonColourProps.GetProperties(thetag).ellipseGradientStopColour2;

            //Moves to the Method to set the gradient style of the button
            SetButtonGradientStyle(GradstopColour1, GradstopColour2);
        }
        #endregion
    }
}
