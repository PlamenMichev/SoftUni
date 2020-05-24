namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var restrictionBooks = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            var result = new StringBuilder();
            foreach (var book in restrictionBooks)
            {
                result.AppendLine(book);
            }

            return result.ToString();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context
                .Books
                .Where(b => b.EditionType.ToString() == "Gold"
                            && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = new StringBuilder();
            foreach (var book in goldenBooks)
            {
                result.AppendLine(book);
            }

            return result.ToString();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            var answer = new StringBuilder();
            foreach (var book in books)
            {
                answer.AppendLine(book.Title + " - $" + $"{book.Price:f2}");
            }

            return answer.ToString();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var titles = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = new StringBuilder();
            foreach (var title in titles)
            {
                result.AppendLine(title);
            }

            return result.ToString();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var books = context
                .Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            var result = new StringBuilder();
            foreach (var book in books)
            {
                result.AppendLine(book);
            }

            return result.ToString();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new 
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            var result = new StringBuilder();
            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return result.ToString();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();
            var result = new StringBuilder();
            foreach (var name in authors)
            {
                result.AppendLine(name.FullName);
            }

            return result.ToString();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var checkString = input.ToLower();
            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(checkString))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            var result = new StringBuilder();
            foreach (var book in books)
            {
                result.AppendLine(book);
            }

            return result.ToString();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();

            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            var result = new StringBuilder();
            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return result.ToString();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    CopiesCount = a
                                    .Books
                                    .Sum(b => b.Copies),
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderByDescending(a => a.CopiesCount)
                .ToList();

            var result = new StringBuilder();
            foreach (var author in authors)
            {
                result.AppendLine($"{author.FullName} - {author.CopiesCount}");
            }

            return result.ToString();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks
                                .Select(cb => new
                                {
                                    ProfitPerBook = cb.Book.Price * cb.Book.Copies,
                                })
                                .Sum(cb => cb.ProfitPerBook)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            var result = new StringBuilder();
            foreach (var category in categories)
            {
                result.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return result.ToString();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    Books = c.CategoryBooks
                            .OrderByDescending(cb => cb.Book.ReleaseDate)
                            .Select(cb => new
                            {
                                cb.Book.Title,
                                cb.Book.ReleaseDate.Value.Year
                            })
                            .Take(3)
                            .ToList(),
                    c.Name
                })
                .OrderBy(c => c.Name);

            var result = new StringBuilder();
            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    result.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return result.ToString();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            //var books = context
            //    .Books
            //    .Where(b => b.ReleaseDate.Value.Year < 2010)
            //    .Update(b => new Book { Price = b.Price + 5m });
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();
            return books.Count();
        }

        public static void Main()
        {
            var context = new BookShopContext();
            Console.WriteLine(RemoveBooks(context));
            Console.WriteLine(context.Books.Count());
        }
    }
}
