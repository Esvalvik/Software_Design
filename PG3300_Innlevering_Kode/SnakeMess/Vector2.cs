using System;


namespace SnakeMess
{

	class Vector2
	{

		//public const string Ok = "Ok";

		public int X, Y;
		public Vector2(int x = 0, int y = 0)
		{
			X = x;
			Y = y;
		}

		public Vector2(Vector2 input)
		{
			X = input.X;
			Y = input.Y;
		}

		public static bool operator ==(Vector2 v, Vector2 u)
			{	return (v.X == u.X) && (v.Y == u.Y) ? true : false; }
	}
}