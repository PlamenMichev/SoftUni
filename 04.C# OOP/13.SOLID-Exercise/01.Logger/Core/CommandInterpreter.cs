using _01.Logger.Appenders;
using _01.Logger.Appenders.Contracts;
using _01.Logger.Core.Contracts;
using _01.Logger.Layouts;
using _01.Logger.Loggers.Enums;
using _01.LoggerLibrary;
using _01.LoggerLibrary.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private AppenderFactory appenderFactory;
        private LayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }
        
        public void AddAppender(string[] args)
        {
            string typeAppender = args[0];
            string typeLayout = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = this.layoutFactory.CreateLayout(typeLayout);
            IAppender appender = this.appenderFactory.CreateAppender(typeAppender, layout);

            appender.ReportLevel = reportLevel;

            appenders.Add(appender);
        }

        public void AddReport(string[] args)
        {
            string reportType = args[0];
            string dateTime = args[1];
            string message = args[2];

            ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportType);
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.Show());
            }
        }
    }
}
