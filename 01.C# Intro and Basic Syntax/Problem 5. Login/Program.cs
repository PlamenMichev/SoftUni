using System;

namespace Problem_5._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int length=username.Length-1;
            char[] pass = username.ToCharArray(); 
            Array.Reverse(pass);
            string newPass = new string(pass);
            int count = 0;
            while(true)
            {
                if (Console.ReadLine() == newPass)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else if(count>=3)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    count++;

                }
                
                
            }
        }
    }
}
