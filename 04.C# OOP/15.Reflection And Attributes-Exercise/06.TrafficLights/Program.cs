using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _06.TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> order = Console.ReadLine()
                .Split()
                .ToList();
            List<TrafficLight> trafficLight = new List<TrafficLight>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < order.Count; i++)
            {
                string signal = order[i];

                var signalToAdd = (Signal)Enum.Parse(typeof(Signal), signal);
                TrafficLight cuurentLight = new TrafficLight(signalToAdd);

                trafficLight.Add(cuurentLight);
            }

            for (int i = 0; i < count; i++)
            {
                string result = string.Empty;
                foreach (var signal in trafficLight)
                {
                    signal.Update();
                    result += signal.Signal.ToString() + " ";
                }
                Console.WriteLine(result);
            }

        }
    }
}
