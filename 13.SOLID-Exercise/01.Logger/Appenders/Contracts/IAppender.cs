using _01.Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.LoggerLibrary.Appenders
{
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string messege);

        ReportLevel ReportLevel { get; set; }

        string Show();
    }
}
