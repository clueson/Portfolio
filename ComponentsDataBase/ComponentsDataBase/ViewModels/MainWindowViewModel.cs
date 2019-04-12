using ComponentsDataBase.Events;
using ComponentsDataBase.Helpers;
using ComponentsDataBase.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Media;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Configures the main window and defines which region are wired
/// up to corresponding views using the prism engine, creates event listeners for
/// subscribers and sets the main window colour properties on the controls
/// using the IChangeViewcolours interface.
/// </summary>
namespace ComponentsDataBase.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        #region Fields
        private readonly IRegionManager _regionmanager;
        private SolidColorBrush _mainwindowborderbrush = new SolidColorBrush(Colors.Gray);
        private SolidColorBrush _mainwindowborderbackground = new SolidColorBrush(Colors.White);
        #endregion

        #region Properties
        public SolidColorBrush MainWindowBorderBrush
        {
            get { return _mainwindowborderbrush; }
            set { SetProperty(ref _mainwindowborderbrush, value); }
        }
        public SolidColorBrush MainWindowBorderBackground
        {
            get { return _mainwindowborderbackground; }
            set { SetProperty(ref _mainwindowborderbrush, value); }
        }
        IChangeViewColours ViewColours { get; set; }
        public IEventAggregator _aggregator { get; set; }   
        #endregion

        #region Constructor
        public MainWindowViewModel(IRegionManager regionmanager, IEventAggregator aggregator )
        {
            //assigns the region manager object to the field
            _regionmanager = regionmanager;

            //intialises the IEvent aggregator object - enables event listening
            _aggregator = aggregator;

            //Intitialises the interfaces via the factory methods class
            //ViewColours = new ChangeViewColours();
            ViewColours = CreateInterface.ReturnTheChangeViewColoursProperty();
                        
            //Configure the region manager and adds all the regions into the view
            _regionmanager.RegisterViewWithRegion("MenuBar", typeof(ViewMenuBar));
            _regionmanager.RegisterViewWithRegion("SearchTextBox", typeof(ViewSearchTextBox));
            _regionmanager.RegisterViewWithRegion("ButtonRibbons", typeof(ViewButtonsRibbon));
            _regionmanager.RegisterViewWithRegion("ListBoxesLeft", typeof(ViewLeftLB));
            _regionmanager.RegisterViewWithRegion("ListBoxesRight", typeof(ViewRightLB));
            _regionmanager.RegisterViewWithRegion("UtilityButtons", typeof(ViewUtilityButtons));
            _regionmanager.RegisterViewWithRegion("StatusBar", typeof(ViewStatusBar));

            //creates an event listener for the updatecolour event
            _aggregator.GetEvent<UpdateColourEvent>().Subscribe(SetNewBackgroundColourNew);

        }
        #endregion

        #region Methods

        [Obsolete("Use SetNewBackgroundColourNew Method")]
        private void SetNewBackgroundColour(string thetag)
        {
            //Extracts the solidcolourbrushs from the dictionary and applies them to the style

            //Assigns a dictionary object
            Dictionary<string, SolidColorBrush> Windowstyles = ViewColours.ColourDictionaryChangeEntry(thetag);

            //Checks to see if the dictionary object is empty - move this to the class!
            if (Windowstyles.Count == 0)
            {
                _aggregator.GetEvent<UpdateTagEvent>().Publish("ERROR - The Property was not set in the View!");
            }
            else
            {
                MainWindowBorderBrush = Windowstyles.SingleOrDefault(x => x.Key == "_MainWindowBorderBrush").Value;
                MainWindowBorderBackground = Windowstyles.SingleOrDefault(x => x.Key == "_MainWindowBorderBackground").Value;
            }
        }
        private void SetNewBackgroundColourNew(string thetag)
        {
            //Assigns the extracted solidcolourbrushes to the class
            //member properties using an interface via a static method
            MainWindowBorderBackground = MainwindowColourProps.GetProperties(thetag).mainwindowborderbackground;
            MainWindowBorderBrush = MainwindowColourProps.GetProperties(thetag).mainwindowborderbrush;
        }
        #endregion

        #region UnsedCode
        private void UnsedCode()
        {
            //Attaching the navigate delegates of type string to the target methods
            //NavigateCommand = new DelegateCommand<string>(Navigate);
            //NavigateCommand1 = new DelegateCommand<string>(Navigate1);

                    //private void Navigate(string uri)
        //{
            //The region manager object is then assigned to the region inside the
            //main window which then loads the content within the region
            //the content is the view "ViewA" user control
            //the "uri" is the text name of the region on the mainwindow
            //_regionmanager.RequestNavigate("Anotherview", uri);

        //}
        //private void Navigate1(string uri)
        //{
            //The region manager object is then assigned to the region inside the
            //main window which then loads the content within the region
            //the content is the view "ViewB" user control
            //the "uri" is the text name of the region on the mainwindow
            //_regionmanager1.RequestNavigate("AnotherView", uri);
            //_regionmanager1.RequestNavigate("SearchTextBox", uri);
            //_regionmanager.RequestNavigate<ViewAViewModel>("ContentRegion"); - in next version of prism using tokens

        //}
    }
        #endregion

    }
}
