using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

/// <summary>
/// This series of class and interfaces organises all of the 
/// controls related to each user control and then changes the coulors
/// of all of the related controls through an interface when called by the ViewModel code.
/// </summary>
namespace ComponentsDataBase.Helpers
{
    #region Gradient Property settings for Xaml
    interface ICreateinterface
    {
        void CreateIChangeGradient();
        void CreateViewColoursInterface();
        IChangeGradient GradientInterface { get; set; }
        IChangeViewColours ViewColoursInterface { get; set; }
    }
    internal class CreateInterface : ICreateinterface
    {
        #region Properties
        public IChangeGradient GradientInterface { get; set; }
        public IChangeViewColours ViewColoursInterface { get; set; }
        #endregion

        #region Methods
        public void CreateIChangeGradient()
        {
            //only assigns the property once
            if (GradientInterface == null)
            {
                //assigns the property of 'type' interface referenced to the class object
                GradientInterface = new ChangeGradient();
            }
        }
        public void CreateViewColoursInterface()
        {
            //only assigns the property once
            if (ViewColoursInterface== null)
            {
                //assigns the property of 'type' interface referenced to the class object
                ViewColoursInterface = new ChangeViewColours();
            }
        }
        public static IChangeGradient ReturnTheChangeGradientProperty()
        {
            //Access the property through an object instance of the interface referenced to the class
            ICreateinterface i = new CreateInterface();
            i.CreateIChangeGradient();
            return i.GradientInterface;
        }
        public static IChangeViewColours ReturnTheChangeViewColoursProperty()
        {
            //Access the property through an object instance of the interface referenced to the class
            ICreateinterface i = new CreateInterface();
            i.CreateViewColoursInterface();
            return i.ViewColoursInterface;
        }
        #endregion

    }
    #endregion

    #region Abstract base class For all the Xaml Property settings for the UI
    public interface IUIBaseColourProperties
    {
        Dictionary<string, SolidColorBrush> Testdictionary { get; set; }
    }
    public abstract class UIBaseColourProperties : IUIBaseColourProperties
    {
        #region Fields
        private Dictionary<string, SolidColorBrush> _testDictionary;
        private IChangeViewColours viewcoloursInterface;
        //private IUIBaseColourProperties uinterface;
        #endregion

        #region Properties
        public Dictionary<string, SolidColorBrush> Testdictionary { get; set; }
        private SolidColorBrush mainWindowBorderBrush { get; set; }
        private SolidColorBrush mainWindowBorderBackground { get; set; }
        private SolidColorBrush listViewBorderBackground { get; set; }
        private SolidColorBrush listViewBorderBrush { get; set; }
        private SolidColorBrush listViewContainerBackground { get; set; }
        private SolidColorBrush textBoxBorderBrush { get; set; }
        private SolidColorBrush textBoxBorderBackground { get; set; }
        private SolidColorBrush ellipseStroke { get; set; }
        private SolidColorBrush buttonMouseOverForeground { get; set; }
        private SolidColorBrush buttonIsPressStroke { get; set; }
        private SolidColorBrush statusBarBorderBackground { get; set; }
        private SolidColorBrush ellipseGradientStopColour1 { get; set; }
        private SolidColorBrush ellipseGradientStopColour2 { get; set; }
        #endregion

        #region Methods
        public virtual void GetMainWindowColProps(string thetag)
        {
            //Moves to the base method implementation.
            ReturnDictionary(thetag);
        }
        private void ReturnDictionary(string thetag)
        {
            //Initialises the interface.
            viewcoloursInterface = new ChangeViewColours();

            //assigns the dictionary property of all the xaml properties using the interface.
            Testdictionary = viewcoloursInterface.ColourDictionaryChangeEntry(thetag);
        }
        #endregion
    }
    #endregion

