using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyUsers = new Dictionary<string, List<string>>();
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ");

                if (input[0] == "End")
                {
                    break;
                }

                string user = input[0];
                string id = input[1];

                if (!companyUsers.ContainsKey(user))
                {
                    companyUsers.Add(user, new List<string>());
                }
                else if (companyUsers[user].Contains(id))
                {
                    continue;
                }
                companyUsers[user].Add(id);

            }

            var result = companyUsers
                .OrderBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Key} \n-- {string.Join("\n-- ", user.Value)}");
            }
        }
    }
}
