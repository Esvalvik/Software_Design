using System;

namespace SnakeGood
{
	public class Board
	{
		private Vector2 _windowSize = new Vector2(Console.WindowWidth, Console.WindowHeight);
        private Snake _snake;
        private Food _food;

        public static int STATE_INIT = 0, STATE_RUNNING = 1, STATE_PAUSED = 2, STATE_GAMEOVER = 3;
        public int GameState { get; set; }
		public Board()
		{
            GameState = Board.STATE_INIT;
			_snake = new Snake(4);
			_food = new Food(_windowSize);
			for(int i = 0; i < 10; i++)
			{
				_food.Position = _food.NewPosition(_windowSize);
				Console.WriteLine("\nNew food pos: " + _food.Position.ToString);
				Console.ReadLine();
			}
		}

        public void Logic()
        {
            
        }
	}
}