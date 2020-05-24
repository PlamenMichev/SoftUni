using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var result = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    Name = e.FirstName + " " + e.LastName + " " + e.MiddleName,
                    e.JobTitle,
                    Salary = $"{e.Salary:f2}"
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in result)
            {
                sb.AppendLine($"{employee.Name} {employee.JobTitle} {employee.Salary}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    SalaryInfo = e.FirstName + " - " + $"{e.Salary:f2}",
                })
                .ToList();

            var result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine(employee.SalaryInfo);
            }

            return result.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .ToList();

            var result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} " +
                    $"from {employee.Name}" +
                    $" - ${employee.Salary:f2}");
            }

            return result.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var addresses = context.Addresses;
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            addresses.Add(newAddress);

            var employee = context.Employees
                .Where(e => e.LastName == "Nakov")
                .First();

            employee.Address = newAddress;
            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.Address.AddressId)
                .Take(10)
                .ToList();
            var result = new StringBuilder();
            foreach (var empl in employees)
            {
                result.AppendLine(context.Addresses.FirstOrDefault(a => a.AddressId == empl.AddressId).AddressText);
            }

            return result.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    IsInPeriod = e.EmployeesProjects
                                .Where(ep => ep.Project.StartDate.Year >= 2001
                                            && ep.Project.StartDate.Year <= 2003)
                                 .Any(),
                    Projects = e.EmployeesProjects
                                .Select(ep => new
                                {
                                    ep.Project.Name,
                                    ep.Project.StartDate,
                                    ep.Project.EndDate
                                })
                })
                .Take(10)
                .ToList();

            var result = new StringBuilder();

            foreach (var employee in employees)
            {
                if (employee.IsInPeriod)
                {
                    result.AppendLine($"{employee.Name} - Manager: {employee.ManagerName}");
                    foreach (var project in employee.Projects)
                    {
                        result.Append($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - ");
                        result.Append(
                            project.EndDate.HasValue == false
                            ? "not finished"
                            : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                        result.AppendLine();
                    }
                }
            }

            return result.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    EmployeesCount = a.Employees.Count,
                    TownName = a.Town.Name,
                    a.AddressText
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            var result = new StringBuilder();
            foreach (var address in addresses)
            {
                result.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return result.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                                .Select(ep => new
                                {
                                    ep.Project.Name
                                })
                                .OrderBy(ep => ep.Name)
                                .ToList()
                })
                .First();
            var result = new StringBuilder();

            result.AppendLine($"{employee.Name} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                result.AppendLine($"{project.Name}");
            }

            return result.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderByDescending(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                                    .OrderBy(e => e.FirstName)
                                    .ThenBy(e => e.LastName)
                                    .Select(e => new
                                    {
                                        Name = e.FirstName + " " + e.LastName,
                                        e.JobTitle
                                    })
                                    .ToList()
                })
                .ToList();

            var result = new StringBuilder();
            foreach (var department in departments)
            {
                result.AppendLine($"{department.Name} - {department.ManagerName}");
                foreach (var employee in department.Employees)
                {
                    result.AppendLine($"{employee.Name} - {employee.JobTitle}");
                }
            }

            return result.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new 
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .Take(10)
                .ToList();

            var result = new StringBuilder();
            foreach (var project in latestProjects
                .OrderBy(p => p.Name))
            {
                result.AppendLine(project.Name);
                result.AppendLine(project.Description);
                result.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt",
                                                                CultureInfo.InvariantCulture));
            }

            return result.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .Select(e => new Employee
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary += 0.12m * employee.Salary;
            }

            context.SaveChanges();
            var result = new StringBuilder();
            foreach (var employee in employees
                                        .OrderBy(e => e.FirstName)
                                        .ThenBy(e => e.LastName))
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return result.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    Name = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();
            var result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.Name} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return result.ToString();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectsInEmplProj = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);
            foreach (var project in projectsInEmplProj)
            {
                context.EmployeesProjects.Remove(project);
            }

            context.SaveChanges();
            var projectToDelete = context.Projects
                .First(p => p.ProjectId == 2);
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();
            var result = new StringBuilder();
            foreach (var project in context.Projects.ToArray().Take(10))
            {
                result.AppendLine(project.Name);
            }

            return result.ToString();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .First(t => t.Name == "Seattle");

            var addresses = context.Addresses
                .Where(a => a.TownId == town.TownId)
                .ToList();
            
            foreach (var employee in context.Employees.ToList())
            {
                if (addresses.Contains(employee.Address))
                {
                    employee.AddressId = null;
                }
            }

            context.SaveChanges();
            foreach (var adressInDb in addresses)
            {
                context.Addresses.Remove(adressInDb);
            }

            context.SaveChanges();
            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(
                RemoveTown(new SoftUniContext()));
        }
    }
}
