using System;

namespace P01.ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (ValidateData(value))
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }              
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (ValidateData(value))
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (ValidateData(value))
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        public double SurfaceArea(double length, double width, double height)
        {
            double area = 2 * length * width + 2 * width * height + 2 * length* height;
            return area;
        }

        public double LiteralSurfaceArea(double length, double width, double height)
        {
            double area = 2 * length * height + 2 * width * height;
            return area;
        }

        public double Volume(double length, double width, double height)
        {
            double volume = length * width * height;
            return volume;
        }

        public bool ValidateData(double num)
        {
            return num > 0;
        }
    }
}
