using System;
using System.Diagnostics;

namespace SnakeGood
{
    //Class for handling the game
    public class GameHandler
    {
        private static int _gameSpeed = 100;
        private static Board _board;
        private static Stopwatch _timer;

        static void Main(string[] args)
        {
            Init();
            while (_board.GameState != Board.STATE_GAMEOVER)
            {
                if (_timer.ElapsedMilliseconds > _gameSpeed)

                {
                    Input();
                    Update();

                    _timer.Restart();
                }
            }
            // Game over
        }

        //For initializing the game
        public static void Init()
        {
            Console.Title = "Westerdals Oslo ACT - SNAKE";
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
                _board.Draw();
            }
        }

        public static void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo readKey = Console.ReadKey(true);

                // Escape or pause game
                if (readKey.Key == ConsoleKey.Escape)
                    _board.GameState = Board.STATE_GAMEOVER;
                else if (readKey.Key == ConsoleKey.Spacebar)
                    _board.GameState = (_board.GameState != Board.STATE_PAUSED) ? Board.STATE_PAUSED : Board.STATE_RUNNING;

                // Change snake direction
                if (_board.GameState == Board.STATE_RUNNING)
                {
                    if (readKey.Key == ConsoleKey.UpArrow && _board.Snake.LastDirection != Snake.Direction.DOWN)
                        _board.Snake.CurrentDirection = Snake.Direction.UP;
                    else if (readKey.Key == ConsoleKey.RightArrow && _board.Snake.LastDirection != Snake.Direction.LEFT)
                        _board.Snake.CurrentDirection = Snake.Direction.RIGHT;
                    else if (readKey.Key == ConsoleKey.DownArrow && _board.Snake.LastDirection != Snake.Direction.UP)
                        _board.Snake.CurrentDirection = Snake.Direction.DOWN;
                    else if (readKey.Key == ConsoleKey.LeftArrow && _board.Snake.LastDirection != Snake.Direction.RIGHT)
                        _board.Snake.CurrentDirection = Snake.Direction.LEFT;
                }
            }
        }
    }
}