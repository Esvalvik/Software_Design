using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// WARNING: DO NOT code like this. Please. EVER! 
//          "Aaaargh!" 
//          "My eyes bleed!" 
//          "I facepalmed my facepalm." 
//          Etc.
//          I had a lot of fun obfuscating this code! And I can now (proudly?) say that this is the uggliest short piece of code I've ever written!
//          (And yes, it could have been ugglier. But the idea wasn'_timer to make it fuggly-uggly, just funny-uggly or sweet-uggly.)
//
//          -Tomas
//
namespace SnakeMess
{
	class SnakeMess
    {
        public static void Main(string[] arguments)
        {
            bool _gameOver = false, _gamePaused = false, _inUse = false;
            short _newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
            short _last = _newDir;
            int _boardWidth = Console.WindowWidth, _boardHeight = Console.WindowHeight;
            Random _rng = new Random();
            Vector2 _app = new Vector2();

			List<Vector2> snake = new List<Vector2>
			{
				new Vector2(10, 10),
				new Vector2(10, 10),
				new Vector2(10, 10),
				new Vector2(10, 10)
			};

			Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(10, 10); Console.Write("@");

            while (true)
            {
                _app.X = _rng.Next(0, _boardWidth);
                _app.Y = _rng.Next(0, _boardHeight);

                bool spot = true;

                foreach (Vector2 i in snake)
                    if (i.X == _app.X && i.Y == _app.Y)
                    {
                        spot = false;
                        break;
                    }
                if (spot)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(_app.X, _app.Y);
                    Console.Write("$");
                    break;
                }
            }

            Stopwatch _timer = new Stopwatch();
            _timer.Start();

            while (!_gameOver)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Escape)
                        _gameOver = true;
                    else if (cki.Key == ConsoleKey.Spacebar)
                        _gamePaused = !_gamePaused;
                    else if (cki.Key == ConsoleKey.UpArrow && _last != 2)
                        _newDir = 0;
                    else if (cki.Key == ConsoleKey.RightArrow && _last != 3)
                        _newDir = 1;
                    else if (cki.Key == ConsoleKey.DownArrow && _last != 0)
                        _newDir = 2;
                    else if (cki.Key == ConsoleKey.LeftArrow && _last != 1)
                        _newDir = 3;
                }

                if (!_gamePaused)
                {
                    if (_timer.ElapsedMilliseconds < 100)
                        continue;
                    _timer.Restart();
                    Vector2 tail = new Vector2(snake.First());
                    Vector2 head = new Vector2(snake.Last());
                    Vector2 newH = new Vector2(head);
                    switch (_newDir)
                    {
                        case 0:
                            newH.Y -= 1;
                            break;
                        case 1:
                            newH.X += 1;
                            break;
                        case 2:
                            newH.Y += 1;
                            break;
                        default:
                            newH.X -= 1;
                            break;
                    }
                    if (newH.X < 0 || newH.X >= _boardWidth)
                        _gameOver = true;
                    else if (newH.Y < 0 || newH.Y >= _boardHeight)
                        _gameOver = true;
                    if (newH.X == _app.X && newH.Y == _app.Y)
                    {
                        if (snake.Count + 1 >= _boardWidth * _boardHeight)
                            // No more room to place apples - game over.
                            _gameOver = true;
                        else
                        {
                            while (true)
                            {
                                _app.X = _rng.Next(0, _boardWidth);
                                _app.Y = _rng.Next(0, _boardHeight);
                                bool found = true;
                                foreach (Vector2 i in snake)
                                    if (i.X == _app.X && i.Y == _app.Y)
                                    {
                                        found = false;
                                        break;
                                    }
                                if (found)
                                {
                                    _inUse = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!_inUse)
                    {
                        snake.RemoveAt(0);
                        foreach (Vector2 x in snake)
                            if (x.X == newH.X && x.Y == newH.Y)
                            {
                                // Death by accidental self-cannibalism.
                                _gameOver = true;
                                break;
                            }
                    }

                    if (!_gameOver)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(head.X, head.Y); Console.Write("0");
                        if (!_inUse)
                        {
                            Console.SetCursorPosition(tail.X, tail.Y); Console.Write(" ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(_app.X, _app.Y); Console.Write("$");
                            _inUse = false;
                        }
                        snake.Add(newH);
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newH.X, newH.Y); Console.Write("@");
                        _last = _newDir;
                    }
                }
            }
        }
    }
}