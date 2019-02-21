using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> Books;

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
            
        }
        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {

            private readonly List<Book> books;
            private int index;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                this.index = -1;
            }

            public Book Current
            {
                get => this.books[index];
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                this.index++;
                if (this.index < this.books.Count)
                {
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
