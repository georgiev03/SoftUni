using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            ICollection<Game> games = new HashSet<Game>();
            List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto) || IsNullOrEmpty(gameDto.Developer) ||
                    IsNullOrEmpty(gameDto.Name) || IsNullOrEmpty(gameDto.ReleaseDate) ||
                    IsNullOrEmpty(gameDto.Genre) || !gameDto.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParse(gameDto.ReleaseDate, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime releaseDate))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var developer = games.Select(g => g.Developer)
                    .FirstOrDefault(d => d.Name == gameDto.Developer);
                if (developer is null)
                {
                    developer = new Developer()
                    {
                        Name = gameDto.Developer
                    };
                }

                var genre = games.Select(g => g.Genre).FirstOrDefault(g => g.Name == gameDto.Genre);
                if (genre is null)
                {
                    genre = new Genre()
                    {
                        Name = gameDto.Genre
                    };
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var tagNameDto in gameDto.Tags)
                {
                    var tag = tags.FirstOrDefault(t => t.Name == tagNameDto);
                    if (tag == null)
                    {
                        tag = new Tag()
                        {
                            Name = tagNameDto
                        };

                        tags.Add(tag);
                    }

                    game.GameTags.Add(new GameTag() { Tag = tag });
                }

                games.Add(game);

                sb.AppendLine($"Added {game.Name} ({genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsNullOrEmpty(string s) => string.IsNullOrEmpty(s);

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            ICollection<User> users = new HashSet<User>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                bool notValidCard = false;
                ICollection<Card> cards = new HashSet<Card>();

                foreach (var cardDto in userDto.Cards)
                {
                    if (!Enum.TryParse(cardDto.Type, out CardType cardType))
                    {
                        sb.AppendLine(ErrorMessage);
                        notValidCard = true;
                        break;
                    }

                    Card card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = cardType
                    };

                    cards.Add(card);
                }

                if (notValidCard)
                {
                    break;
                }

                user.Cards = cards;
                users.Add(user);

                sb.AppendLine($"Imported {user.Username} with {cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            using StringReader reader = new StringReader(xmlString);
            
                
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);

            var purchaseDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(reader);
            ICollection<Purchase> purchases = new HashSet<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = context
                    .Games
                    .FirstOrDefault(g => g.Name == purchaseDto.GameTitle);

                if (game is null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var card = context
                    .Cards
                    .FirstOrDefault(c => c.Number == purchaseDto.Card);

                if (card is null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.TryParse(purchaseDto.Type, out PurchaseType type))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime purchaseDate))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }
                //if (!DateTime.TryParse(purchaseDto.Date, CultureInfo.InvariantCulture,
                //    DateTimeStyles.None, out DateTime purchaseDate))
                //{
                //    sb.AppendLine(ErrorMessage);
                //    continue;
                //}

                var purchase = new Purchase()
                {
                    Game = game,
                    Card = card,
                    Type = type,
                    ProductKey = purchaseDto.Key,
                    Date = purchaseDate
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {game.Name} for {card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}