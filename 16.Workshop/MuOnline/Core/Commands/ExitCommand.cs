using MuOnline.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MuOnline.Core.Commands
{
    class ExitCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine($"Exit after {i}s");   
                Thread.Sleep(1000);
                Console.Clear();
            }

            Console.WriteLine("BOOM");

            Environment.Exit(0);
            return null;
        }
    }
}
