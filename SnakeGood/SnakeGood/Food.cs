using System;

namespace SnakeGood
{
	public class Food
	{
        public const char ICON = '$';
        public const ConsoleColor COLOR = ConsoleColor.Green;
        private Vector2 _position = new Vector2(10, 10);
        private Random _rnd = new Random();

		public Vector2 Position { get { return _position; } set { LastPosition = Position; _position = value; } }
        public Vector2 LastPosition { get; set; }

		public Food(Vector2 size)
		{
            // Init last pos
			Position = NewPosition(size);
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
