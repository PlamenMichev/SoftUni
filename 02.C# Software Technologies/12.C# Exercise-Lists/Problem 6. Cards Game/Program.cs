using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (firstPlayerCards.Count != 0 && secPlayerCards.Count != 0)
            {
                int firstCardOfFirstPlayer = firstPlayerCards[0];
                int firstCardOfSecPlayer = secPlayerCards[0];
                if (firstCardOfFirstPlayer > firstCardOfSecPlayer)
                {
                    RemoveCards(firstPlayerCards, secPlayerCards);

                    firstPlayerCards.Add(firstCardOfFirstPlayer);
                    firstPlayerCards.Add(firstCardOfSecPlayer);
                }
                else if (firstCardOfFirstPlayer < firstCardOfSecPlayer)
                {
                    RemoveCards(firstPlayerCards, secPlayerCards);

                    secPlayerCards.Add(firstCardOfSecPlayer);
                    secPlayerCards.Add(firstCardOfFirstPlayer);
                    
                }
                else
                {
                    RemoveCards(firstPlayerCards, secPlayerCards);
                }
            }

            if (firstPlayerCards.Count == 0)
            {
                int sum = secPlayerCards.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            else
            {
                int sum = firstPlayerCards.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
        }

        static void RemoveCards(List<int> firstList, List<int> secList)
        {
            firstList.RemoveAt(0);
            secList.RemoveAt(0);
        }
    }
}
