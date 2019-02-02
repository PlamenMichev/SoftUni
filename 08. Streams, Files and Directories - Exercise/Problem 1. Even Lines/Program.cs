using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem_1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> output = new List<string>();
            using (var reader = new StreamReader("../../../Resources/text.txt"))
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
                        output.Add(line);
                    }

                    counter++;
                }
            }

            for (int i = 0; i < output.Count; i++)
            {
                output[i] = output[i].Replace('.', '@');
                output[i] = output[i].Replace('-', '@');
                output[i] = output[i].Replace(',', '@');
                output[i] = output[i].Replace('!', '@');
                output[i] = output[i].Replace('?', '@');
            }

            for (int i = 0; i < output.Count; i++)
            {
                string[] temp = output[i].Split();
                temp = temp.Reverse().ToArray();
                string currentString = "";
                foreach (var word in temp)
                {
                    foreach (var symbol in word)
                    {
                        currentString += symbol;
                    }

                    currentString += " ";
                }

                output[i] = currentString;
            }

            using (var writer = new StreamWriter("../../../Resources/output.txt"))
            {
                foreach (var line in output)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
