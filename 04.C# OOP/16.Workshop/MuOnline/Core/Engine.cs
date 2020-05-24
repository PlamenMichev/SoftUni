using Microsoft.Extensions.DependencyInjection;
using MuOnline.Core.Factories.Contracts;

namespace MuOnline.Core
{
    using System;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                    var commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();
                    var result = commandInterpreter.Read(inputArgs);

                    //todo: Add IWriter
                    Console.WriteLine(result);

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane.Message);
                }
                catch (ArgumentException ax)
                {
                    Console.WriteLine(ax.Message);
                }
                catch (InvalidOperationException iox)
                {
                    Console.WriteLine(iox.Message);
                }
            }
        }
    }
}
