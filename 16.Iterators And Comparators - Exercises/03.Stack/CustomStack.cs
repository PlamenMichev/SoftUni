using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> data;
        public int Count => data.Count;

        public CustomStack()
        {
            this.data = new List<T>();
        }

        public void Push(params T[] items)
        {
            
            for (int i = 0; i < items.Length; i++)
            {
                this.data.Add(items[i]);
            }
        }

        public void Pop()
        {
            this.data.RemoveAt(data.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
