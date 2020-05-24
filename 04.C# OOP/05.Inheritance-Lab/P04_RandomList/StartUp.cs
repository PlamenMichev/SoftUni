using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("Plamen");
            list.Add("Angle");
            list.Add("Sine");

            Console.WriteLine(list.RandomString());
        }
    }
}
