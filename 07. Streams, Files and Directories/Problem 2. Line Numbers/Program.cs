using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"Resources/02. Line Numbers/Input.txt"))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    int i = 1;

                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        line = $"{i}. {line}";

                        i++;

                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
