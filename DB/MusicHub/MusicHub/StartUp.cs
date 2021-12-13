
using MusicHub.Initializer;

namespace MusicHub
{
    using System;

    using System.Linq;
    using System.Globalization;
    using System.Text;
    using Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context, 4).Length);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albumsInfo = context
                .Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    Name = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy",
                        CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .ToArray()
                        .Select(s => new
                        {
                            SongName = s.Name,
                            WriterName = s.Writer.Name,
                            s.Price
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.WriterName)
                        .ToArray(),
                    Price = a.Price
                })
                .ToArray();

            foreach (var a in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {a.Name}")
                    .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                    .AppendLine($"-ProducerName: {a.ProducerName}")
                    .AppendLine("-Songs:");

                int songCount = 1;
                foreach (var s in a.Songs)
                {
                    sb
                        .AppendLine($"---#{songCount++}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.Price:f2}")
                        .AppendLine($"---Writer: {s.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {a.Price:f2}");
            }
            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songs = context
                .Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers
                        .ToArray()
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault(),
                    Producer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c",
                        CultureInfo.InvariantCulture)
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToArray();

            int i = 1;
            foreach (var s in songs)
            {
                sb
                    .AppendLine($"-Song #{i++}")
                    .AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.Writer}")
                    .AppendLine($"---Performer: {s.Performer}")
                    .AppendLine($"---AlbumProducer: {s.Producer}")
                    .AppendLine($"---Duration: {s.Duration}");
            }

            return sb.ToString().Trim();
        }
    }
}
