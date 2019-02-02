using System;
using System.Numerics;

namespace Problem_7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            BigInteger[][] pascalArray = new BigInteger[rows][];
            pascalArray[0] = new BigInteger[1];
            pascalArray[0][0] = 1;
            for (int row = 0; row < rows; row++)
            {
                pascalArray[row] = new BigInteger[row + 1];
                pascalArray[row][0] = 1;
                pascalArray[row][pascalArray[row].Length - 1] = 1;
                for (int col = 1; col < pascalArray[row].Length - 1; col++)
                {
                    pascalArray[row][col] += pascalArray[row - 1][col];
                    pascalArray[row][col] += pascalArray[row - 1][col - 1];
                }
            }

            foreach (var row in pascalArray)
            {
                Console.WriteLine(string.Join(" ", row)); 
            }
        }
    }
}
