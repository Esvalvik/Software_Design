using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGood
{
	public class Snake
	{
        public const char ICON = '0';
        public const char ICON_HEAD = '@';
		public const char ICON_TAIL = '%';
        public const ConsoleColor COLOR = ConsoleColor.Yellow;
		public List<Vector2> Body = new List<Vector2>();
        public enum Direction { UP, DOWN, LEFT, RIGHT };
        private Direction _direction;
		public Direction CurrentDirection
		{
			get { return _direction; }
            set
            {
                _direction = value;
                LastDirection = _direction;
            }
		}
		public Direction LastDirection {get; set;}

		public int Head {get;}
		public int Tail {get; set;}

		public Snake(int size)
		{
			for(int i = 0; i < size; i++)
			{
				Body.Add(new Vector2(10, 10-i));
			}

			Head = 0;
			Tail = Body.Count - 1;
			CurrentDirection = Direction.DOWN;
			LastDirection = CurrentDirection;
		}

		public void Move()
		{
			Vector2 tempVector = new Vector2(Body[Head].X, Body[Head].Y);
			switch(CurrentDirection)
			{
				case Direction.UP:
				    Body.First().Y -= 1;
				break;
				case Direction.RIGHT:
				    Body.First().X += 1;
				break;
				case Direction.DOWN:
				    Body.First().Y += 1;
				break;
				default:
				    Body.First().X -= 1;
				break;
			}
			Body[Tail] = tempVector;
			SetTail();
		}

		//Checks if the position is taken by part of snake
		public bool PosTaken(Vector2 pos, bool countHead)
		{
            for(int i = 0; i < Body.Count; i++)
            {
                if (!countHead && i == Head)
                    continue;
                if (pos == Body[i])
                    return true;
            }
            return false;
		}

        public void Draw()
        {
			//PrintPos();
            for (int i = 0; i < Body.Count; i++)
            {
                if (Body[i].X >= 0 && Body[i].Y >= 0 && Body[i].X < Console.WindowWidth)
                {
                    Console.ForegroundColor = COLOR;
                    Console.SetCursorPosition(Body[i].X, Body[i].Y);
                    char icon = (i == Head) ? ICON_HEAD : ICON;
                    Console.Write(icon);
                }
            }
        }

        public void Grow()
		{
			Body.Add(Body[1]);
			
			
		}

		private void SetTail()
		{
			if(Tail == 1)
				Tail = Body.Count - 1;
            else
			    Tail -= 1;
		}

		public void PrintPos()
		{
			for(int i = 0; i < Body.Count; i++)
			{
				Console.WriteLine("Position for nr. " + (i + 1) + " is: " + Body[i].ToString);
			}
		}
	}


}
