using System;

namespace Problem_1._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases =
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."   //6 elements
            };
            string[] events =
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"   //6 elements
            };
            string[] authors = 
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"    //8 elements
            };
            string[] cities =
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"  //5 elements
            };
            int length = int.Parse(Console.ReadLine());
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {              
                Console.WriteLine($"{phrases[random.Next(5)]} {events[random.Next(5)]} {authors[random.Next(7)]} - {cities[random.Next(4)]}");
            }
        }
    }
}
