using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Car
    {
        public string Model { get; set; }

        public int Speed { get; set; }

        public Car(string model, int speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        public Car()
        {
            
        }

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine();
            sb.Append($"{this.Model} {this.Speed}");

            return sb.ToString().TrimEnd();
        }
    }
}
