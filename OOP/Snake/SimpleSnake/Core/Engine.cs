using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] pointsOfDirections;
        private Direction direction;
        private Snake snake;
        private double sleepTime;
        private Wall wall;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100;
            this.pointsOfDirections = new Point[4];
        }
        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = this.snake.IsMoving(this.pointsOfDirections[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            var userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.Y)
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(wall.LeftX + 1 ,10);
            Console.Write("Game over");
            Environment.Exit(0);
        }
        private void CreateDirections()
        {
            this.pointsOfDirections[0] = new Point(1, 0); //rights
            this.pointsOfDirections[1] = new Point(-1, 0); //left
            this.pointsOfDirections[2] = new Point(0, 1); //down
            this.pointsOfDirections[3] = new Point(0, -1); //up
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }

            Console.CursorVisible = false;
        }
    }
}
