using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.TrafficLights
{
    public class TrafficLight
    {
        public TrafficLight(Signal signal)
        {
            this.Signal = signal;
        }

        public Signal Signal { get; set; }

        public void Update()
        {
            int signal = (int)this.Signal;
            if (signal + 1 > 3)
            {
                signal = 1;
            }
            else
            {
                signal++;
            }

            this.Signal = (Signal)signal;
        }
    }
}
