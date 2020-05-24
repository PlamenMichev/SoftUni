namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ExportDto;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    g.Id,
                    Genre = g.Name,
                    Games = g.Games
                            .Where(x => x.Purchases.Any())
                            .Select(x => new
                            {
                                x.Id,
                                Title = x.Name,
                                Developer = x.Developer.Name,
                                Tags = string.Join(", ", x.GameTags.Select(y => y.Tag.Name)),
                                Players = x.Purchases.Count
                            })
                            .OrderByDescending(x => x.Players)
                            .ThenBy(x => x.Id),
                    TotalPlayers = g.Games.Sum(x => x.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .OrderBy(g => g.Id);

            var result = JsonConvert.SerializeObject(genres, Formatting.Indented);
            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var serializer = new XmlSerializer(typeof(ExportUserDto[]),
                new XmlRootAttribute("Users"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            var result = new StringBuilder();

            var users = context.Users
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = u.Cards
                                    .SelectMany(c => c.Purchases)
                                    .Where(p => p.Type.ToString() == storeType)
                                    .Select(p => new ExportPurchaseDto
                                    {
                                        CardNumber = p.Card.Number,
                                        Cvc = p.Card.Cvc,
                                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                        Game = new ExportGameDto
                                        {
                                            Title = p.Game.Name,
                                            Genre = p.Game.Genre.Name,
                                            Price = p.Game.Price
                                        }
                                    })
                                    .OrderBy(p => p.Date)
                                    .ToArray(),
                    TotalSpent = u.Cards
                                    .SelectMany(c => c.Purchases)
                                    .Where(p => p.Type.ToString() == storeType)
                                    .Sum(p => p.Game.Price)

                })
                .Where(u => u.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, users, namespaces);
            }


            return result.ToString().TrimEnd();
        }
    }
}