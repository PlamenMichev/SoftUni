using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            List<Doctor> doctors = new List<Doctor>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + secondName;

                var currentDoctor = new Doctor();
                var currentPatient = new Patient(patient, currentDoctor);

                if (doctors.Where(x => x.Name == fullName).ToList().Count == 0)
                {
                    currentDoctor = new Doctor(fullName);
                }
                else
                {
                    currentDoctor = doctors.First(x => x.Name == fullName);
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int room = 0; room < 20; room++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool isThereFreePlace = departments[departament].SelectMany(x => x).Count() < 60;
                if (isThereFreePlace)
                {
                    int room = 0;
                    currentDoctor.AddPatient(currentPatient);
                    doctors.Add(currentDoctor);
                    for (int currentRoom = 0; currentRoom < departments[departament].Count; currentRoom++)
                    {
                        if (departments[departament][currentRoom].Count < 3)
                        {
                            room = currentRoom;
                            break;
                        }
                    }
                    departments[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] splitCommand = command.Split();

                if (splitCommand.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[splitCommand[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (splitCommand.Length == 2 && int.TryParse(splitCommand[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[splitCommand[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    var currentDoctor = doctors.FirstOrDefault(x => x.Name == splitCommand[0] + splitCommand[1]);
                    Console.WriteLine(string.Join("\n", currentDoctor.GetPatientsNames().OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
