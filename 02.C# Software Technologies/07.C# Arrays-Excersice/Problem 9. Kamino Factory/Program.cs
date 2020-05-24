using System;
using System.Linq;

namespace Problem_9._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)

        {
            int num = int.Parse(Console.ReadLine());

            int length = 0;
            int sum = 0;
            int index = -1;
            int row = 0;
            int currentRow = 1;
            int[] bestDNA = new int [num];
            while (true)
            {

                string DNA = Console.ReadLine();
                if (DNA == "Clone them!")
                {
                    break;
                }
                string[] DNAAsNums = DNA.Split("!").ToArray();
                //Parsing to numbers
                int[] numbers = DNA.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currentSum = 0;
                //Finding Sum
                for (int i = 0; i < num; i++)
                {
                    currentSum += numbers[i];
                }
                if(currentRow==1)
                {
                    bestDNA = numbers;
                    row = currentRow;
                    sum = currentSum;
                }
                int currentIndex = -1;
                int currentLength = 0;
                bool isFound = false;
                //finding left index
                for (int i = 0; i < num; i++)
                {
                    if (numbers[i] == 1)
                    {
                        if (!isFound)
                        {
                            currentIndex = i;
                        }
                        currentLength++;
                        if (currentLength > length)
                        {
                            length = currentLength;
                            index = currentIndex;
                            sum = currentSum;
                            row = currentRow;
                            bestDNA = numbers;
                        }
                        else if (currentLength == length)
                        {
                            if (currentIndex < index)
                            {
                                length = currentLength;
                                index = currentIndex;
                                sum = currentSum;
                                row = currentRow;
                                bestDNA = numbers;
                            }
                            else if (currentSum > sum)
                            {
                                length = currentLength;
                                index = currentIndex;
                                sum = currentSum;
                                row = currentRow;
                                bestDNA = numbers;
                            }
                        }
                    }
                else
                {
                    currentIndex = -1;
                    currentLength = 0;
                    isFound = false;
                }
               }



                currentRow++;
            }
            Console.WriteLine($"Best DNA sample {row} with sum: {sum}.");
            Console.WriteLine(String.Join(" ", bestDNA));
        }
    }
}
