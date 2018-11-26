using System;
using System.Linq;

namespace Problem_11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                if (input[0] == "end")
                {
                    break;
                }
                if (input[0] == "exchange")
                {
                    int num = int.Parse(input[1]);
                    Exchange(numbers, num);
                    Console.WriteLine(String.Join(" ", numbers));
                }
                if (input[0] == "max")
                {
                    if(input[1] == "even")
                    {
                        MaxEven(numbers);
                    }
                    else if(input[1] == "odd")
                    {
                        MaxOdd(numbers);
                    }
                }
                if (input[0] == "min")
                {
                    if (input[1] == "even")
                    {
                        MinEven(numbers);
                    }
                    else if (input[1] == "odd")
                    {
                        MinOdd(numbers);
                    }
                }
                if(input[0] == "first")
                {
                    if(input[2] == "even")
                    {
                        FirstEven(numbers, int.Parse(input[1]));
                    }
                    else if (input[2] == "odd")
                    {
                        FirstOdd(numbers, int.Parse(input[1]));
                    }
                }
                if(input[0] == "last")
                {
                    if(input[2] == "odd")
                    {
                        LastOdd(numbers, int.Parse(input[1]));
                    }
                    else if(input[2] == "even")
                    {
                        LastEven(numbers, int.Parse(input[1]));
                    }
                }
            }
            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }


         static void Exchange(int[] numbers, int num)
        {
            if(num < 0 || num >= numbers.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }
            Array.Resize(ref numbers, numbers.Length + 1);
            for (int i = 0; i < num + 1; i++)
            {
                numbers[numbers.Length - 1] = numbers[0];
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }
            }
            Array.Resize(ref numbers, numbers.Length - 1);
            //Console.WriteLine(String.Join(" ", numbers));
        }
        static void MaxEven(int[] numbers)
        {
            int maxIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] % 2 == 0)
                {
                    maxIndex = i;
                }
            }
            Console.WriteLine(maxIndex);
        }
        static void MaxOdd(int[] numbers)
        {
            int maxIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    maxIndex = i;
                }
            }
            Console.WriteLine(maxIndex);
        }
        static void MinEven(int[] numbers)
        {
            int minIndex = -1;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == 0)
                {
                    minIndex = i;
                }
            }
            if(minIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else Console.WriteLine("[" + minIndex +"]");

        }
        static void MinOdd(int[] numbers)
        {
            int minIndex = numbers.Length - 1;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == 1)
                {
                    minIndex = i;
                }
            }
            Console.WriteLine(minIndex);
        }
        static void FirstEven(int[] numbers, int num)
        {
            if (num < 0 || num >= numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] answer = new int[num];
            int maxIndex = 0;
            for (int i = 0; i < num; i++)
            {

                for (int j = maxIndex + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] % 2 == 0)
                    {
                        answer[i] = numbers[j];
                        maxIndex = j;
                        break;
                    }
                }
            }
            
            Console.WriteLine(String.Join(" ", answer));
        }
        static void FirstOdd(int[] numbers, int num)
        {
            if(num < 0 || num >= numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] answer = new int[num];
            int maxIndex = 0;
            for (int i = 0; i < num; i++)
            {

                for (int j = maxIndex + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] % 2 == 1)
                    {
                        answer[i] = numbers[j];
                        maxIndex = j;
                        break;
                    }
                }
            }

            Console.WriteLine(String.Join(" ", answer));
        }
        static void LastOdd(int[] numbers, int num)
        {
            if (num < 0 || num >= numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] answer = new int[num];
            int maxIndex = numbers.Length - 1;
            for (int i = num - 1; i >= 0; i--)
            {

                for (int j = maxIndex; j >= 0; j--)
                {
                    if (numbers[j] % 2 == 1)
                    {
                        answer[i] = numbers[j];
                        maxIndex = j - 1;
                        break;
                    }
                }
            }

            Console.WriteLine(String.Join(" ", answer));
        }
        static void LastEven(int[] numbers, int num)
        {
            if (num < 0 || num >= numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            int[] answer = new int[num];
            int maxIndex = numbers.Length - 1;
            for (int i = num - 1; i >= 0; i--)
            {

                for (int j = maxIndex; j >= 0; j--)
                {
                    if (numbers[j] % 2 == 0)
                    {
                        answer[i] = numbers[j];
                        maxIndex = j - 1;
                        break;
                    }
                }
            }

            Console.WriteLine(String.Join(" ", answer));
        }
    }
}
