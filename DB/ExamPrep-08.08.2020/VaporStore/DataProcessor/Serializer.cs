using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context
                .Genres
                .ToArray()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                        .Where(game => game.Purchases.Any())
                        .Select(game => new
                        {
                            Id = game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = string.Join(", ", game.GameTags.Select(gt => gt.Tag.Name)),
                            Players = game.Purchases.Count
                        })
                        .OrderByDescending(game => game.Players)
                        .ThenBy(game => game.Id)
                        .ToArray(),
                    TotalPlayers = g.Games.Sum(game => game.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            var serializedGenres = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return serializedGenres;
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var sb = new StringBuilder();
            using StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            Enum.TryParse(storeType, out PurchaseType type);

            var purchases = context
                .Purchases
                .Where(p=> p.Type == type)
                .Select(p => new ExportUserDto()
                {
                    Username = p.Card.User.Username,
                    Purchase = new ExportUserPurchaseDto()
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportPurchaseGameDto()
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price.ToString("f2")
                        }
                    }
                })
                .OrderByDescending(u=> u.Purchase.Game.Price)

            var users = context
                .Users
                .Where(u => u.Cards.Select(c => c.Purchases)
                    .Any(p => p.Select(a => a.Type).Any(a => a == type)))
                .Select(u => new ExportUserDto()
                {
                    Username = u.Username,
                    Purchase = new ExportUserPurchaseDto()
                    {
                        Card = u.Cards
                    }
                });
        }
	}
}