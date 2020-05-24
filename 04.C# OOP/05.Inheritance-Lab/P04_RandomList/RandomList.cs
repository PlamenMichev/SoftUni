using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private List<string> list;

        public RandomList()
        {
            this.list = new List<string>();
        }

        public void Add(string item)
        {
            list.Add(item);
        }

        public string RandomString()
        {
            Random rand = new Random();
            int index = rand.Next(0, list.Count);

            string stringToRemove = list[index];
            list.RemoveAt(index);

            return stringToRemove;
        }
    }
}
