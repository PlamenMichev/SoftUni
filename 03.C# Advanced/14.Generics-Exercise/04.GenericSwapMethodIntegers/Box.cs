using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.GenericSwapMethodStrings
{
    public class Box<T>
    {
        private List<T> lines = new List<T>();
        public void Add(T line) => lines.Add(line);

        public void Swap(int firstIndex, int secIndex)
        {
            T temp = lines[firstIndex];
            lines[firstIndex] = lines[secIndex];
            lines[secIndex] = temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                sb.AppendLine($"{typeof(T)}: {line}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