    #region Button Xaml property settings including an Interface
    interface IButtonCoulorProps : IUIBaseColourProperties
    {
        SolidColorBrush ellipseStroke { get; set; }
        SolidColorBrush buttonMouseOverForeground { get; set; }
        SolidColorBrush buttonIsPressStroke { get; set; }
        SolidColorBrush ellipseGradientStopColour1 { get; set; }
        SolidColorBrush ellipseGradientStopColour2 { get; set; }
        void GetMainWindowColProps(string thetag);
        void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict);
    }
    internal class ButtonColourProps : UIBaseColourProperties, IButtonCoulorProps
    {
        #region Fields

        #endregion

        #region Properties
        public SolidColorBrush buttonIsPressStroke { get; set; }
        public SolidColorBrush buttonMouseOverForeground { get; set; }
        public SolidColorBrush ellipseGradientStopColour1 { get; set; }
        public SolidColorBrush ellipseGradientStopColour2 { get; set; }
        public SolidColorBrush ellipseStroke { get; set; }
        #endregion

        #region constructor
        public ButtonColourProps()
        {
            //Intialises the viewcolours interface
            //viewcoloursInterface = new ChangeViewColours();
        }
        #endregion

        #region methods
        public override void GetMainWindowColProps(string thetag)
        {
            //Uses the base method
            base.GetMainWindowColProps(thetag);
        }
        public void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict)
        {
            //Moves to the method used by the Class interface
            ExtractProperties(passeddict);
        }
        private void ExtractProperties(Dictionary<string, SolidColorBrush> allpropertiesdictionary)
        {
            //Extracts the specified properties into the class member properties using linq
            buttonIsPressStroke = allpropertiesdictionary.FirstOrDefault(x => x.Key == "_ButtonIsPressStroke").Value;
            buttonMouseOverForeground = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_ButtonMouseOverForeground").Value;
            ellipseGradientStopColour1 = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_EllipseGradientStopColour1").Value;
            ellipseGradientStopColour2 = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_EllipseGradientStopColour2").Value;
            ellipseStroke = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_EllipseStroke").Value;
        }
        public static IButtonCoulorProps GetProperties(string thetag)
        {
            //Uses an interface to set a dictionary and then select the required xaml properties.

            //Creates an instance of the interface referenced to the class - extracts the 4 properties
            IButtonCoulorProps buttoninterface = new ButtonColourProps();

            //Moves to the overidden Method in this class
            buttoninterface.GetMainWindowColProps(thetag);

            //Uses the interface to move to the method passing in a dictionary
            buttoninterface.PathToExtractPropertiesMethod(buttoninterface.Testdictionary);
            
            //returns the interface with properties set
            return buttoninterface;
        }

        #endregion
    }
    #endregion

    #region ListView Xaml property settings including an interface
    interface IListViewColourProps : IUIBaseColourProperties
    {
        SolidColorBrush listViewBorderBackground { get; set; }
        SolidColorBrush listViewBorderBrush { get; set; }
        SolidColorBrush listViewContainerBackground { get; set; }
        void GetMainWindowColProps(string thetag);
        void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict);
    }
    internal class ListviewColourProps : UIBaseColourProperties, IListViewColourProps
    {
        #region Fields
        #endregion

        #region Properties
        public SolidColorBrush listViewBorderBackground { get; set; }
        public SolidColorBrush listViewBorderBrush { get; set; }
        public SolidColorBrush listViewContainerBackground { get; set; }
        #endregion

        #region Constructor
        #endregion

        #region methods
        public override void GetMainWindowColProps(string thetag)
        {
            //Uses the base method
            base.GetMainWindowColProps(thetag);
        }
        public void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict)
        {
            //Moves to the method used by the Class interface
            ExtractProperties(passeddict);
        }
        private void ExtractProperties(Dictionary<string, SolidColorBrush> allpropertiesdictionary)
        {
            //Extracts the specified properties into the class member properties using linq
            listViewBorderBackground = allpropertiesdictionary.FirstOrDefault(x => x.Key == "_ListViewBorderBackground").Value;
            listViewBorderBrush = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_ListViewBorderBrush").Value;
            listViewContainerBackground = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_ListViewContainerBackground").Value;
        }
        public static IListViewColourProps GetProperties(string thetag)
        {
            //Uses an interface to set a dictionary and then select the required xaml properties.

            //Creates an instance of the interface referenced to the class - extracts the 4 properties
            IListViewColourProps listviewinterface = new ListviewColourProps();

            //Moves to the overidden Method in this class
            listviewinterface.GetMainWindowColProps(thetag);

            //Uses the interface to move to the method passing in a dictionary
            listviewinterface.PathToExtractPropertiesMethod(listviewinterface.Testdictionary);

            //returns the interface with properties set
            return listviewinterface;
        }

        #endregion
    }
    #endregion

    #region Mainwindow Xaml Property setting including Interface
    interface IMainwindowColourProps : IUIBaseColourProperties
    {
        SolidColorBrush mainwindowborderbrush { get; set; }
        SolidColorBrush mainwindowborderbackground { get; set; }
        void GetMainWindowColProps(string thetag);
        void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict);
    }
    internal class MainwindowColourProps : UIBaseColourProperties, IMainwindowColourProps
    {
        #region Fields

        #endregion

        #region Properties
        public SolidColorBrush mainwindowborderbrush { get; set; }
        public SolidColorBrush mainwindowborderbackground { get; set; }
        #endregion

        #region Constructor
        public MainwindowColourProps()
        {
            //Initialises interfaces
            //viewcoloursInterface = new ChangeViewColours();
        }
        #endregion

        #region Methods
        public override void GetMainWindowColProps(string thetag)
        {
            //Moves to the base class implemetation of this method
            base.GetMainWindowColProps(thetag);
        }
        public void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict)
        {
            //Moves to the method used by the Class interface
            ExtractProperties(passeddict);
        }
        private void ExtractProperties(Dictionary<string, SolidColorBrush> allpropertiesdictionary)
        {
            //Extracts the specified properties into the class member properties using linq
            mainwindowborderbrush = allpropertiesdictionary.FirstOrDefault(x => x.Key == "_MainWindowBorderBrush").Value;
            mainwindowborderbackground = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_MainWindowBorderBackground").Value;
        }
        public static IMainwindowColourProps GetProperties(string thetag)
        {
            //Creates an instance of the interface referenced to the class
            IMainwindowColourProps windowinterface = new MainwindowColourProps();

            //Moves to the method to pass values to the viewcolours interface
            //and sets the class member properties
            windowinterface.GetMainWindowColProps(thetag);
            
            //Moves to the method in this class using the interface
            windowinterface.PathToExtractPropertiesMethod(windowinterface.Testdictionary);

            //returns the interface with properties set
            return windowinterface;
        }
        #endregion
    }
    #endregion

    #region Menu Bar Xaml Property settings including Interface
    interface IMenuColoursProps : IUIBaseColourProperties
    {
        SolidColorBrush menuborderbackground { set; get; }
        SolidColorBrush meniItemsforeground { set; get; }
        SolidColorBrush menuitemsborderbrush { set; get; }
        SolidColorBrush menuhighlightforeground { set; get; }
        void GetMainWindowColProps(string thetag);
        void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict);
    }
    interface IGetMainWindow : IUIBaseColourProperties
    {
        void GetMainWindowColProps(string thetag);
        void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict);
    }

    internal class MenuColoursProps : UIBaseColourProperties, IMenuColoursProps//, IGetMainWindow
    {
        #region Fields

        #endregion

        #region Properties
        public SolidColorBrush menuborderbackground { set; get; }
        public SolidColorBrush meniItemsforeground { set; get; }
        public SolidColorBrush menuitemsborderbrush { set; get; }
        public SolidColorBrush menuhighlightforeground { set; get; }
        #endregion

        #region constructor
        public MenuColoursProps()
        {
            //Intialises the viewcolours interface
            //viewcoloursInterface = new ChangeViewColours();
        }
        #endregion

        #region methods
        public override void GetMainWindowColProps(string thetag)
        {
            //Uses the base method
            base.GetMainWindowColProps(thetag);
        }
        public void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict)
        {
            //Moves to the method used by the Class interface
            ExtractProperties(passeddict);
        }
        private void ExtractProperties(Dictionary<string, SolidColorBrush> allpropertiesdictionary)
        {
            //Extracts the specified properties into the class member properties using linq
            menuborderbackground = allpropertiesdictionary.FirstOrDefault(x => x.Key == "_MenuBorderBackGround").Value;
            meniItemsforeground = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_MenuItemsForeground").Value;
            menuitemsborderbrush = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_MenuItemsBorderBrush").Value;
            menuhighlightforeground = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_MenuHighlightForeground").Value;
        }
        public static IMenuColoursProps GetProperties(string thetag)
        {
            //Uses an interface to set a dictionary and then select the required xaml properties.

            //Creates an instance of the interface referenced to the class - extracts the 4 properties
            IMenuColoursProps windowinterface = new MenuColoursProps();
            //IGetMainWindow getbasecoloursinterface = new MenuColoursProps();

            //Moves to the overidden Method in this class
                windowinterface.GetMainWindowColProps(thetag);
                //getbasecoloursinterface.GetMainWindowColProps(thetag);

            //Uses the interface to move to the method passing in a dictionary
                windowinterface.PathToExtractPropertiesMethod(windowinterface.Testdictionary);
                //getbasecoloursinterface.PathToExtractPropertiesMethod(getbasecoloursinterface.Testdictionary);

            //returns the interface with properties set
            return windowinterface;
        }

        #endregion
    }
    #endregion

    #region StatusBar Xaml property settings including interface
    interface IStatusBarColourProps : IUIBaseColourProperties
    {
        SolidColorBrush statusBarBorderBackground { get; set; }
        void GetMainWindowColProps(string thetag);
        void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict);
    }
    internal class StatusBarColourProps : UIBaseColourProperties, IStatusBarColourProps
    {
        #region Fields
        #endregion

        #region Properties
        public SolidColorBrush statusBarBorderBackground { get; set; }
        #endregion

        #region Constructor
        public StatusBarColourProps()
        {
            //no code
        }
        #endregion

        #region methods
        public override void GetMainWindowColProps(string thetag)
        {
            //Uses the base method
            base.GetMainWindowColProps(thetag);
        }
        public void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict)
        {
            //Moves to the method used by the Class interface
            ExtractProperties(passeddict);
        }
        private void ExtractProperties(Dictionary<string, SolidColorBrush> allpropertiesdictionary)
        {
            //Extracts the specified properties into the class member properties using linq
            statusBarBorderBackground = allpropertiesdictionary.FirstOrDefault(x => x.Key == "_StatusBarBorderBackground").Value;
        }
        public static IStatusBarColourProps GetProperties(string thetag)
        {
            //Uses an interface to set a dictionary and then select the required xaml properties.

            //Creates an instance of the interface referenced to the class - extracts the 4 properties
            IStatusBarColourProps statusbarinterface = new StatusBarColourProps();

            //Moves to the overidden Method in this class
            statusbarinterface.GetMainWindowColProps(thetag);

            //Uses the interface to move to the method passing in a dictionary
            statusbarinterface.PathToExtractPropertiesMethod(statusbarinterface.Testdictionary);

            //returns the interface with properties set
            return statusbarinterface;
        }

        #endregion
    }
    #endregion

    #region TextBox Xaml Property settings including an interface
    interface ITextBoxColoursProps : IUIBaseColourProperties
    {
        SolidColorBrush textBoxBorderBrush { get; set; }
        SolidColorBrush textBoxBorderBackground { get; set; }
        void GetMainWindowColProps(string thetag);
        void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict);
    }
    internal class TextBoxColoursProps : UIBaseColourProperties, ITextBoxColoursProps
    {
        #region Fields
        #endregion

        #region Constructor
        public TextBoxColoursProps()
        {
            //no code
        }
        #endregion

        #region Properties
        public SolidColorBrush textBoxBorderBackground { get; set; }
        public SolidColorBrush textBoxBorderBrush { get; set; }
        #endregion

        #region Methods
        public override void GetMainWindowColProps(string thetag)
        {
            //Uses the base method
            base.GetMainWindowColProps(thetag);
        }
        public void PathToExtractPropertiesMethod(Dictionary<string, SolidColorBrush> passeddict)
        {
            //Moves to the method used by the Class interface
            ExtractProperties(passeddict);
        }
        private void ExtractProperties(Dictionary<string, SolidColorBrush> allpropertiesdictionary)
        {
            //Extracts the specified properties into the class member properties using linq
            textBoxBorderBackground = allpropertiesdictionary.FirstOrDefault(x => x.Key == "_TextBoxBorderBackground").Value;
            textBoxBorderBrush = allpropertiesdictionary.FirstOrDefault(y => y.Key == "_TextBoxBorderBrush").Value;
        }
        public static ITextBoxColoursProps GetProperties(string thetag)
        {
            //Uses an interface to set a dictionary and then select the required xaml properties.

            //Creates an instance of the interface referenced to the class - extracts the 4 properties
            ITextBoxColoursProps textboxinterface = new TextBoxColoursProps();

            //Moves to the overidden Method in this class
            textboxinterface.GetMainWindowColProps(thetag);

            //Uses the interface to move to the method passing in a dictionary
            textboxinterface.PathToExtractPropertiesMethod(textboxinterface.Testdictionary);

            //returns the interface with properties set
            return textboxinterface;
        }

        #endregion
    }
    #endregion

}