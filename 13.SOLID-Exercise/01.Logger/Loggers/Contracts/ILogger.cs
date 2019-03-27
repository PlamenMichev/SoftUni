using System;
using System.Collections.Generic;
using System.Text;

namespace _01.LoggerLibrary.Loggers.Contracts
{
    interface ILogger
    {
        void Error(string dateTime, string errorMessege);

        void Info(string dateTime, string infoMessege);

        void Critical(string dateTime, string infoMessege);

        void Fatal(string dateTime, string infoMessege);

        void Warning(string dateTime, string infoMessege);
    }
}
