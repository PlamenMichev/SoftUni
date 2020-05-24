using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ExelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string[][] matrix = new string[length - 1][];
            for (int i = 0; i < length - 1; i++)
            {
                matrix[i] = new string[format.Length - 1];
                string[] line = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                matrix[i] = line;
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (command[0] == "sort")
            {
                string header = command[1];
                var formatAsList = format.ToList();
                int index = Array.IndexOf(format, header);

                Console.WriteLine(string.Join(" | ", format));
                foreach (var row in matrix.OrderBy(x => x[index]))
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
            else if (command[0] == "hide")
            {
                string header = command[1];
                int index = Array.IndexOf(format, header);


                List<string> formatToPrint = new List<string>();
                formatToPrint.AddRange(format.Take(index));
                formatToPrint.AddRange(format.Skip(index + 1));
                Console.WriteLine(string.Join(" | ", formatToPrint));


                for (int row = 0; row < matrix.Length; row++)
                {
                    List<string> lineToPrint = new List<string>();
                    lineToPrint.AddRange(matrix[row].Take(index).ToList());
                    lineToPrint.AddRange(matrix[row].Skip(index + 1));
                    Console.WriteLine(string.Join(" | ", lineToPrint));
                }
            }
            else if (command[0] == "filter")
            {
                string criteria = command[1];
                int index = Array.IndexOf(format, criteria);
                string header = command[2];
                Console.WriteLine(string.Join(" | ", format));
                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][index] == header)
                    {
                        Console.WriteLine(string.Join(" | ", matrix[row]));
                    }
                }
            }
        }
    }
}
