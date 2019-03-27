using _01.Logger.Appenders;
using _01.Logger.Loggers.Contracts;
using _01.Logger.Loggers.Enums;
using _01.LoggerLibrary.Appenders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01.LoggerLibrary.Appenders
{
    class FileAppender : Appender
    {
        const string Path = @"..\..\..\log.txt";
        
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            :base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message)
                + Environment.NewLine;
                this.AppendedMesseges++;
                this.logFile.Write(content);

                File.AppendAllText(Path, content);
            }
            
        }

        public override string Show()
        {
            return $"Appender type: ConsoleAppender, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel}, Messages appended: {this.AppendedMesseges} " +
                $", File size: {this.logFile.Size}";
        }
    }
}
