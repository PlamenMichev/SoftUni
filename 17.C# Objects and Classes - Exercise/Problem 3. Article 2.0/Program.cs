using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problem_2.__Articles
{
    class Article
    {
        public Article()
        {
        }      
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public void ToString(Article article)
        {
            Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                var input = new List<string>();
                input = Console.ReadLine()
                    .Split(", ")
                    .ToList();
                Article currentArticle = new Article();
                currentArticle.Title = input[0];
                currentArticle.Content = input[1];
                currentArticle.Author = input[2];
                articles.Add(currentArticle);
            }

            string sortBy = Console.ReadLine();
            if (sortBy == "title")
            {
                foreach (var article in articles.OrderBy(x=>x.Title))
                {
                    Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                }
            }
            if (sortBy == "content")
            {
                foreach (var article in articles.OrderBy(x => x.Content))
                {
                    Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                }
            }
            if (sortBy == "author")
            {
                foreach (var article in articles.OrderBy(x => x.Author))
                {
                    Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                }
            }
        }
    }
}
