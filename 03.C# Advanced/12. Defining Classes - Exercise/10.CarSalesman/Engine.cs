using System;
using System.Collections.Generic;
using System.Text;

namespace _10.CarSalesman
{
    public class Engine
    {
        private const string defaultStringValue = "n/a";
        private const int deafaultIntValue = -1;

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power) : this(model, power, deafaultIntValue, defaultStringValue)
        {
        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, defaultStringValue)
        {
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power, deafaultIntValue, efficiency)
        {
        }

        public Engine()
        {

        }


        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine(this.Displacement == -1 
                ? $"    Displacement: n/a"
                : $"    Displacement: {this.Displacement}");
            sb.Append($"    Efficiency: {this.Efficiency}");

            return sb.ToString();
        }
    }
}
