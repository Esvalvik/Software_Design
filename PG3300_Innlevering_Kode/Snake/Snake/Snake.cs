using System;

namespace Snake
{
	public class Snake
	{
		List<Vector2> Body = new List<Vector2>();
		public int Direction { get; set; }
		Vector2 Head { get; }
		Vector2 Tail { get; }

		public Snake(int size)
		{
			Head = Body.First();
			Tail = Body.Last();

			for(int i = 0; i < size; i++)
			{
				Body.add(new Vector2(10, 10));
			}
		}

		public void Move()
		{
		}

		//Checks if the position is taken by part of snake
		public bool PosTaken(Vector2 pos)
		{
			foreach(int i in Body)
			{
				return pos == Body.Get(i) ? true : false;
			}
		}
	}
}
