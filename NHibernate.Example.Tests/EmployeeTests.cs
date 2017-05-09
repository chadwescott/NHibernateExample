using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Example.Domain;
using System;

namespace NHibernate.Example.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void CreateEmployeeTest()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                ITransaction tx = session.BeginTransaction();

                var chad = new Employee
                {
                    FirstName = "Chad",
                    LastName = "Wescot",
                    Designation = "Senior Software Engineer"
                };

                session.Save(chad);
                tx.Commit();
            }
        }

        [TestMethod]
        public void GetAllEmployeesTest()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var query = session.CreateQuery("select e from Employee e");
                foreach(var employee in query.List<Employee>())
                {
                    Console.WriteLine($"Employee: {employee.FirstName} {employee.LastName}: {employee.Designation}");
                }
            }
        }
    }
}
