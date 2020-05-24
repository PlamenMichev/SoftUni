using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericsBoxOfString
{
    public class Box<T>
    {
        private List<T> lines = new List<T>();

        public void Add(T item) => lines.Add(item);

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
