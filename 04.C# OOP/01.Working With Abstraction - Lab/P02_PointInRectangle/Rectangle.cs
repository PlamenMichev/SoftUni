using System;
using System.Collections.Generic;
using System.Text;

namespace P02_PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point botRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = botRight;
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            return this.TopLeft.X <= point.X && this.TopLeft.Y <= point.Y && this.BottomRight.X >= point.X && this.BottomRight.Y >= point.Y;            
        }
    }
}
