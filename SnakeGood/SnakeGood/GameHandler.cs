using System;
using System.Diagnostics;

namespace SnakeGood
{

    //Class for handling the game
    public class GameHandler
    {
        private static Board _board;
        private const int STATE_INIT = 0, STATE_RUNNING = 1, STATE_PAUSED = 2, STATE_GAMEOVER = 3;
        private static int _gameState = STATE_INIT;
        private static Stopwatch _timer;

        private static int _currentDir = 0;
        private static int _lastDir = 0;
        static void Main(string[] args)
        {
            Init();
            while (_gameState != STATE_GAMEOVER)
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
            _gameState = STATE_RUNNING;
        }

        //Upating the board
        public static void Update()
        {
            //Gameover motherfucker
            if (_gameState == STATE_RUNNING)
            {
                Console.WriteLine("Tick");
            }
        }

        public static void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo readKey = Console.ReadKey(true);
                if (readKey.Key == ConsoleKey.Escape)
                    _gameState = STATE_GAMEOVER;
                else if (readKey.Key == ConsoleKey.Spacebar)
                    _gameState = (_gameState != STATE_PAUSED) ? STATE_PAUSED : STATE_RUNNING;

                if (_gameState == STATE_RUNNING)
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