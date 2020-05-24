using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstFileText = File.ReadAllLines("Resources/04. Merge Files/FileOne.txt");
            string[] secongFileText = File.ReadAllLines("Resources/04. Merge Files/FileTwo.txt");
            List<string> finalText = new List<string>();
            foreach (var line in firstFileText)
            {
                finalText.Add(line);
            }
            foreach (var line in secongFileText)
            {
                finalText.Add(line);
            }
            foreach (var line in finalText.OrderBy(x => x))
            {
                using (StreamWriter writer = File.AppendText("Output.txt"))
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
