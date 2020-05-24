namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.IO;
    using TeisterMask.Data.Models.Enums;
    using System.Globalization;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProjectDto[]),
                new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();
            var projects = new List<Project>();
            var tasks = new List<Task>();

            ImportProjectDto[] projectDtos;

            using (var reader = new StringReader(xmlString))
            {
                projectDtos = (ImportProjectDto[])
                    serializer.Deserialize(reader);
            }

            foreach (var projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    var project = new Project()
                    {
                        Name = projectDto.Name,
                        DueDate = string.IsNullOrEmpty(projectDto.DueDate)  == false || string.IsNullOrWhiteSpace(projectDto.DueDate) == false
                        ? DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        : (DateTime?)null,
                        OpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    foreach (var taskDto in projectDto.Tasks)
                    {
                        var taskOpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        var taskDueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        if (project.DueDate.HasValue)
                        {
                            if (!IsValid(taskDto) ||
                            DateTime.Compare(taskOpenDate, project.OpenDate) < 0 ||
                            DateTime.Compare(taskDueDate, project.DueDate.Value) > 0)
                            {
                                sb.AppendLine(ErrorMessage);
                                continue;
                            }
                        }
                        else
                        {
                            if (!IsValid(taskDto) ||
                                DateTime.Compare(taskOpenDate, project.OpenDate) < 0)
                            {
                                sb.AppendLine(ErrorMessage);
                                continue;
                            }
                        }

                        var task = new Task()
                        {
                            OpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            DueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            Name = taskDto.Name,
                            LabelType = (LabelType)taskDto.LabelType,
                            ExecutionType = (ExecutionType)taskDto.ExecutionType
                        };

                        tasks.Add(task);
                        project.Tasks.Add(task);
                    }

                    projects.Add(project);
                    sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                }
            }

            context.Projects.AddRange(projects);
            context.Tasks.AddRange(tasks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            var sb = new StringBuilder();


            var employees = new List<Employee>();
            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    var employee = new Employee()
                    {
                        Username = employeeDto.Username,
                        Email = employeeDto.Email,
                        Phone = employeeDto.Phone
                    };

                    foreach (var id in employeeDto.Tasks.Distinct())
                    {
                        var task = context.Tasks.FirstOrDefault(t => t.Id == id);
                        if (task == null)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        var employeeTask = new EmployeeTask()
                        {
                            Task = task,
                            Employee = employee
                        };

                        employee.EmployeesTasks.Add(employeeTask);
                    }

                    employees.Add(employee);
                    sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
                }
            }

          
            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}