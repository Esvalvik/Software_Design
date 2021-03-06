﻿using System;

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
            Console.CursorVisible = false;
            GameState = Board.STATE_INIT;
			Snake = new Snake(4);
			Food = new Food(_windowSize);
		}

        public void Logic()
        {
            Snake.Move();
            // Snake found food
            if (Food.Position == Snake.Body[Snake.Head] && Food.LastPosition != Snake.Body[Snake.Head])
            {
                Food.Position = Food.NewPosition(_windowSize);
                Snake.Grow();
            }
            // Snake is out of map
            else if (Snake.Body[Snake.Head].X >= _windowSize.X || Snake.Body[Snake.Head].X < 0 || Snake.Body[Snake.Head].Y >= _windowSize.Y || Snake.Body[Snake.Head].Y < 0)
            {
                GameState = STATE_GAMEOVER;
            }
            // Snake eats itself
            else if (Snake.PosTaken(Snake.Body[Snake.Head], false))
            {
                GameState = STATE_GAMEOVER;
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
                if(bodyPart.X >= 0 && bodyPart.Y >= 0 && bodyPart.X < _windowSize.X && bodyPart.Y < _windowSize.Y)
                    map[bodyPart.X, bodyPart.Y] = Snake.ICON;
            }

            // Add food to buffer
            map[Food.Position.X, Food.Position.Y] = Food.ICON;

            // Clear screen and load buffer
            ClearConsole();
            // Reset cursor and write buffer to 
            Console.SetCursorPosition(0, 0);
            Console.Write(buffer);
        }

        private void ClearConsole()
        {
            string spaceString = "";
            for (int x = 0; x < (_windowSize.X*_windowSize.Y); x++)
            {

                spaceString += " ";
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(spaceString);
        }
	}
}