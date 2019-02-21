using System;

namespace _07.Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] fisrtInput = Console.ReadLine()
                .Split();

            string name = fisrtInput[0] + " " + fisrtInput[1];
            string address = fisrtInput[2];
            Tuple<string, string> firsTuple = new Tuple<string, string>(name, address);
            string[] secInput = Console.ReadLine()
                .Split();

            string secName = secInput[0];
            int litres = int.Parse(secInput[1]);

            Tuple<string, int> secTuple = new Tuple<string, int>(secName, litres);

            string[] thirdInput = Console.ReadLine()
                .Split();

            int number = int.Parse(thirdInput[0]);
            double doubleNumber = double.Parse(thirdInput[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(number, doubleNumber);

            Console.WriteLine(firsTuple);
            Console.WriteLine(secTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
