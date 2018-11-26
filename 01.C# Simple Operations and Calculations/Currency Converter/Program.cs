using System;

namespace Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            string currency = Console.ReadLine();
            string secCurrency = Console.ReadLine();
            //bg
            if(currency == "BGN" && secCurrency =="USD")
            {
                Console.WriteLine($"{(money/1.79549):F2}");
            }
            if (currency == "BGN" && secCurrency == "EUR")
            {
                Console.WriteLine($"{(money / 1.95583):F2}");
            }
            if (currency == "BGN" && secCurrency == "GBP")
            {
                Console.WriteLine($"{(money / 2.53405):F2}");
            }
            if (currency == "GBP" && secCurrency == "BGN")
            {
                Console.WriteLine($"{(money * 2.53405):F2}");
            }
            if (currency == "EUR" && secCurrency == "BGN")
            {
                Console.WriteLine($"{(money * 1.95583):F2}");
            }
            if (currency == "USD" && secCurrency == "BGN")
            {
                Console.WriteLine($"{(money * 1.79549):F2}");
            }
            //forigner
            if (currency == "USD" && secCurrency == "GBP")
            {
                Console.WriteLine($"{(money / 1.41133603239):F2}");
            }
            if (currency == "USD" && secCurrency == "EUR")
            {
                Console.WriteLine($"{(money / 1.089334879):F2}");
            }
            if (currency == "EUR" && secCurrency == "GBP")
            {
                Console.WriteLine($"{(money / 1.29590766002):F2}");
            }
            if(currency == "EUR" && secCurrency == "USD")
            {
                Console.WriteLine($"{(money * 1.089334879):F2}");
            }
            if (currency == "GBP" && secCurrency == "USD")
            {
                Console.WriteLine($"{(money * 1.41133603239):F2}");
            }
            if (currency == "GBP" && secCurrency == "EUR")
            {
                Console.WriteLine($"{(money * 1.29590766002):F2}");
            }
        }
    }
}
