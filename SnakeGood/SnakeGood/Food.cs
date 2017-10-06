using System;

namespace SnakeGood
{
	public class Food
	{
		Random _rnd = new Random();

		public Vector2 Position { get; set; }

		public Food(Vector2 size)
		{
			Position = NewPosition(size);
		}

		//Generate a new random for the food within gamewindow
		public Vector2 NewPosition(Vector2 size)
		{
			return new Vector2(_rnd.Next(0, size.X), _rnd.Next(0, size.Y));
		}

	}
}
