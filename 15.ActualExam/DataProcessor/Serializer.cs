namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
               .Where(p => p.Tasks.Any())
               .Select(p => new ExportProjectDto
               {
                   TasksCount = p.Tasks.Count,
                   ProjectName = p.Name,
                   HasEndDate = p.DueDate.HasValue
                   ? "Yes"
                   : "No",
                   Tasks = p.Tasks
                           .Select(t => new ExportTaskDto
                           {
                               Label = t.LabelType.ToString(),
                               Name = t.Name
                           })
                           .OrderBy(t => t.Name)
                           .ToArray()
               })
               .OrderByDescending(p => p.TasksCount)
               .OrderBy(p => p.ProjectName)
               .ToArray();

            var serializer = new XmlSerializer(typeof(ExportProjectDto[]),
                new XmlRootAttribute("Projects"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, projects, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesTasks.Any(et => DateTime.Compare(et.Task.OpenDate, date) >= 0))
                .Select(e => new
                {
                    e.Username,
                    Tasks = e.EmployeesTasks
                                .Where(et => DateTime.Compare(et.Task.OpenDate, date) >= 0)
                                .OrderByDescending(t => t.Task.DueDate)
                                .ThenBy(t => t.Task.Name)
                                .Select(t => new
                                {
                                    TaskName = t.Task.Name,
                                    OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                    DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                    LabelType = t.Task.LabelType.ToString(),
                                    ExecutionType = t.Task.ExecutionType.ToString(),
                                })
                                .ToList()

                })
                .ToList()
                .OrderByDescending(e => e.Tasks.Count)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToList();

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result.ToString().TrimEnd();
        }
    }
}

