using System;


namespace SnakeGood
{

	public class Vector2
	{
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
		{
			return ((v.X == u.X) && (v.Y == u.Y)) ? true : false;
		}

		public static bool operator !=(Vector2 v, Vector2 u)
		{
			return !(v == u) ? true : false;
		}

		public override bool Equals(object obj)
		{
			var vector = obj as Vector2;
			return vector != null &&
				   X == vector.X &&
				   Y == vector.Y;
		}
  
		public override int GetHashCode()
		{
			var hashCode = 1861411795;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			return hashCode;
		}

		public new String ToString => "x:" + X + " y:" + Y +
			"\n";
	}
}