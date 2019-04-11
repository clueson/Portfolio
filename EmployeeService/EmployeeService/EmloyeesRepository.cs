using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls.Ribbon.Primitives;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class EmployeesRepository
    {
        #region Methods
        public static List<Employees> GetEmployees()
        {
            EmployeeDataContainer emp = new EmployeeDataContainer();
            return emp.Employee.ToList();
        }
        public static void PreloadData()
        {
            //initialises the dbcontext object
            EmployeeDataContainer e = new EmployeeDataContainer();

            if(e.Employee.Count().Equals(0))
            {
                //adds records to the db context
                e.Employee.Add(new Employees { Id = 0, Name = "robert", Gender = "male",  Birthday = new DateTime(1978, 6, 15) });
                e.Employee.Add(new Employees { Id = 0, Name = "denise", Gender = "female", Birthday = new DateTime(1975, 1, 23) });
                e.Employee.Add(new Employees { Id = 0, Name = "robert", Gender = "male", Birthday = new DateTime(1988, 3, 21) });
                e.Employee.Add(new Employees { Id = 0, Name = "sally", Gender = "female", Birthday = new DateTime(1979, 2, 5) } );

                //saves changes to the data base
                e.SaveChanges();
            }
        }
        public static void AddData(Employees emp)
        {
            EmployeeDataContainer e = new EmployeeDataContainer();
            e.Employee.Add(emp);
            e.SaveChanges();
        }
        public static Employees FindEmployee(int id)
        {
            //find the record
            EmployeeDataContainer e = new EmployeeDataContainer();
            Employees foundperson = e.Employee.FirstOrDefault(x => x.Id == id);

            //returns the found record
            return foundperson;
        }
        #endregion
    }
}
