using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problem_2.__Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public void ToString(Article article)
        {
            Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new List<string>();
            input = Console.ReadLine()
                .Split(", ")
                .ToList();
            Article article = new Article(input[0], input[1], input[2]);
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(": ")
                    .ToArray();
                string command = tokens[0];
                string newWord = tokens[1];
                if (command == "Edit")
                {
                    article.Edit(newWord);
                }

                if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(newWord);
                }

                if (command == "Rename")
                {
                    article.Rename(newWord);
                }

                if (command == "ToString")
                {
                    article.ToString(article);
                }
            }
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}
