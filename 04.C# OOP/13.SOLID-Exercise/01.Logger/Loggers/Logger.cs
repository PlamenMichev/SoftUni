
using _01.Logger.Loggers.Contracts;
using _01.Logger.Loggers.Enums;
using _01.LoggerLibrary.Appenders;
using _01.LoggerLibrary.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.LoggerLibrary.Loggers
{
    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        private void Append(string dateTime, string message, ReportLevel type)
        {
            consoleAppender?.Append(dateTime, type, message);
            fileAppender?.Append(dateTime, type, message);
        }


        public void Info(string dateTime, string infoMessage)
        {
            this.Append(dateTime, infoMessage, ReportLevel.INFO);
        }

        public void Warning(string dateTime, string warningMessage)
        {
            this.Append(dateTime, warningMessage, ReportLevel.WARNING);
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.Append(dateTime, errorMessage, ReportLevel.ERROR);
        }

        public void Critical(string dateTime, string errorMessage)
        {
            this.Append(dateTime, errorMessage, ReportLevel.CRITICAL);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.Append(dateTime, fatalMessage, ReportLevel.FATAL);
        }
    }
}
