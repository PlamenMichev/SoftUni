using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;

        public int Count { get => data.Count; }

        public Box()
        {
            this.data = new List<T>();
        }
        
        public void Add(T item)
        {
            this.data.Add(item);
        }

        public T Remove()
        {
            var lastElement = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);
            return lastElement;
        }
    }
}
