using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-4PCJT2Q\\SQLEXPRESS;Database=MiniORM;Integrated Security=True";
            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Pesho",
                LastName = "Peshov",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Gosho";

            context.SaveChanges();
        }
    }
}
