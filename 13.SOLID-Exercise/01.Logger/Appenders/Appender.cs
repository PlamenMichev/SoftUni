using _01.Logger.Loggers.Enums;
using _01.LoggerLibrary;
using _01.LoggerLibrary.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public abstract string Show();

        protected int AppendedMesseges { get; set; }

        protected ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string messege);
    }
}
