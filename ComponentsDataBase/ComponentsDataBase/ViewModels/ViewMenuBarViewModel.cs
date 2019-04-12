using ComponentsDataBase.Events;
using ComponentsDataBase.Helpers;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Linq;

namespace ComponentsDataBase.ViewModels
{
    public class ViewMenuBarViewModel : BindableBase
    {
        #region Fields
        private DateTime? _lastupdated ;
        private  DispatcherTimer dt = new DispatcherTimer();
        private SolidColorBrush _menuborderbackground = new SolidColorBrush(Colors.LightGray);
        private SolidColorBrush _menuitemsforeground = new SolidColorBrush(Colors.Black);
        private SolidColorBrush _menuitemsborderbrush = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush _menuhighlightforeground = new SolidColorBrush(Colors.White);
        private LinearGradientBrush _lineargb;
        #endregion

        #region Properties
        public DateTime? LastUpdated
        {
            get { return _lastupdated; }
            set { SetProperty(ref _lastupdated, value); }
        }
        public SolidColorBrush MenuBorderBackGround
        {
            get { return _menuborderbackground; }
            set { SetProperty(ref _menuborderbackground, value); }
        }
        public SolidColorBrush MenuItemsForeground
        {
            get { return _menuitemsforeground; }
            set { SetProperty(ref _menuitemsforeground, value); }
        }
        public SolidColorBrush MenuItemsBorderBrush
        {
            get {return _menuitemsborderbrush; }
            set {SetProperty(ref _menuitemsborderbrush, value); }
        }
        public SolidColorBrush MenuHighlightForeground
        {
            get {return _menuhighlightforeground; }
            set {SetProperty(ref _menuhighlightforeground, value); }
        }
        public IEventAggregator _eventaggregator { get; set; }
        public IChangeViewColours ViewColours { get; set; }
        IChangeGradient ILinearGB { get; set; }
        public LinearGradientBrush Lineargb
        {
            get { return _lineargb; }
            set { SetProperty(ref _lineargb, value); }
        }
        public DelegateCommand<MouseEventArgs> mousenterCommand { get; set; }
        public DelegateCommand<string> exitCommand { get; set; }
        public DelegateCommand<string> changecolourCommand { get; set; }

        #endregion

        #region Constructor
        public ViewMenuBarViewModel(IEventAggregator eventaggregator)
        {
            //Assigns the event aggregator pool for recieving Pub/Sub events
            _eventaggregator = eventaggregator;

            //intialises the interfaces
                //ViewColours = new ChangeViewColours();
                //ILinearGB = new ChangeGradient();
            ViewColours = CreateInterface.ReturnTheChangeViewColoursProperty();
            ILinearGB = CreateInterface.ReturnTheChangeGradientProperty();

            //Proccesses the bound interaction event trigger events to the method using a delegatecommand
            mousenterCommand = new DelegateCommand<MouseEventArgs>(MouseEnterAction);
            
            //Button for exit command on menuitems
            exitCommand = new DelegateCommand<string>(ExitApplication);
            
            //Command to change all the skin colours originates from the menu 
            changecolourCommand = new DelegateCommand<string>(SetNewBackgroundColourNew);

            //Run Date and time updates every second
            RunTimer();
        }
        #endregion

        #region Methods
        [Obsolete("Use new method 'SetNewBackgroundColourNew'")]
        private void SetNewBackgroundColour(string thetag)
        {
            //Extracts the solidcolourbrushs from the dictionary and applies them to the style
            //<---------This method will be obselete see 'SetNewBackgroundColourNew'------->

            //Assigns a dictionary object
            Dictionary<string, SolidColorBrush> Menustyles = ViewColours.ColourDictionaryChangeEntry(thetag);

            //Checks to see if the dictionary object is empty - move this to the class!
            if (Menustyles.Count == 0)
            {
                _eventaggregator.GetEvent<UpdateTagEvent>().Publish("ERROR - The Property was not set in the View!");
            }
            else
            {
                MenuBorderBackGround = Menustyles.SingleOrDefault(x => x.Key == "_MenuBorderBackGround").Value;
                MenuItemsForeground = Menustyles.SingleOrDefault(x => x.Key == "_MenuItemsForeground").Value;
                MenuItemsBorderBrush = Menustyles.SingleOrDefault(x => x.Key == "_MenuItemsBorderBrush").Value;
                MenuHighlightForeground = Menustyles.SingleOrDefault(x => x.Key == "_MenuHighlightForeground").Value;
            }

            //Publishes to the update colour event pub/sub 
            //passing the tag for the events listner
            _eventaggregator.GetEvent<UpdateColourEvent>().Publish(thetag);
        }
        private void ExitApplication(string obj)
        {
            //shuts down the application
            dt.Stop();
            Application.Current.Shutdown();
        }
        private void RunTimer()
        {
            //Initialtes a 1 second timer
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }
        private void Dt_Tick(object sender, EventArgs e)
        {
            //Assigns to the time and date property
            LastUpdated = DateTime.Now;
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
            _eventaggregator.GetEvent<UpdateTagEvent>().Publish(thetag);
        }
        private bool CanExecute()
        {
            return true;
        }
        private void Execute()
        {            
        }
        private void SetNewBackgroundColourNew(string thetag)
        {
            //<----- This Stub to replaces the 'SetNewBackgroundColour(string thetag)' method ------->

            //Uses the static method of the 'TestClass' to access the properties through an interface
            MenuBorderBackGround = MenuColoursProps.GetProperties(thetag).menuborderbackground;
            MenuItemsForeground = MenuColoursProps.GetProperties(thetag).meniItemsforeground;
            MenuItemsBorderBrush = MenuColoursProps.GetProperties(thetag).menuitemsborderbrush;
            MenuHighlightForeground = MenuColoursProps.GetProperties(thetag).menuhighlightforeground;

            //Publishes to the update colour event pub/sub 
            //passing the tag for the events listner
            _eventaggregator.GetEvent<UpdateColourEvent>().Publish(thetag);
        }
   
        #endregion

    }

}
