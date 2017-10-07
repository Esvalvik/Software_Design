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

        public void Draw()
        {
            DoubleBuffer();
            Food.Draw();
            Snake.Draw();
        }

        private void DoubleBuffer()
        {
            string buffer = "";
            char[,] map = new char[_windowSize.X, _windowSize.Y];
            for (int x = 0; x < _windowSize.X; x++)
            {
                for (int y = 0; y < _windowSize.Y; y++)
                {
                    map[x, y] = ' ';
                }
            }

            // Add snake to buffer
            foreach(Vector2 bodyPart in Snake.Body)
            {
                map[bodyPart.X, bodyPart.Y] = Snake.ICON;
            }

            // Add food to buffer
            map[Food.Position.X, Food.Position.Y] = Food.ICON;

            // Clear screen and load buffer
            Console.Clear();
            Console.Write(buffer);
        }
	}
}