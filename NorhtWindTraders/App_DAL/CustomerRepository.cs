using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorhtWindTraders.App_DAL
{
    public class CustomerRepository:ICustomerRepository,IDisposable
    {
        NWContext db;

        public CustomerRepository()
        {
            db = new NWContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer GetCustomer(int customerID)
        {
            return db.Customers.Find(customerID);
        }

        public SortedList<string, string> GetSorted()
        {
            SortedList<string, string> cs = new SortedList<string, string>();
            var custs = (from c in db.Customers
                         select new
                         {
                             CustomerID = c.CustomerID,
                             CompanyName = c.CompanyName
                         }).ToList();


            foreach (var c in custs)
            {
                cs.Add(c.CustomerID, c.CompanyName);
            }

            return cs;
        }

        public bool InsertCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            db.Customers.Attach(customer);
            db.Entry(customer).State = EntityState.Modified;
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool DeleteCustomer(int productId)
        {
            var or = db.Customers.Find(productId);
            db.Customers.Remove(or);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            db.Dispose();
        }


       
    }
}