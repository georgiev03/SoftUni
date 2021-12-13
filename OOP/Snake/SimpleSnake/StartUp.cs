﻿using SimpleSnake.Core;
using SimpleSnake.GameObjects;

namespace SimpleSnake
{
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(30, 30);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
