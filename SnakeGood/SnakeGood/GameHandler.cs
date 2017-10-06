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
                    if (readKey.Key == ConsoleKey.UpArrow && _lastDir != 2)
                        _currentDir = 0;
                    else if (readKey.Key == ConsoleKey.RightArrow && _lastDir != 3)
                        _currentDir = 1;
                    else if (readKey.Key == ConsoleKey.DownArrow && _lastDir != 0)
                        _currentDir = 2;
                    else if (readKey.Key == ConsoleKey.LeftArrow && _lastDir != 1)
                        _currentDir = 3;
                }
            }
        }
    }
}