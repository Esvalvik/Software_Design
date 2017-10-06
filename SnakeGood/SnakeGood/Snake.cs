using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGood
{
    public class Snake
    {
        List<Vector2> Body = new List<Vector2>();
        public int Direction { get; set; }
        public int LastDirection { get; set; }

        int Head { get; }
        int Tail { get; set; }

        public Snake(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Body.Add(new Vector2(10, 10));
            }

            Head = 0;
            Tail = Body.Capacity - 1;
            Direction = 3;
            LastDirection = Direction;
        }

        public void Move()
        {
            Vector2 tempVector = Body[Head];
            switch (Direction)
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
            foreach (Vector2 i in Body)
            {
                if (pos == i)
                {
                    return true;
                }
            }
            return false;
        }
        private void SetTail()
        {
            if (Tail == 1)
                Tail = Body.Capacity - 1;

            Tail -= 1;
        }
    }
}