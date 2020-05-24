namespace _01.LoggerLibrary
{
    using _01.Logger.Core;
    using _01.Logger.Core.Contracts;
    using _01.Logger.Loggers.Enums;
    using Appenders;
    using Layouts;
    using Loggers;
    using Loggers.Contracts;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
