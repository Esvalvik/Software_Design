using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGood
{
	public class Snake
	{
		List<Vector2> Body = new List<Vector2>();
		public int Direction
		{
			get; set;
		}
		Vector2 Head
		{
			get;
		}
		Vector2 Tail
		{
			get;
		}

		public Snake(int size)
		{
			for(int i = 0; i < size; i++)
			{
				Body.Add(new Vector2(10, 10));
			}

			Head = Body.First();
			Tail = Body.Last();

			
		}

		public void Move()
		{
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
	}
}