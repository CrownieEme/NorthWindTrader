using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorhtWindTraders.App_DAL
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        NWContext db;

        public EmployeeRepository()
        {
            db = new NWContext();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployee(int employeeID)
        {
            return db.Employees.Find(employeeID);
        }

        public SortedList<int, string> GetSorted()
        {
            SortedList<int, string> cs = new SortedList<int, string>();
            var custs = (from c in db.Employees
                         select new
                         {
                             EmployeeID = c.EmployeeID,
                             EmployeeName = c.FirstName + " " + c.LastName

                         }).ToList();

            foreach (var c in custs)
            {
                cs.Add(c.EmployeeID, c.EmployeeName);
            }

            return cs;
        }

        public bool InsertEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            db.Employees.Attach(employee);
            db.Entry(employee).State = EntityState.Modified;
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;

        }

        public bool DeleteEmployee(int employeeID)
        {
            var or = db.Employees.Find(employeeID);
            db.Employees.Remove(or);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool Save()
        {
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

       