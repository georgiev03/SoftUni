using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "course start")
                {
                    break;
                }

                string[] line = input.Split(':');
                string command = line[0];

                string lessonTitle = line[1];

                if (command == "Add")
                {
                    if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Add(lessonTitle);
                    }
                }
                else if (command == "Insert")
                {
                    int idx = int.Parse(line[2]);

                    if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Insert(idx, lessonTitle);
                    }
                }
                else if (command == "Remove")
                {
                    lessons.Remove(lessonTitle);
                }
                else if (command == "Swap")
                {
                    string secondTitle = line[2];
                    int firstIdx = lessons.IndexOf(lessonTitle);
                    int secondIdx = lessons.IndexOf(secondTitle);

                    if (lessons.Contains(lessonTitle) && lessons.Contains(secondTitle))
                    {

                        lessons[firstIdx] = secondTitle;
                        lessons[secondIdx] = lessonTitle;
                    }
                    if (lessons.Contains($"{lessonTitle}-Exercise") && lessons.Contains(lessonTitle))
                    {
                        lessons.Remove($"{lessonTitle}-Exercise");
                        lessons.Insert(secondIdx + 1, $"{lessonTitle}-Exercise");
                    }
                    else if (lessons.Contains($"{secondTitle}-Exercise") && lessons.Contains(secondTitle))
                    {
                        lessons.Remove($"{secondTitle}-Exercise");
                        lessons.Insert(firstIdx + 1, $"{secondTitle}-Exercise");
                    }

                }
                else
                {
                    if (lessons.Contains(lessonTitle) && !lessons.Contains($"{lessonTitle}-Exercise"))
                    {
                        int idx = lessons.IndexOf(lessonTitle);
                        lessons.Insert(idx, $"{lessonTitle}-Exercise");
                    }
                    else if (!lessons.Contains(lessonTitle))
                    {
                        lessons.Add(lessonTitle);
                        lessons.Add($"{lessonTitle}-Exercise");
                    }
                }
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
