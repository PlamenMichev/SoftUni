using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            List<string> answer = new List<string>();
            char[][] matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[row];
                string input = Console.ReadLine();
                char[] temp = input.ToCharArray();
                matrix[row] = temp;
            }

            bool isFound = false;
            char symbolToFind = char.Parse(Console.ReadLine());
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < rows; col++)
                {
                    if (matrix[row][col] == symbolToFind)
                    {
                        string temp = row.ToString();
                        string secTemp = col.ToString();
                        string result = "(" + temp + ", " + secTemp + ")";
                        answer.Add(result);
                        isFound = true;
                        break;
                    }                   
                }
                if (isFound)
                {
                    break;
                }
            }

            if (answer.Any() == false)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
                return;
            }
            foreach (var row in answer)
            {
                Console.WriteLine(row);
            }
        }
    }
}
