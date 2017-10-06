using System;
using System.Diagnostics;

namespace SnakeGood
{

    //Class for handling the game
    public class GameHandler
    {
        private static Board _board;
        private static Stopwatch _timer;

        static void Main(string[] args)
        {
            Init();
            while (_board.GameState != Board.STATE_GAMEOVER)
            {
                if (_timer.ElapsedMilliseconds > 100)
                {
                    Input();
                    Update();
                    _timer.Restart();
                }
            }
        }

        //For initializing the game
        public static void Init()
        {
            _board = new Board();
            _timer = new Stopwatch();
            _timer.Start();
            _board.GameState = Board.STATE_RUNNING;
        }

        //Upating the board
        public static void Update()
        {
            //Gameover motherfucker
            if (_board.GameState == Board.STATE_RUNNING)
            {
                _board.Logic();
            }
        }

        public static void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo readKey = Console.ReadKey(true);
                if (readKey.Key == ConsoleKey.Escape)
                    _board.GameState = Board.STATE_GAMEOVER;
                else if (readKey.Key == ConsoleKey.Spacebar)
                    _board.GameState = (_board.GameState != Board.STATE_PAUSED) ? Board.STATE_PAUSED : Board.STATE_RUNNING;

                if (_board.GameState == Board.STATE_RUNNING)
                {
                    if (readKey.Key == ConsoleKey.UpArrow && _board.Snake.LastDirection != 2)
                        _board.Snake.Direction = 0;
                    else if (readKey.Key == ConsoleKey.RightArrow && _board.Snake.LastDirection != 3)
						_board.Snake.Direction = 1;
                    else if (readKey.Key == ConsoleKey.DownArrow && _board.Snake.LastDirection != 0)
						_board.Snake.Direction = 2;
                    else if (readKey.Key == ConsoleKey.LeftArrow && _board.Snake.LastDirection != 1)
						_board.Snake.Direction = 3;
                }
            }
        }
    }
}