namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Enums;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var sb = new StringBuilder();
            var games = new List<Game>();
            var tags = new List<Tag>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            foreach (var gameDto in gameDtos)
            {
                var validTags = gameDto.Tags.Any();
                if (!IsValid(gameDto) ||
                    !validTags)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else
                {
                    Developer developer = developers.FirstOrDefault(x => x.Name == gameDto.Developer);
                    Genre genre = genres.FirstOrDefault(x => x.Name == gameDto.Genre);
                    if (developer == null)
                    {
                        developer = new Developer()
                        {
                            Name = gameDto.Developer
                        };
                        developers.Add(developer);
                    }

                    if (genre == null)
                    {
                        genre = new Genre
                        {
                            Name = gameDto.Genre,
                        };
                        genres.Add(genre);
                    }

                    var game = new Game
                    {
                        Name = gameDto.Name,
                        Price = gameDto.Price,
                        ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Developer = developer,
                        Genre = genre
                    };
                    foreach (var tag in gameDto.Tags)
                    {
                        Tag currentTag = tags.FirstOrDefault(x => x.Name == tag);
                        if (currentTag == null)
                        {
                            currentTag = new Tag()
                            {
                                Name = tag,
                            };
                            tags.Add(currentTag);
                        }

                        if (!IsValid(currentTag))
                        {
                            tags.Remove(currentTag);
                            continue;
                        }

                        game.GameTags.Add(new GameTag
                        {
                            Tag = currentTag
                        });
                    }

                    games.Add(game);

                    sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
                }
            }

            context.Games.AddRange(games);
            context.Genres.AddRange(genres);
            context.Tags.AddRange(tags);
            context.Developers.AddRange(developers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var sb = new StringBuilder();
            var users = new List<User>();
            var cards = new List<Card>();
            foreach (var userDto in userDtos)
            {
                var areCardsValid = userDto.Cards.Any(c => IsValid(c));
                var areEnumsValid = userDto.Cards.Any(c => Enum.IsDefined(typeof(CardType), c.Type));
                if (!areCardsValid ||
                    !IsValid(userDto) ||
                    !areEnumsValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else
                {
                    var user = new User()
                    {
                        Username = userDto.Username,
                        FullName = userDto.FullName,
                        Age = userDto.Age,
                        Email = userDto.Email
                    };

                    foreach (var cardDto in userDto.Cards)
                    {
                        var card = new Card()
                        {
                            Cvc = cardDto.Cvc,
                            Number = cardDto.Number,
                            Type = (CardType)Enum.Parse(typeof(CardType), cardDto.Type)
                        };

                        user.Cards.Add(card);
                        cards.Add(card);
                    }

                    users.Add(user);
                    sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
                }
            }

            context.Users.AddRange(users);
            context.Cards.AddRange(cards);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportPurchaseDto[]),
                new XmlRootAttribute("Purchases"));

            var sb = new StringBuilder();
            var purchases = new List<Purchase>();
            ImportPurchaseDto[] purchasesDtos;
            using (var reader = new StringReader(xmlString))
            {
                purchasesDtos = (ImportPurchaseDto[])
                    serializer.Deserialize(reader);
            }

            foreach (var purchaseDto in purchasesDtos)
            {
                var areCardValid = context.Cards.Any(c => c.Number == purchaseDto.CardNumber);
                var areGameValid = context.Games.Any(g => g.Name == purchaseDto.Title);
                var areTypeValid = Enum.IsDefined(typeof(PurchaseType), purchaseDto.Type);

                if (!IsValid(purchaseDto) ||
                    !areCardValid ||
                    !areGameValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else
                {
                    var card = context.Cards.First(c => c.Number == purchaseDto.CardNumber);
                    var game = context.Games.First(g => g.Name == purchaseDto.Title);

                    var purchase = new Purchase()
                    {
                        Card = card,
                        Game = game,
                        ProductKey = purchaseDto.ProductKey,
                        Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDto.Type),
                        Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                    };

                    purchases.Add(purchase);
                    sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
                }
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, validationContext, results, true);

            return isValid;
        }
    }
}