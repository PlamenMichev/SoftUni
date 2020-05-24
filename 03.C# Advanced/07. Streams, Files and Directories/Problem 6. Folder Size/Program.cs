using System;
using System.IO;

namespace Problem_6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            var info = new DirectoryInfo(@"C:\Users\miche\source\repos\07. Streams, Files and Directories\Problem 6. Folder Size\bin\Debug\netcoreapp2.1\Resources\06. Folder Size\TestFolder");
            foreach (var file in info.GetFiles())
            {
                sum += (double)file.Length / 1024 / 1024;
            }

            Console.WriteLine($"{sum}");
        }
    }
}
