using System;

namespace Snake
{
	public class Board
	{
		Vector2 _windowSize = new Vector2(Console.WindowWidth, Console.WindowHeight);
		Snake _snake;
		Food _food;

		public Board()
		{
			_snake = new Snake(4);
			_food = new Food(_width, _height);
		}

		
	}
}
