using System;
using System.Collections.Generic;
using System.Text;

namespace P02.BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price)
            : base(title, author, price)
        {

        }

        public override decimal Price
        {
            get => base.Price;
            set => base.Price = value + (value * 0.3m);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Type: GoldenEditionBook");
            sb.AppendLine($"Title: {base.Title}");
            sb.AppendLine($"Author: {base.Author}");
            sb.Append($"Price: {this.Price:f2}");

            return sb.ToString();
        }
    }
}
