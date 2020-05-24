using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> Books;

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in Books.OrderBy(x => x))
            {
                yield return book;
            }
        }

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
            
        }
        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        
    }
}
