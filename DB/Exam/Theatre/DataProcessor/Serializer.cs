using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;

namespace Theatre.DataProcessor
{
    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context
                .Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                        .Sum(x => x.Price),
                    Tickets = t.Tickets
                        .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                        .Select(x => new
                        {
                            Price = x.Price,
                            RowNumber = x.RowNumber
                        })
                        .OrderByDescending(x => x.Price)
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            var result = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var sb = new StringBuilder();

            using StringWriter writer = new StringWriter(sb);

            var plays = context
                .Plays
                .ToArray()
                .Where(p => p.Rating <= rating || p.Rating == 0)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .ToArray()
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ExportActorDto()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRoot);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            xmlSerializer.Serialize(writer, plays, namespaces);

            return sb.ToString().Trim();
        }
    }
}
