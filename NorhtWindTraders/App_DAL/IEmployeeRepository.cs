using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorhtWindTraders.App_DAL
{
    interface IEmployeeRepository:IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeID);
        SortedList<int, string> GetSorted();
        bool InsertEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int employeeID);
        bool Save();
    }
}
