using System;

namespace SnakeGood
{
	public class Food
	{
        public const char ICON = '$';
        public const ConsoleColor COLOR = ConsoleColor.Green;

        Random _rnd = new Random();
		public Vector2 Position { get; set; }
        public Vector2 LastPosition { get; set; }

		public Food(Vector2 size)
		{
			Position = new Vector2(10, 10);
		}

        public void Draw()
        {
            Console.ForegroundColor = COLOR;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(ICON);
        }

		//Generate a new random for the food within gamewindow
		public Vector2 NewPosition(Vector2 size)
		{
			return new Vector2(_rnd.Next(0, size.X), _rnd.Next(0, size.Y));
		}
	}
}
