namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    p.Id,
                    Name = p.FullName,
                    p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                                .Select(po => new
                                {
                                    OfficerName = po.Officer.FullName,
                                    Department = po.Officer.Department.Name
                                })
                                .OrderBy(po => po.OfficerName),
                    TotalOfficerSalary = decimal.Parse($"{p.PrisonerOfficers.Sum(po => po.Officer.Salary):f2}")
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id);

            var result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return result;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisoners = new List<Prisoner>();
            var names = prisonersNames.Split(",");
            foreach (var name in names)
            {
                var prisoner = context.Prisoners.First(x => x.FullName == name);
                prisoners.Add(prisoner);
            }

            var exportPrisoners = prisoners
                    .Select(p => new ExportPrisonerDto
                    {
                        Id = p.Id,
                        Name = p.FullName,
                        IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                        EncryptedMessages = p.Mails
                                            .Select(m => new ExportMessagesDto
                                            {
                                                Description = String.Join("", m.Description.ToCharArray().Reverse())
                                            })
                                            .ToArray()
                    })
                    .OrderBy(p => p.Name)
                    .ThenBy(p => p.Id)
                    .ToArray();

            var serializer = new XmlSerializer(typeof(ExportPrisonerDto[]),
                new XmlRootAttribute("Prisoners"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, exportPrisoners, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}