using System;
using System.Collections.Generic;

namespace _03.Songs
{
    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split('_');

                string type = line[0];
                string name = line[1];
                string time = line[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string typeList = Console.ReadLine();
            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            foreach (Song song in songs)
            {
                if (typeList == song.TypeList)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}
