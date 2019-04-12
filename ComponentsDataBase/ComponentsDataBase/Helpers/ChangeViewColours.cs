using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace ComponentsDataBase.Helpers
{
    public interface IChangeViewColours
    {
        Dictionary<string, SolidColorBrush> ColourDictionaryChangeEntry(string whichcolour);
    }
    internal class ChangeViewColours : IChangeViewColours
    {
        //Changes the colours for the screen UI skins

        #region Fields
        private ColourSkin thecolourskinlist;
        #endregion

        #region Methods
        public Dictionary<string,SolidColorBrush> ColourDictionaryChangeEntry(string whichcolour)
        {
            //ecapsulates the background colour selector
            InitialiseColoursData();
            //Checks for nulls in the list before execution
            thecolourskinlist.CheckForNulls();
            //returns the colour as a dictionary to the caller
            
            return thecolourskinlist.ReturnTheSkinDictionary(whichcolour);
        }
        private void InitialiseColoursData()
        {
            //ensures that the colourskin class is initialised properly
            if(thecolourskinlist == null)
            {
                //assigns the colourskin class object to the variable
                thecolourskinlist = new ColourSkin();
            } 
        }

        #endregion

    }
    internal class ColourSkin
    {
        //Simple class for storing the colour collections
        //Has definitions for each skin type
        //changes a group of controls to a set skin coulour selectable
        //from the main menu
        //each property is then changed to its colour skin selected

        #region Fields
        //dictionaries
        private Dictionary<string, Dictionary<string, SolidColorBrush>> DictionaryOfSkins = new Dictionary<string, Dictionary<string,SolidColorBrush>>();
        private Dictionary<string, int> SkinIndexer = new Dictionary<string, int>();
        private Dictionary<string, SolidColorBrush> BiegeSkin = new Dictionary<string, SolidColorBrush>();
        private Dictionary<string, SolidColorBrush> DarkSkin = new Dictionary<string, SolidColorBrush>();
        private Dictionary<string, SolidColorBrush> MistralBlueSkin = new Dictionary<string, SolidColorBrush>();
        private Dictionary<string, SolidColorBrush> RadiantVioletSkin = new Dictionary<string, SolidColorBrush>();
        private Dictionary<string, SolidColorBrush> SalmonSkin = new Dictionary<string, SolidColorBrush>();
        private Dictionary<string, SolidColorBrush> SilverSkin = new Dictionary<string, SolidColorBrush>();
        private Dictionary<string, SolidColorBrush> SoftGreenSkin = new Dictionary<string, SolidColorBrush>();
        private Dictionary<string, SolidColorBrush> WoodySkin = new Dictionary<string, SolidColorBrush>();
        #endregion

        #region Properties
        //Xaml properties for the skin - not used
        private SolidColorBrush _MainWindowBorderBrush { get; set; }
        private SolidColorBrush _MainWindowBorderBackground { get; set; }
        private SolidColorBrush _ListViewBorderBackground { get; set; }
        private SolidColorBrush _ListViewBorderBrush { get; set; }
        private SolidColorBrush _ListViewContainerBackground { get; set; }
        private SolidColorBrush _MenuBorderBackGround { get; set; }
        private SolidColorBrush _MenuItemsForeground { get; set; }
        private SolidColorBrush _MenuItemsBorderBrush { get; set; }
        private SolidColorBrush _MenuHighlightForeground { get; set; }
        private SolidColorBrush _TextBoxBorderBrush { get; set; }
        private SolidColorBrush _TextBoxBorderBackground { get; set; }
        private SolidColorBrush _EllipseStroke { get; set; }
        private SolidColorBrush _ButtonMouseOverForeground { get; set; }
        private SolidColorBrush _ButtonIsPressStroke { get; set; }
        private SolidColorBrush _StatusBarBorderBackground { get; set; }
        private SolidColorBrush _EllipseGradientStopColour1 { get; set; }
        private SolidColorBrush _EllipseGradientStopColour2 { get; set; }
        #endregion

        #region Methods
        public void CheckForNulls()
        {
            if(DictionaryOfSkins.Count <=0)
            {
                Createlist();
            }
            else
            {
                return;
            }
        }
        public Dictionary<string,SolidColorBrush> ReturnTheSkinDictionary(string theskin)
        {
            //returns a list of solidcolourbrush objects
            if (theskin !=null)
            {
                //extracts the correct dictionary from the dictonary collection and returns it to the caller
                foreach (KeyValuePair<string, Dictionary<string,SolidColorBrush>> skin in DictionaryOfSkins)
                {
                    if (skin.Key == theskin)
                    {
                        return skin.Value;
                    }
                }
            }
            //default return an empty list object- needs correcting
            return BiegeSkin;

        }
        private void Createlist()
        {
            //creates all of the colour skins
            #region Biege Skin
            //creates a test dictionary object for future use
            BiegeSkin.Add("_MainWindowBorderBrush", new SolidColorBrush(Colors.BurlyWood));
            BiegeSkin.Add("_MainWindowBorderBackground", new SolidColorBrush(Colors.White));
            BiegeSkin.Add("_ListViewBorderBackground", new SolidColorBrush(Colors.Beige));
            BiegeSkin.Add("_ListViewBorderBrush", new SolidColorBrush(Colors.BurlyWood));
            BiegeSkin.Add("_ListViewContainerBackground", new SolidColorBrush(Colors.White));
            BiegeSkin.Add("_MenuBorderBackGround", new SolidColorBrush(Colors.Beige));
            BiegeSkin.Add("_MenuHighlightForeground", new SolidColorBrush(Colors.White));
            BiegeSkin.Add("_MenuItemsBorderBrush", new SolidColorBrush(Colors.Silver));
            BiegeSkin.Add("_MenuItemsForeground", new SolidColorBrush(Colors.Black));
            BiegeSkin.Add("_TextBoxBorderBrush", new SolidColorBrush(Colors.BurlyWood));
            BiegeSkin.Add("_TextBoxBorderBackground", new SolidColorBrush(Colors.Beige));
            BiegeSkin.Add("_EllipseStroke", new SolidColorBrush(Colors.SandyBrown));
            BiegeSkin.Add("_ButtonMouseOverForeground", new SolidColorBrush(Colors.White));
            BiegeSkin.Add("_ButtonIsPressStroke",new SolidColorBrush(Colors.SandyBrown));
            BiegeSkin.Add("_StatusBarBorderBackground", new SolidColorBrush(Colors.Beige));
            BiegeSkin.Add("_EllipseGradientStopColour1", new SolidColorBrush(Colors.BurlyWood));
            BiegeSkin.Add("_EllipseGradientStopColour2", new SolidColorBrush(Colors.Beige));
              
            //ads the single dictionary to a list of dictionaries
            DictionaryOfSkins.Add("BiegeSkin", BiegeSkin);
            #endregion

            #region Dark skin
            DarkSkin.Add("_MainWindowBorderBrush", new SolidColorBrush(Colors.DarkGray));
            DarkSkin.Add("_MainWindowBorderBackground", new SolidColorBrush(Colors.White));
            DarkSkin.Add("_ListViewBorderBackground", new SolidColorBrush(Colors.DarkGray));
            DarkSkin.Add("_ListViewBorderBrush", new SolidColorBrush(Colors.DarkSlateGray));
            DarkSkin.Add("_ListViewContainerBackground", new SolidColorBrush(Colors.DarkGray));
            DarkSkin.Add("_MenuBorderBackGround", new SolidColorBrush(Colors.DarkGray));
            DarkSkin.Add("_MenuHighlightForeground", new SolidColorBrush(Colors.White));
            DarkSkin.Add("_MenuItemsBorderBrush", new SolidColorBrush(Colors.Silver));
            DarkSkin.Add("_MenuItemsForeground", new SolidColorBrush(Colors.Black));
            DarkSkin.Add("_TextBoxBorderBrush", new SolidColorBrush(Colors.Black));
            DarkSkin.Add("_TextBoxBorderBackground", new SolidColorBrush(Colors.Silver));
            DarkSkin.Add("_EllipseStroke", new SolidColorBrush(Colors.DarkSlateGray));
            DarkSkin.Add("_ButtonMouseOverForeground", new SolidColorBrush(Colors.White));
            DarkSkin.Add("_ButtonIsPressStroke", new SolidColorBrush(Colors.DarkSlateGray));
            DarkSkin.Add("_StatusBarBorderBackground", new SolidColorBrush(Colors.DarkGray));
            DarkSkin.Add("_EllipseGradientStopColour1", new SolidColorBrush(Colors.Gray));
            DarkSkin.Add("_EllipseGradientStopColour2", new SolidColorBrush(Colors.LightGray));
            
            //ads the single dictionary to a list of dictionaries
            DictionaryOfSkins.Add("DarkSkin", DarkSkin);
            #endregion

            #region MistralBlue Skin
            MistralBlueSkin.Add("_MainWindowBorderBrush", new SolidColorBrush(Colors.LightBlue));
            MistralBlueSkin.Add("_MainWindowBorderBackground", new SolidColorBrush(Colors.White));
            MistralBlueSkin.Add("_ListViewBorderBackground", new SolidColorBrush(Colors.AliceBlue));
            MistralBlueSkin.Add("_ListViewBorderBrush", new SolidColorBrush(Colors.LightBlue));
            MistralBlueSkin.Add("_ListViewContainerBackground", new SolidColorBrush(Colors.White));
            MistralBlueSkin.Add("_MenuBorderBackGround", new SolidColorBrush(Colors.LightBlue));
            MistralBlueSkin.Add("_MenuHighlightForeground", new SolidColorBrush(Colors.White));
            MistralBlueSkin.Add("_MenuItemsBorderBrush", new SolidColorBrush(Colors.AliceBlue));
            MistralBlueSkin.Add("_MenuItemsForeground", new SolidColorBrush(Colors.Navy));
            MistralBlueSkin.Add("_TextBoxBorderBrush", new SolidColorBrush(Colors.LightBlue));
            MistralBlueSkin.Add("_TextBoxBorderBackground", new SolidColorBrush(Colors.AliceBlue));
            MistralBlueSkin.Add("_EllipseStroke", new SolidColorBrush(Colors.LightBlue));
            MistralBlueSkin.Add("_ButtonMouseOverForeground", new SolidColorBrush(Colors.White));
            MistralBlueSkin.Add("_ButtonIsPressStroke", new SolidColorBrush(Colors.LightBlue));
            MistralBlueSkin.Add("_StatusBarBorderBackground", new SolidColorBrush(Colors.LightBlue));
            MistralBlueSkin.Add("_EllipseGradientStopColour1", new SolidColorBrush(Colors.LightBlue));
            MistralBlueSkin.Add("_EllipseGradientStopColour2", new SolidColorBrush(Colors.White));

            //ads the single dictionary to a list of dictionaries
            DictionaryOfSkins.Add("MistralBlueSkin", MistralBlueSkin);
            #endregion

            #region RadiantViolet
            RadiantVioletSkin.Add("_MainWindowBorderBrush", new SolidColorBrush(Colors.Orchid));
            RadiantVioletSkin.Add("_MainWindowBorderBackground", new SolidColorBrush(Colors.White));
            RadiantVioletSkin.Add("_ListViewBorderBackground", new SolidColorBrush(Colors.MediumOrchid));
            RadiantVioletSkin.Add("_ListViewBorderBrush", new SolidColorBrush(Colors.Magenta));
            RadiantVioletSkin.Add("_ListViewContainerBackground", new SolidColorBrush(Colors.White));
            RadiantVioletSkin.Add("_MenuBorderBackGround", new SolidColorBrush(Colors.Orchid));
            RadiantVioletSkin.Add("_MenuHighlightForeground", new SolidColorBrush(Colors.White));
            RadiantVioletSkin.Add("_MenuItemsBorderBrush", new SolidColorBrush(Colors.Silver));
            RadiantVioletSkin.Add("_MenuItemsForeground", new SolidColorBrush(Colors.DarkMagenta));
            RadiantVioletSkin.Add("_TextBoxBorderBrush", new SolidColorBrush(Colors.Magenta));
            RadiantVioletSkin.Add("_TextBoxBorderBackground", new SolidColorBrush(Colors.Orchid));
            RadiantVioletSkin.Add("_EllipseStroke", new SolidColorBrush(Colors.Silver));
            RadiantVioletSkin.Add("_ButtonMouseOverForeground", new SolidColorBrush(Colors.White));
            RadiantVioletSkin.Add("_ButtonIsPressStroke", new SolidColorBrush(Colors.DarkMagenta));
            RadiantVioletSkin.Add("_StatusBarBorderBackground", new SolidColorBrush(Colors.Orchid));
            RadiantVioletSkin.Add("_EllipseGradientStopColour1", new SolidColorBrush(Colors.Fuchsia));
            RadiantVioletSkin.Add("_EllipseGradientStopColour2", new SolidColorBrush(Colors.LightCyan));

            //ads the single dictionary to a list of dictionaries
            DictionaryOfSkins.Add("RadiantVioletSkin", RadiantVioletSkin);
            #endregion

            #region Salmon skin
            SalmonSkin.Add("_MainWindowBorderBrush",new SolidColorBrush(Colors.DarkSalmon));
            SalmonSkin.Add("_MainWindowBorderBackground", new SolidColorBrush(Colors.White));
            SalmonSkin.Add("_ListViewBorderBackground", new SolidColorBrush(Colors.SeaShell));
            SalmonSkin.Add("_ListViewBorderBrush", new SolidColorBrush(Colors.Coral));
            SalmonSkin.Add("_ListViewContainerBackground", new SolidColorBrush(Colors.White));
            SalmonSkin.Add("_MenuBorderBackGround", new SolidColorBrush(Colors.DarkSalmon));
            SalmonSkin.Add("_MenuHighlightForeground", new SolidColorBrush(Colors.White));
            SalmonSkin.Add("_MenuItemsBorderBrush", new SolidColorBrush(Colors.Silver));
            SalmonSkin.Add("_MenuItemsForeground", new SolidColorBrush(Colors.DarkRed));
            SalmonSkin.Add("_TextBoxBorderBrush", new SolidColorBrush(Colors.DarkSalmon));
            SalmonSkin.Add("_TextBoxBorderBackground", new SolidColorBrush(Colors.SeaShell));
            SalmonSkin.Add("_EllipseStroke",new SolidColorBrush(Colors.Silver));
            SalmonSkin.Add("_ButtonMouseOverForeground", new SolidColorBrush(Colors.White));
            SalmonSkin.Add("_ButtonIsPressStroke", new SolidColorBrush(Colors.DarkSalmon));
            SalmonSkin.Add("_StatusBarBorderBackground", new SolidColorBrush(Colors.DarkSalmon));
            SalmonSkin.Add("_EllipseGradientStopColour1", new SolidColorBrush(Colors.DarkSalmon));
            SalmonSkin.Add("_EllipseGradientStopColour2", new SolidColorBrush(Colors.White));

            //ads the single dictionary to a list of dictionaries
            DictionaryOfSkins.Add("SalmonSkin", SalmonSkin);
            #endregion

            #region Silver skin
            SilverSkin.Add("_MainWindowBorderBrush", new SolidColorBrush(Colors.DarkGray));
            SilverSkin.Add("_MainWindowBorderBackground", new SolidColorBrush(Colors.White));
            SilverSkin.Add("_ListViewBorderBackground", new SolidColorBrush(Colors.LightGray));
            SilverSkin.Add("_ListViewBorderBrush", new SolidColorBrush(Colors.DarkGray));
            SilverSkin.Add("_ListViewContainerBackground", new SolidColorBrush(Colors.White));
            SilverSkin.Add("_MenuBorderBackGround", new SolidColorBrush(Colors.Silver));
            SilverSkin.Add("_MenuHighlightForeground", new SolidColorBrush(Colors.White));
            SilverSkin.Add("_MenuItemsBorderBrush", new SolidColorBrush(Colors.Silver));
            SilverSkin.Add("_MenuItemsForeground",new SolidColorBrush(Colors.Black));
            SilverSkin.Add("_TextBoxBorderBrush",new SolidColorBrush(Colors.DarkGray));
            SilverSkin.Add("_TextBoxBorderBackground", new SolidColorBrush(Colors.LightGray));
            SilverSkin.Add("_EllipseStroke", new SolidColorBrush(Colors.Silver));
            SilverSkin.Add("_ButtonMouseOverForeground", new SolidColorBrush(Colors.White));
            SilverSkin.Add("_ButtonIsPressStroke", new SolidColorBrush(Colors.Silver));
            SilverSkin.Add("_StatusBarBorderBackground", new SolidColorBrush(Colors.Silver));
            SilverSkin.Add("_EllipseGradientStopColour1", new SolidColorBrush(Colors.Silver));
            SilverSkin.Add("_EllipseGradientStopColour2", new SolidColorBrush(Colors.White));

            //ads the single dictionary to a list of dictionaries
            DictionaryOfSkins.Add("SilverSkin", SilverSkin);
            #endregion

            #region Softgreen skin
            SoftGreenSkin.Add("_MainWindowBorderBrush", new SolidColorBrush(Colors.DarkSeaGreen));
            SoftGreenSkin.Add("_MainWindowBorderBackground", new SolidColorBrush(Colors.White));
            SoftGreenSkin.Add("_ListViewBorderBackground", new SolidColorBrush(Colors.LightGreen));
            SoftGreenSkin.Add("_ListViewBorderBrush",new SolidColorBrush(Colors.DarkSeaGreen));
            SoftGreenSkin.Add("_ListViewContainerBackground", new SolidColorBrush(Colors.White));
            SoftGreenSkin.Add("_MenuBorderBackGround", new SolidColorBrush(Colors.MediumSeaGreen));
            SoftGreenSkin.Add("_MenuHighlightForeground", new SolidColorBrush(Colors.White));
            SoftGreenSkin.Add("_MenuItemsBorderBrush", new SolidColorBrush(Colors.Silver));
            SoftGreenSkin.Add("_MenuItemsForeground", new SolidColorBrush(Colors.Black));
            SoftGreenSkin.Add("_TextBoxBorderBrush",new SolidColorBrush(Colors.DarkSeaGreen));
            SoftGreenSkin.Add("_TextBoxBorderBackground", new SolidColorBrush(Colors.LightGreen));
            SoftGreenSkin.Add("_EllipseStroke",new SolidColorBrush(Colors.Silver));
            SoftGreenSkin.Add("_ButtonMouseOverForeground", new SolidColorBrush(Colors.White));
            SoftGreenSkin.Add("_ButtonIsPressStroke",new SolidColorBrush(Colors.Silver));
            SoftGreenSkin.Add("_StatusBarBorderBackground", new SolidColorBrush(Colors.MediumSeaGreen));
            SoftGreenSkin.Add("_EllipseGradientStopColour1", new SolidColorBrush(Colors.SeaGreen));
            SoftGreenSkin.Add("_EllipseGradientStopColour2", new SolidColorBrush(Colors.White));

            //ads the single dictionary to a list of dictionaries
            DictionaryOfSkins.Add("SoftGreenSkin", SoftGreenSkin);
            #endregion           

            #region Woody skin
            WoodySkin.Add("_MainWindowBorderBrush", new SolidColorBrush(Colors.Tan));
            WoodySkin.Add("_MainWindowBorderBackground", new SolidColorBrush(Colors.White));
            WoodySkin.Add("_ListViewBorderBackground", new SolidColorBrush(Colors.Bisque));
            WoodySkin.Add("_ListViewBorderBrush", new SolidColorBrush(Colors.Silver));
            WoodySkin.Add("_ListViewContainerBackground", new SolidColorBrush(Colors.White));
            WoodySkin.Add("_MenuBorderBackGround",new SolidColorBrush(Colors.Tan));
            WoodySkin.Add("_MenuHighlightForeground", new SolidColorBrush(Colors.White));
            WoodySkin.Add("_MenuItemsBorderBrush", new SolidColorBrush(Colors.Silver));
            WoodySkin.Add("_MenuItemsForeground", new SolidColorBrush(Colors.Black));
            WoodySkin.Add("_TextBoxBorderBrush", new SolidColorBrush(Colors.SaddleBrown));
            WoodySkin.Add("_TextBoxBorderBackground", new SolidColorBrush(Colors.Bisque));
            WoodySkin.Add("_EllipseStroke", new SolidColorBrush(Colors.Silver));
            WoodySkin.Add("_ButtonMouseOverForeground", new SolidColorBrush(Colors.White));
            WoodySkin.Add("_ButtonIsPressStroke", new SolidColorBrush(Colors.Silver));
            WoodySkin.Add("_StatusBarBorderBackground", new SolidColorBrush(Colors.Tan));
            WoodySkin.Add("_EllipseGradientStopColour1", new SolidColorBrush(Colors.Tan));
            WoodySkin.Add("_EllipseGradientStopColour2", new SolidColorBrush(Colors.SaddleBrown));

            //ads the single dictionary to a list of dictionaries
            DictionaryOfSkins.Add("WoodySkin", WoodySkin);
            #endregion

            CreateSkinIndexer();
        }
        private void CreateSkinIndexer()
        {
            //creates a dictionary of enums
            SkinIndexer.Add("BiegeSkin", (int)Skinidexnumber.BeigeSkin);
            SkinIndexer.Add("DarkSkin", (int)Skinidexnumber.DarkSkin);
            SkinIndexer.Add("MistralBlueSkin", (int)Skinidexnumber.MistralBlueSkin);
            SkinIndexer.Add("RadiantVioletSkin", (int)Skinidexnumber.RadiantVioletSkin);
            SkinIndexer.Add("SalmonSkin", (int)Skinidexnumber.SalmonSkin);
            SkinIndexer.Add("SilverSkin", (int)Skinidexnumber.SilverSkin);
            SkinIndexer.Add("SoftGreenSkin", (int)Skinidexnumber.SoftGreenSkin);
            SkinIndexer.Add("WoodySkin", (int)Skinidexnumber.WoodySkin);
            
        }
        #endregion

        #region enum
        private enum Skinidexnumber 
        {
            BeigeSkin = 0,
            DarkSkin = 1,
            MistralBlueSkin = 2,
            RadiantVioletSkin = 3,
            SalmonSkin = 4,
            SilverSkin = 5,
            SoftGreenSkin = 6,
            WoodySkin = 7
        }
        #endregion

        #region UnusedCode
        private void UnusedCode()
        {
            //SkinColours.Add( new ColourSkin
            //{
            //    _MainWindowBorderBrush = new SolidColorBrush(Colors.Silver),
            //    _MainWindowBorderBackground = new SolidColorBrush(Colors.White),
            //    _ListViewBorderBackground = new SolidColorBrush(Colors.Black),
            //    _ListViewBorderBrush = new SolidColorBrush(Colors.Silver),
            //    _ListViewContainerBackground = new SolidColorBrush(Colors.White),
            //    _MenuBorderBackGround = new SolidColorBrush(Colors.Black),
            //    _MenuHighlightForeground = new SolidColorBrush(Colors.White),
            //    _MenuItemsBorderBrush = new SolidColorBrush(Colors.Silver),
            //    _MenuItemsForeground = new SolidColorBrush(Colors.Black),
            //    _TextBoxBorderBrush = new SolidColorBrush(Colors.Black),
            //    _TextBoxBorderBackground = new SolidColorBrush(Colors.Silver),
            //    _EllipseStroke = new SolidColorBrush(Colors.Silver),
            //    _ButtonMouseOverForeground = new SolidColorBrush(Colors.White),
            //    _ButtonIsPressStroke = new SolidColorBrush(Colors.Silver),
            //    _StatusBarBorderBackground = new SolidColorBrush(Colors.Black)
            //});


        }
        #endregion
    }
}
