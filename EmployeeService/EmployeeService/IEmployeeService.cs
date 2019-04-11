using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract ]
        List<Employees> GetEmployee();

        [OperationContract]
        void SaveEmployee(Employees employee);

        [OperationContract]
        Employees FindEmployee(int id);

        [OperationContract]
        void UpdateEmployee(Employees employee);

    }
}
