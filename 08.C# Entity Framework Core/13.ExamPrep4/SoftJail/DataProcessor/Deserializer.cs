namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var departments = new List<Department>();
            var cells = new List<Cell>();
            var sb = new StringBuilder();

            foreach (var departmentDto in departmentDtos)
            {
                var areCellsValid = departmentDto.Cells.All(x => IsValid(x));
                if (!IsValid(departmentDto) ||
                    !areCellsValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else
                {
                    var department = new Department()
                    {
                        Name = departmentDto.Name
                    };

                    foreach (var cellDto in departmentDto.Cells)
                    {
                        var cell = new Cell()
                        {
                            CellNumber = cellDto.CellNumber,
                            HasWindow = cellDto.HasWindow,
                            Department = department
                        };

                        department.Cells.Add(cell);
                        cells.Add(cell);
                    }

                    departments.Add(department);
                    sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                }
            }

            context.Departments.AddRange(departments);
            context.Cells.AddRange(cells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonersDto[]>(jsonString);

            var prisoners = new List<Prisoner>();
            var mails = new List<Mail>();
            var sb = new StringBuilder();

            foreach (var prisonerDto in prisonerDtos)
            {
                var areMailsValid = prisonerDto.Mails.All(x => IsValid(x));
                if (!IsValid(prisonerDto) ||
                    !areMailsValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else
                {
                    var prisoner = new Prisoner()
                    {
                        FullName = prisonerDto.FullName,
                        Nickname = prisonerDto.Nickname,
                        Age = prisonerDto.Age,
                        IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ReleaseDate = prisonerDto.IncarcerationDate == null
                        ? DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        : default(DateTime),
                        Bail = prisonerDto.Bail,
                        CellId = prisonerDto.CellId
                    };

                    foreach (var mailDto in prisonerDto.Mails)
                    {
                        var mail = new Mail()
                        {
                            Description = mailDto.Description,
                            Sender = mailDto.Sender,
                            Address = mailDto.Address,
                            Prisoner = prisoner
                        };

                        prisoner.Mails.Add(mail);
                        mails.Add(mail);
                    }

                    prisoners.Add(prisoner);
                    sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
            }

            context.Prisoners.AddRange(prisoners);
            context.Mails.AddRange(mails);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportOfficerDto[]),
                new XmlRootAttribute("Officers"));

            var sb = new StringBuilder();

            ImportOfficerDto[] officerDtos;
            using (var reader = new StringReader(xmlString))
            {
                officerDtos = (ImportOfficerDto[])
                    serializer.Deserialize(reader);
            }

            var officers = new List<Officer>();
            foreach (var officerDto in officerDtos)
            {
                var isWeaponValid = Enum.IsDefined(typeof(Weapon), officerDto.Weapon);
                var isPositionValid = Enum.IsDefined(typeof(Position), officerDto.Position);

                if (!IsValid(officerDto) ||
                    !isWeaponValid ||
                    !isPositionValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else
                {
                    var officer = new Officer()
                    {
                        FullName = officerDto.FullName,
                        Salary = officerDto.Salary,
                        Position = (Position)Enum.Parse(typeof(Position), officerDto.Position),
                        Weapon = (Weapon)Enum.Parse(typeof(Weapon), officerDto.Weapon),
                        DepartmentId = officerDto.DepartmentId,
                    };

                    foreach (var prisonerDto in officerDto.Prisoners)
                    {
                        var prisoner = context.Prisoners.Find(prisonerDto.Id);
                        var pair = new OfficerPrisoner()
                        {
                            Prisoner = prisoner,
                            Officer = officer
                        };
                        officer.OfficerPrisoners.Add(pair);
                    }

                    officers.Add(officer);
                    sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
                }
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, validationContext, results, true);

            return isValid;
        }
    }
}