using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EmployeeServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadData();
            StartService();
        }

        #region Methods
        private static void StartService()
        {
            //starts the service
            using (ServiceHost host = new ServiceHost(typeof(EmployeeService.EmployeeService)))
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.WriteLine("Service is ready and data is loaded");
                Console.ReadLine();
            }
        }
        private static void LoadData()
        {
            //Loads the data from the repository class into the db context
            //using the EmployeeService Reference
            EmployeeService.EmployeesRepository.PreloadData();
            
        }
        #endregion
    }
}
