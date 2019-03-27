using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);
        void AddReport(string[] args);
        void PrintInfo();
    }
}
