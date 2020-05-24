using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace _01.Listyterator
{
    public class ListyIterator<T>
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
    }
}
