using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Resources/text.txt"))
            {
                int counter = 1;
                using (var writer = new StreamWriter("../../../Resources/output.txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        writer.WriteLine($"Line {counter}: {line}({CountOfWords(line)})({CountOfPonctMarks(line)})");
                        counter++;
                    }
                }
            }
        }

        public static int CountOfWords(string line)
        {
            int counter = 0;
            foreach (var item in line)
            {
                if (char.IsLetter(item) == true)
                {
                    counter++;
                }
            }

            return counter;
        }
        public static int CountOfPonctMarks(string line)
        {
            int counter = 0;
            foreach (var item in line)
            {
                if (char.IsPunctuation(item) == true)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
