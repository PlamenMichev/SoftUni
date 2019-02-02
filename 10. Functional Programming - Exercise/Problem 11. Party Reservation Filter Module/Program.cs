using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            HashSet<string> addFilter = new HashSet<string>();
            HashSet<string> removeFilter = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Print")
                {
                    break;
                }

                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string filterCommand = tokens[1];
                string criteria = tokens[2];
                string filterType = filterCommand + " " + criteria;
                
                if (command == "Remove filter")
                {
                    removeFilter.Add(filterType);
                }
                else if (command == "Add filter")
                {
                    addFilter.Add(filterType);
                }

                foreach (var filter in removeFilter)
                {
                    addFilter.Remove(filter);
                }
            }
            Func<string, string, bool> predicate;
            foreach (var filter in addFilter)
            {
                string[] filterTypeAndParameter = filter.Split(" ");

                string typeFilter = "";
                string parameter = filterTypeAndParameter[1];


                if (filterTypeAndParameter.Length == 3)
                {
                    typeFilter = filterTypeAndParameter[0] + " " + filterTypeAndParameter[1];
                    parameter = filterTypeAndParameter[2];
                }
                else
                {
                    typeFilter = filterTypeAndParameter[0];
                    parameter = filterTypeAndParameter[1];
                }

                predicate = GetFunc(typeFilter);
                names.RemoveAll(x => predicate(x, parameter));
            }
            Console.WriteLine(string.Join(" ", names));
        }

        static Func<string, string, bool> GetFunc(string filterCommand)
        {
            if (filterCommand == "Starts with")
            {
                return (x, c) => x.StartsWith(c);
            }
            if (filterCommand == "Ends with")
            {
                return (x, c) => x.EndsWith(c);
            }
            if (filterCommand == "Length")
            {
                return (x, c) => x.Length == int.Parse(c);
            }
            if (filterCommand == "Contains")
            {
                return (x, c) => x.Contains(c);
            }
            return null;
        }
    }
}
