using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.GenericSwapMethodStrings
{
    public class Box<T> where T : IComparable
    {
        private List<T> lines = new List<T>();
        public void Add(T line) => lines.Add(line);
        
        public int GreaterNums(T element)         
        {
            int count = 0;
            foreach (var line in lines)
            {
                
                if (line.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
