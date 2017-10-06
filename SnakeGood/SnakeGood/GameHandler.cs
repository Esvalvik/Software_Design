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
        static void Main(string[] args)
        {
            Init();
            while (_gameState != STATE_GAMEOVER)
            {
                if (_timer.ElapsedMilliseconds > 100)
                {
                    // Game is running
                    if (_gameState != STATE_PAUSED)
                    {
                        Update();
                    }
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
        }

        //Upating the board
        public static void Update()
        {
            //Gameover motherfucker
            Console.WriteLine("Tick");
        }
    }
}