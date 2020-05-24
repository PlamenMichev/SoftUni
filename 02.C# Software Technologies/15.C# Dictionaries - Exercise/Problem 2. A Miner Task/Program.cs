using System;
using System.Collections.Generic;
using System.Numerics;

namespace Problem_2._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var storeData = new Dictionary<string, int>();
            while (true)
            {
                string resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (!storeData.ContainsKey(resource))
                {
                    storeData[resource] = 0;
                }

                storeData[resource] += quantity;

            }

            foreach (var kvp in storeData)
            {
                Console.WriteLine(kvp.Key + " -> " + kvp.Value);
            }
        }
    }
}
