using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }

        public Book(string title, int year, params string[] names)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>();
            for (int i = 0; i < names.Length; i++)
            {
                Authors.Add(names[i]);
            }
        }
    }
}
