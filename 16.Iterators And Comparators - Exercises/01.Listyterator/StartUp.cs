using System;
using System.Linq;

namespace _01.Listyterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ListyIterator<string> listyIterator = null;
            while (input != "END")
            {
                string[] splitedInput = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = splitedInput[0];

                if (command == "Create")
                {
                    listyIterator = new ListyIterator<string>(splitedInput
                        .Skip(1)
                        .ToList());
                }
                else if(command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "Print")
                {
                    Console.WriteLine(listyIterator.Print());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }

                input = Console.ReadLine();
            }
        }
    }
}
