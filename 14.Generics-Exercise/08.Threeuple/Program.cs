using System;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split();

            string name = firstInput[0] + " " + firstInput[1];
            string address = firstInput[2];
            string town = firstInput[3];
            Threeuple<string, string, string> firsTuple = new Threeuple<string, string, string>(name, address, town);
            string[] secInput = Console.ReadLine()
                .Split();

            string secName = secInput[0];
            int litres = int.Parse(secInput[1]);
            bool isDrunk = secInput[2].ToLower() == "drunk" ? true : false;

            Threeuple<string, int, bool> secTuple = new Threeuple<string, int, bool>(secName, litres, isDrunk);

            string[] thirdInput = Console.ReadLine()
                .Split();

            string thirdName = thirdInput[0];
            double balance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];


            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(thirdName, balance, bankName);

            Console.WriteLine(firsTuple);
            Console.WriteLine(secTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
