using _01.Logger.Core.Contracts;
using _01.LoggerLibrary;
using _01.LoggerLibrary.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Layouts
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type");
            }
        }
    }
}
