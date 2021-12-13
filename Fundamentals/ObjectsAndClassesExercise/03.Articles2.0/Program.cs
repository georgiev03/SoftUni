using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(", ");

                Article article = new Article
                {
                    Title = line[0],
                    Content = line[1],
                    Author = line[2]
                };

                articles.Add(article);
            }

            string changeBy = Console.ReadLine();

            List<Article> sorted = new List<Article>();

            if (changeBy == "title")
            {
               sorted = articles
                    .OrderBy(n => n.Title)
                    .ToList();
            }
            else if (changeBy == "content")
            {
                sorted = articles
                    .OrderBy(n => n.Content)
                    .ToList();
            }
            else
            {
                sorted = articles
                    .OrderBy(n => n.Author)
                    .ToList();
            }
            
            foreach (var article in sorted)
            {
                Console.WriteLine(article);
            }
        }
    }
}
