using System;
using System.Reflection.Metadata.Ecma335;

namespace _02.Articles
{
    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] articleData = Console.ReadLine().Split(", ");

            Article article = new Article()
            {

                Title = articleData[0],
                Content = articleData[1],
                Author = articleData[2]
            };

            int changes = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < changes; i++)
            {
                string[] line = Console.ReadLine().Split(": ");

                string command = line[0];
                string param = line[1];

                switch (command)
                {
                    case "Edit":
                        article.Edit(param);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(param);
                        break;
                    case "Rename":
                        article.Rename(param);
                        break;
                }
            }

            Console.WriteLine(article);
        }
    }
}
