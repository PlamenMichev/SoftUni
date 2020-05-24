using System.Linq;
using System.Reflection;
using MuOnline.Core.Commands.Contracts;
using MuOnline.Core.Contracts;

namespace MuOnline.Core
{
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string suffix = "command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] args)
        {
            //AddItem itemName
            string commandName = args[0].ToLower() + suffix;
            string[] inputArgs = args
                .Skip(1)
                .ToArray();

            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid Command!");
            }

            var constructor = type
                .GetConstructors()
                .FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            var services = constructorParams
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var typeInstance = (ICommand)Activator.CreateInstance(type, services);
            string result = typeInstance.Execute(inputArgs); 

            return result;
        }
    }
}
