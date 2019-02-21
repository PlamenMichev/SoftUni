using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace _09.RectangleIntersection
{
    public class Rectangle
    {
        public string Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Row { get; set; }

        public double Col { get; set; }

        public bool AreIntersected(Rectangle rectangle)
        {
            if (this.Row + this.Width < rectangle.Row
                 || rectangle.Row + rectangle.Width < this.Row
                 || this.Col + this.Height < rectangle.Col
                 || rectangle.Col + rectangle.Height < this.Col)
            {
                return false;
            }

            return true;
        }
    }
}
