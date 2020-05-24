using System;
using System.Collections.Generic;
using System.Text;

namespace P02.BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get => this.author;
            set
            {
                if (!ValidateAuthor(value))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public bool ValidateAuthor(string name)
        {
            string[] splitName = name.Split();
            if (splitName.Length == 2)
            {
                string firstName = splitName[0];
                string secName = splitName[1];

                if (char.IsDigit(secName[0]))
                {
                    return false;
                }

                return true;
            }
            else
            {
                return true;
            }
            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Type: Book");
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Author: {this.Author}");
            sb.Append($"Price: {this.Price:f2}");

            return sb.ToString();
        }
    }
}
