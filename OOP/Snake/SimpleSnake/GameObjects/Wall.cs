using System;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        public const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            InitialiseWallBorders();
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 ||
                   snake.LeftX == this.LeftX - 1 || snake.TopY == this.TopY;
        }

        private void SetHorizontalWall(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalWall(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        private void InitialiseWallBorders()
        {
            SetHorizontalWall(0);
            SetHorizontalWall(this.TopY);

            SetVerticalWall(0);
            SetVerticalWall(this.LeftX - 1);
        }
    }
}
