namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;
            commandName = commandName.First().ToString().ToUpper() + commandName.Substring(1);

            Type type = Type.GetType($"{typeof(AppEntryPoint).Namespace}.Core.AddedCommands.{commandName}");
            if (type == null)
            {
                throw new ArgumentException("Invalid Command");
            }

            var constructor = type
                .GetConstructor(BindingFlags.Instance | BindingFlags.Public
                , null
                , new Type[] { typeof(string[]), typeof(IRepository), typeof(IUnitFactory) }
                , null);

            var instance = constructor.Invoke(new object[] { data, this.repository, this.unitFactory });
            MethodInfo executeMethod = type.GetMethod("Execute");

            result = executeMethod.Invoke(instance, new object[] { }).ToString();

            return result;
        }
    }
}
