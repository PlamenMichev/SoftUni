using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> documents = new List<string>();
            List<Employee> employees = new List<Employee>();
            Manager manager = new Manager("Plamen", documents);
            Employee employee = new Employee("Sasho");
            employees.Add(manager);
            employees.Add(employee);

            DetailsPrinter printer = new DetailsPrinter(employees);

            printer.PrintDetails();
        }
    }
}
