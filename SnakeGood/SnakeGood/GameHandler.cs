﻿using System;

namespace SnakeGood
{

    //Class for handling the game
    public class GameHandler
    {
        private static Board _board;
        private const int STATE_INIT = 0, STATE_RUNNING = 1, STATE_PAUSED = 2, STATE_GAMEOVER = 3;
        private static int _gameState = STATE_INIT;
        private 
        private long 
        static void Main(string[] args)
        {
            Init();
            while (_gameState != STATE_GAMEOVER)
            {
                // Game is running
                if (_gameState != STATE_PAUSED)
                {
                    Update();
                }
            }
        }

        //For initializing the game
        public static void Init()
        {
            _board = new Board();
        }

        //Upating the board
        public static void Update()
        {
            //Gameover motherfucker
            _gameState = STATE_GAMEOVER;
        }
    }
}