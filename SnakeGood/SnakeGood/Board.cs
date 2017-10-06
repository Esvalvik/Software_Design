using System;

namespace SnakeGood
{
	public class Board
	{
		private Vector2 _windowSize = new Vector2(Console.WindowWidth, Console.WindowHeight);
        public Snake Snake;
        public Food Food;

        public static int STATE_INIT = 0, STATE_RUNNING = 1, STATE_PAUSED = 2, STATE_GAMEOVER = 3;
        public int GameState { get; set; }
		public Board()
		{
            GameState = Board.STATE_INIT;
			Snake = new Snake(4);
			Food = new Food(_windowSize);
		}

        public void Logic()
        {
            Snake.Move();
			if(Food.Position == Snake.Body[Snake.Head])
			{
				Food.Position = Food.NewPosition(_windowSize);
				Snake.Grow();
			}
        }
	}
}