using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _04.BookComparator;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library()
        {
            this.books = new SortedSet<Book>(new BookComparer());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in books)
            {
                yield return book;
            }
        }

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
            
        }
        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        
    }
}
