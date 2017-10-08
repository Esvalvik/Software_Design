using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGood
{
	public class Snake
	{
        public const char ICON = '0';
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
				Body.Add(new Vector2(10+i, 10));
			}

			Head = 0;
			Tail = Body.Count - 1;
			CurrentDirection = Direction.RIGHT;
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
		public bool PosTaken(Vector2 pos)
		{
			foreach(Vector2 i in Body)
			{
				Console.WriteLine(i.ToString);
				if(pos == i)
				{
					return true;
				}
			}
			return false;
		}

        public void Draw()
        {
            foreach (Vector2 bodyPart in Body)
            {
                Console.ForegroundColor = COLOR;
                Console.SetCursorPosition(bodyPart.X, bodyPart.Y);
                Console.Write(ICON);
            }
        }

        public void Grow()
		{
			Body.Add(Body.Last());
			//Tail = Body.Count - 1;
		}

		private void SetTail()
		{
			if(Tail == 1)
				Tail = Body.Count - 1;
            else
			    Tail -= 1;
		}
	}

}
