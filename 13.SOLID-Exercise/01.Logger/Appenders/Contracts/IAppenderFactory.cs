using _01.LoggerLibrary;
using _01.LoggerLibrary.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Appenders.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
