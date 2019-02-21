using IteratorsAndComparators;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BookComparator
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            var titleCompare = first.Title.CompareTo(second.Title);
            if (titleCompare == 0)
            {
                return second.Year - first.Year;
            }

            return titleCompare;
        }
    }
}
