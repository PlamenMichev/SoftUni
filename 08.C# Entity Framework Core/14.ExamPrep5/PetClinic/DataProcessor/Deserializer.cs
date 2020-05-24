namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.Models;

    public class Deserializer
    {

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAids = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            var animalAidsToImport = new List<AnimalAid>();
            var sb = new StringBuilder();

            foreach (var animalAid in animalAids)
            {
                if (!IsValid(animalAid))
                {
                    sb.AppendLine("Error: Invalid data.");
                }
                else
                {
                    var animalAidToAdd = new AnimalAid()
                    {
                        Name = animalAid.Name,
                        Price = animalAid.Price
                    };

                    if (!animalAidsToImport.Any(x => x.Name == animalAidToAdd.Name))
                    {
                        animalAidsToImport.Add(animalAidToAdd);
                        sb.AppendLine($"Record {animalAidToAdd.Name} successfully imported.");
                    }
                    else
                    {
                        sb.AppendLine("Error: Invalid data.");
                    }
                }
            }

            context.AnimalAids.AddRange(animalAidsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            throw new NotImplementedException();
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
