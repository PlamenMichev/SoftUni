using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Listyterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> data;
        private int index;

        public ListyIterator(List<T> data)
        {
            this.data = data;
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.data.Count)
            {
                return true;
            }

            return false;
        }

        public string Print()
        {
            if (this.data.Count == 0)
            {
                return "Invalid Operation!";
            }
            return this.data[index].ToString();
        }

        public void Add(params T[] data)
        {
            this.data = data.ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public string PrintAll()
        {
            return $"{string.Join(" ", data)}";
        }
    }
}
