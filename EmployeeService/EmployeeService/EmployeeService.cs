using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    //adding a message contract to alter the soap message envelope and header/body content on the post request
    [MessageContract(IsWrapped = true, WrapperName = "EmployeeRequestObject", WrapperNamespace = "http://mycompany.com/Employee")]
    public class EmployeeRequest
    {
        [MessageHeader(Namespace = "http://mycompany.com/Employee")]
        public string LicenseKey { get; set; }
        [MessageBodyMember(Namespace = "http://mycompany.com/Employee")]
        public int EmployeeId { get; set; }
    }

    [MessageContract (IsWrapped = true, WrapperName = "EmployeeInfoObject", WrapperNamespace = "http://mycompany.com/Employee")]
    public class EmployeeInfo
    {
        //This is for the soap response message get request
        public EmployeeInfo()
        {
            
        }

        public EmployeeInfo(Employees employees)
        {
            this.Id = employees.Id;
            this.Name = employees.Name;
            this.Gender = employees.Gender;
            this.Birthday = employees.Birthday;
        }

        [MessageBodyMember (Namespace = "http://mycompany.com/Employee")]
        public int Id { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee")]
        public string Name { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee")]
        public string Gender { get; set; }

        [MessageBodyMember(Namespace = "http://mycompany.com/Employee")]
        public DateTime Birthday { get; set; }

    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {
        //implements the service contracts via the interface
        public List<Employees> GetEmployee()
        {
            //returns from the database all of the employees as a list
            return EmployeesRepository.GetEmployees();
        }
        public Employees FindEmployee(int id)
        {
            //returns the employee
            return EmployeesRepository.FindEmployee(id);
        }
        public void SaveEmployee(Employees employee)
        {
            //Saves the employee object to the database
            EmployeeDataContainer em = new EmployeeDataContainer();
            em.Employee.Add(employee);
            em.SaveChanges();
        }
        public void UpdateEmployee(Employees employee)
        {
            //finds the record from the db context class
            EmployeeDataContainer em = new EmployeeDataContainer();

            //assigns an "Employee object to the variable
            //and applies the ext method find by "employee id"
            //extracting a single record.
            Employees person = em.Employee.Find(employee.Id);
            
            //Use the repository version!
            //Employees person = EmployeesRepository.FindEmployee(employee.Id);

            //assigns the new variable to the properties passed in
            //person.Id = employee.Id;
            person.Name = employee.Name;
            person.Gender = employee.Gender;
            person.Birthday = employee.Birthday;

            //Saves the changees back to the database
            em.SaveChanges();

        }
    }
}
