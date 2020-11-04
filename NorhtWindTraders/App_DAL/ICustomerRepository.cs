using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorhtWindTraders.App_DAL
{
    interface ICustomerRepository:IDisposable
    {
        IEnumerable<Customer> GetCustomers();     
        Customer GetCustomer(int customerID);
        SortedList<string, string> GetSorted();
        bool InsertCustomer(Customer customer);
        bool DeleteCustomer(int customerID);
        bool Save();
    }
}
