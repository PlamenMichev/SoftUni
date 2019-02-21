using System;
using System.Collections.Generic;
using System.Text;

namespace _10.CarSalesman
{
    public class Car
    {
        private const string defaultStringValue = "n/a";
        private const int deafaultIntValue = -1;

        public Car(string model, Engine engine, double weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine)
            : this(model, engine, deafaultIntValue, defaultStringValue)
        {
        }

        public Car(string model, Engine engine, double weight)
            : this(model, engine, weight, defaultStringValue)
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, deafaultIntValue, color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Color = color;
        }

        public Car()
        {
        }


        public string Model { get; set; }

        public Engine Engine { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"{this.Engine}");
            sb.AppendLine(this.Weight == -1
                ? $"  Weight: n/a"
                : $"  Weight: {this.Weight}");
            sb.Append($"  Color: {this.Color}");

            return sb.ToString();
        }
    }
}
