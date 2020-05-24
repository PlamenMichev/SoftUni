using _01.Logger.Appenders.Contracts;
using _01.LoggerLibrary;
using _01.LoggerLibrary.Appenders;
using _01.LoggerLibrary.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Appenders
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            type = type.ToLower();

            switch (type)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
