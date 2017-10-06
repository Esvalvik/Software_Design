using System;

namespace Snake
{
	Random _rnd = new Random();

	public class Food
	{
		public Vector2 Position { get; set; }

		public Food(Vector2 size)
		{
			position = NewPosition(size);
		}

		//Generate a new random for the food within gamewindow
		public static Vector2 NewPosition(Vector2 size)
		{
			return new Vector2(rnd.Next(0, size.X), rnd.Next(0, size.Y));
		}


	}
}