using System;

namespace _04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split();
            string[] urls = Console.ReadLine()
                .Split();

            var phone = new Smartphone();

            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(phone.Browse(url));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
