namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count > 0))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = $"{m.Rating:f2}",
                    TotalIncomes = $"{m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)):f2}",
                    Customers = m.Projections
                                    .SelectMany(p => p.Tickets)
                                    .Select(t => new
                                    {

                                        t.Customer.FirstName,
                                        t.Customer.LastName,
                                        Balance = $"{t.Customer.Balance:f2}"

                                    })
                                    .OrderByDescending(p => p.Balance)
                                    .ThenBy(p => p.FirstName)
                                    .ThenBy(p => p.LastName)
                })
                .OrderByDescending(m => double.Parse(m.Rating))
                .ThenByDescending(m => decimal.Parse(m.TotalIncomes))
                .Take(10);

            var result = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return result;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var serializer = new XmlSerializer(typeof(ExportCustomerDto[]),
                new XmlRootAttribute("Customers"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var customers = context.Customers
                .Where(c => c.Age >= age)
                .Select(c => new ExportCustomerDto
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    SpentMoney = $"{c.Tickets.Sum(t => t.Price):f2}",
                    SpentTime = TimeSpan.FromMilliseconds(c.Tickets
                                    .Select(t => t.Projection)
                                    .Sum(p => p.Movie.Duration.TotalMilliseconds))
                                    .ToString(@"hh\:mm\:ss")
                })
                .OrderByDescending(c => Decimal.Parse(c.SpentMoney))
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}