using System.Linq;

namespace _01.Database
{
    using System;
    using System.Collections.Generic;

    public class Database
    {
        private const int DefaultSize = 16;

        private int[] data;
        private int index;

        public Database(params int[] initialNumbers)
        {
            this.index = 0;
            this.DatabaseElements = initialNumbers;
        }

        public int[] DatabaseElements
        {
            get
            {
                List<int> numbers = new List<int>();
                for (int i = 0; i < index; i++)
                {
                    numbers.Add(data[i]);
                }

                return numbers.ToArray();
            }
            private set
            {
                if (value.Length > DefaultSize || value.Length < 1)
                {
                    throw new InvalidOperationException("Invalid size!");
                }

                this.data = new int[DefaultSize];

                for (int i = 0; i < value.Length; i++)
                {
                    this.data[this.index] = value[i];
                    this.index++;
                }
            }
        }

        public void Add(int numberToAdd)
        {
            if (index == 16)
            {
                throw new InvalidOperationException("Database is full!");
            }

            data[this.index] = numberToAdd;
            index++;
        }

        public void Remove()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.data[index - 1] = default(int);
            this.index--;
        }
    }
}
