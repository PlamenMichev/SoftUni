using System;
using System.IO;

namespace Problem_1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"Resources/01. Odd Lines/Input.txt"))
            {
                int counter = 0;

                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (counter % 2 == 0)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;
                }
            }
        }
    }
}
