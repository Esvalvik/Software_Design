using System;

namespace SnakeGood
{
	public class Board
	{
		Vector2 _windowSize = new Vector2(Console.WindowWidth, Console.WindowHeight);
		Snake _snake;
		Food _food;

		public Board()
		{
			_snake = new Snake(4);
			_food = new Food(_windowSize);
			for(int i = 0; i < 10; i++)
			{
				_food.Position = _food.NewPosition(_windowSize);
				Console.WriteLine("\nNew food pos: " + _food.Position.ToString);
				Console.ReadLine();
			}
		}


	}
}