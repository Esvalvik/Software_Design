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

        private int _direction;
		public int Direction
		{
			get { return _direction; }
            set
            {
                _direction = value;
                LastDirection = _direction;
            }
		}
		public int LastDirection
		{
			get; set;
		}

		public int Head
		{
			get;
		}
		public int Tail
		{
			get; set;
		}

		public Snake(int size)
		{
			for(int i = 0; i < size; i++)
			{
				Body.Add(new Vector2(10+i, 10));
			}

			Head = 0;
			Tail = Body.Capacity - 1;
			Direction = 3;
			LastDirection = Direction;
		}

		public void Move()
		{
			Vector2 tempVector = Body[Head];
			switch(Direction)
			{
				case 0:
				Body[Head].Y -= 1;
				break;
				case 1:
				Body[Head].X += 1;
				break;
				case 2:
				Body[Head].Y += 1;
				break;
				default:
				Body[Head].X -= 1;
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
			Body.Add(Body[Tail]);
			Tail = Body.Capacity - 1;
		}

		private void SetTail()
		{
			if(Tail == 1)
				Tail = Body.Capacity - 1;

			Tail -= 1;
		}
	}

}
