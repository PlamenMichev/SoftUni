using _01.LoggerLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Core.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
