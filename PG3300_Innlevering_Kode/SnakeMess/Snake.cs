using System;

namespace Snake
{
	public class Snake
	{
		List<Vector2> Body = new List<Vector2>();
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
	}
}
