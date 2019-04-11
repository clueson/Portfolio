using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace EmployeeBrowserApp
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        #region Fields
        private ServiceReference2.EmployeeServiceClient theservice;
        #endregion

        #region Constructor
        public Page1()
        {
            InitializeComponent();
            theservice = CreateEmployeeService();
            DisplayAllRecords(theservice);
            SetTheFocus();
        }
        #endregion

        #region Events
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceReference1.HelloServiceClient service = new ServiceReference1.HelloServiceClient();
                tlxTheResult.Text = service.GetMessage(tbxNames.Text);
            }
            catch (Exception error)
            {
                string errmessage = error.Message;
            }
            finally
            {
                //code should go here

            }

        }
        private void tbxEmplyeeid_TextChanged(object sender, TextChangedEventArgs e)
        {
            //creates a variable of int
            int id;

            //validates the input, silently fails if not a number - error should be dealt with!
            int.TryParse(tbxEmplyeeid.Text, out id);

            //moves to the method passing a client service and the Id number
            DisplaySelectedId(theservice, id);
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            theservice.Close();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            theservice.Close();
        }
        private void btnUpdateData_Click(object sender, RoutedEventArgs e)
        {
            AddToDataBase();
        }
        private void btnStartService_Click(object sender, RoutedEventArgs e)
        {
            theservice = CreateEmployeeService();
            DisplayAllRecords(theservice);
        }
        private void btnEditData_Click(object sender, RoutedEventArgs e)
        {
            //Moves to the method to save the edited data
            UpdateDataBase();
        }
        private void dgdEmployeeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (object emp in e.AddedItems)
            //{
            //    //this is one alternative to handling the selected items
            //    //the other is the "ExtractIndexOfSelection" method, heavier but better
            //    //tbxEmplyeeid.Text = (dgdEmployeeTable.SelectedIndex +1).ToString();
            //    //DisplaySelectedId(theservice, dgdEmployeeTable.SelectedIndex-1);
            //    ExtractIndexOfSelection(e);
            //}
            ExtractIndexOfSelection(e);
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Moves to the methods
            UpdateDataBase();
        }
        #endregion

        #region Methods
        private ServiceReference2.EmployeeServiceClient CreateEmployeeService()
        {
            //creates a client service to connect to the WCF host service
            ServiceReference2.EmployeeServiceClient service = new ServiceReference2.EmployeeServiceClient();

            //returns to service to the caller
            return service;
        }
        private void DisplayAllRecords(ServiceReference2.EmployeeServiceClient service)
        {
            try
            {
                //connects to the WCF host service to extract data from the database
                dgdEmployeeTable.ItemsSource = from employee in service.GetEmployee()
                                               select new
                                               {
                                                   Id = employee.Id,
                                                   Name = employee.Name,
                                                   Gender = employee.Gender,
                                                   Date = employee.Birthday.ToShortDateString(),
                                                   //ExtensionData = employee.ExtensionData.GetType().Name,
                                               };
                DisablesCancelButton();
            }
            catch (Exception error)
            {
                //stores an error message for further diagnostics
                string errmessage = error.Message;
            }
            finally
            {
                //code should go here
            }

        }
        private void DisplaySelectedId(ServiceReference2.EmployeeServiceClient service, int id)
        {
            try
            {
                //uses the connection to the WCF host service to extract data from the database
                dgdEmployeeTable.ItemsSource = from employee in service.GetEmployee()
                                               where employee.Id == id
                                               select new
                                               {
                                                   Id = employee.Id,
                                                   Name = employee.Name,
                                                   Gender = employee.Gender,
                                                   Date = employee.Birthday.ToShortDateString()
                                               };

                //Moves to the form field population method and hides the button
                DisableSaveChangesButton();
                PopulateFormFields();
            }
            catch (Exception error)
            {
                //stores an error message for further diagnostics
                string errmessage = error.Message;
            }
            finally
            {
                //code should go here
            }
        }
        private void UpdateDataBase()
        {
            //Creates an object of employees from the form properties
            //and then connects to the service to update the database

            try
            {
                if (tbxEmplyeeid.Equals(null))
                {
                    tbxEmplyeeid.Text = string.Empty;
                }
                //connects to the service contract and passes the type
                theservice.UpdateEmployee(new ServiceReference2.Employees
                {
                    Id = int.Parse(tbxEmplyeeid.Text),
                    Name = tbxName.Text,
                    Gender = tbxGender.Text,
                    Birthday = Convert.ToDateTime(dpkDateOfBirth.Text)
                });

                //refreshes the datagrid and resets the form controls
                DisplayAllRecords(theservice);
                EnablesSaveChangesButton();
                ClearTextBoxes();
            }
            catch (Exception e)
            {
                string errormessage = e.Message;
                MessageBox.Show("No record to edit! - edit record button pressed in wrong sequence", "Host Error", MessageBoxButton.OK);
                SetTheFocus();
            }
            finally
            {
                //code goes here
            }

        }
        private void DisableSaveChangesButton()
        {
            btnSaveChanges.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Visible;
        }
        private void EnablesSaveChangesButton()
        {
            btnSaveChanges.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Hidden;
        }
        private void DisablesCancelButton()
        {
            btnCancel.Visibility = Visibility.Hidden;
        }
        private void PopulateFormFields()
        {
            //Populates all the form property fields for editing

            //checks the textbox for a value
            if (!string.IsNullOrWhiteSpace(tbxEmplyeeid.Text))
            {
                //extracts the data for the selected id for modyfying
                ServiceReference2.Employees person = theservice.GetEmployee().FirstOrDefault(x => x.Id == int.Parse(tbxEmplyeeid.Text));

                //sets the properties
                tbxName.Text = person.Name;
                tbxGender.Text = person.Gender;
                dpkDateOfBirth.Text = person.Birthday.ToShortDateString();
            }
        }
        private void AddToDataBase()
        {
            try
            {
                //adds the data input from the form to the database using the service connection
                theservice.SaveEmployee(new ServiceReference2.Employees
                {
                    Name = tbxName.Text,
                    Gender = tbxGender.Text,
                    //Will fail on an empty or null value in the field
                    Birthday = Convert.ToDateTime(dpkDateOfBirth.Text),
                });
                DisplayAllRecords(theservice);
                ClearTextBoxes();
            }
            catch(Exception e)
            {
                string errormessage = e.Message;
            }
            finally
            {
                //code here
            }


        }
        private void SetTheFocus()
        {
            //sets the focus to the control
            tbxName.Focus();
            //selects the texbox contents
            tbxName.SelectAll();
        }
        private void ClearTextBoxes()
        {
            tbxName.Text = "Type the name here";
            tbxGender.Text = string.Empty;
            dpkDateOfBirth.Text = string.Empty;
            //tbxEmplyeeid.Text = string.Empty;
            SetTheFocus();
        }
        private void SelectionChangedData(int theindex)
        {
            tbxEmplyeeid.Text = theindex.ToString();
        }
        private void ExtractIndexOfSelection(SelectionChangedEventArgs e)
        {
            //Gets the value within the Ilist object
            foreach (object emp in e.AddedItems)
            {
                var theval = emp.GetType().GetRuntimeProperty("Id").GetValue(emp);
                //calls the method for record editing.
                tbxEmplyeeid.Text = theval.ToString();
                DisplaySelectedId(theservice, Convert.ToInt32(theval));
            }
        }
        #endregion
    }
}
