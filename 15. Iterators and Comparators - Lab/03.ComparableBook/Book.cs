using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public List<string> Authors { get; private set; }

        public Book(string title, int year, params string[] names)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = names.ToList();
        }

        public int CompareTo(Book other)
        {
            var result = this.Year - other.Year;
            if (result == 0)
            {
                return this.Title.CompareTo(other.Title);
            }
            else
            {
                return result;
            }
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
