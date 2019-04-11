using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloName
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RunApp();
        }

        #region Methods
        private void RunApp()
        {
            tbxName.Focus();
            tbxName.SelectAll();
            bdrScrollViewer.Visibility = Visibility.Hidden;
            srvErrorMessage.Visibility = Visibility.Hidden;
            tbxErrorMessage.Visibility = Visibility.Hidden;
            lblErrorMessage.Visibility = Visibility.Hidden;
        }
        private string ChangeFirstLetterToUpper(string lowercasestring)
        {
            //creates a character array
            char[] letters = lowercasestring.ToCharArray();
            
            //ternary condition if first character in the array is lower then change to upper, and vice versa
            letters[0] = char.IsUpper(letters[0]) ? char.ToLower(letters[0]) : char.ToUpper(letters[0]);
            
            //returns the converted char[] as a string
            return new string(letters );
        }
        private void SendMessageToService(string fromtextbox)
        {
            try
            {
                //initialises the client to send an receive a message
                ServiceReference1.HelloServiceClient clientservice = new ServiceReference1.HelloServiceClient();

                //asigns the textblock the value recived from the WCF service host.
                tbkMessage.Text = clientservice.GetMessage(fromtextbox);

                //Closes the service
                clientservice.Close();
            }
            catch (Exception e)
            {
                //enables the controls to be visible
                bdrScrollViewer.Visibility = Visibility.Visible;
                srvErrorMessage.Visibility = Visibility.Visible;
                tbxErrorMessage.Visibility = Visibility.Visible;
                lblErrorMessage.Visibility = Visibility.Visible;

                //sets the textwrapping
                tbxErrorMessage.TextWrapping = TextWrapping.Wrap;

                //assigns the the error message to the control
                tbxErrorMessage.Text = e.Message;
            }
        }
        #endregion

        #region Events
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Sends the text to the firstletter upper checker method and then onto the service
            SendMessageToService(ChangeFirstLetterToUpper(tbxName.Text));
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Closes the application
            App.Current.Shutdown();
        }
        #endregion
    }
}
