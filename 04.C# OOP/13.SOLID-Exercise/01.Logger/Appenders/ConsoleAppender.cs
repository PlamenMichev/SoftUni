using _01.Logger.Appenders;
using _01.Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.LoggerLibrary.Appenders
{
    public class ConsoleAppender : Appender
    {

        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
        }

        public override string Show()
        {
            return $"Appender type: ConsoleAppender, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel}, Messages appended: {this.AppendedMesseges}";
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string messege)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, messege));
                this.AppendedMesseges++;
            }
        }
    }
}
