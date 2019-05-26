using System;
using System.Numerics;

namespace snake_back.Objects
{
    internal class Leader : IMovingEntity
    {

        private Vector2 Direction, Position;
        public static readonly Vector2[] DIRECTIONS =
            { new Vector2(1, 0),
              new Vector2(0, 1),
              new Vector2(-1, 0),
              new Vector2(0, -1) };

       
        public Vector2 pPosition
        {
            get
            {
                return Position;
            }
            set
            {
                Position = value;
            }
        }

        public Vector2 pDirection {
            get
            {
                return Direction;
            }
            set
            {
                Direction = value;
            }
        }

        public Leader(float x, float y, ConsoleKey direction)
        {
            SetDirection(direction);
            this.Position = new Vector2(x, y);
        }

        public void SetDirection (ConsoleKey key)
        {
            Vector2 direction;

            switch (key)
            {
                case ConsoleKey.RightArrow: direction = DIRECTIONS[0]; break;
                case ConsoleKey.UpArrow: direction = DIRECTIONS[3]; break;
                case ConsoleKey.LeftArrow: direction = DIRECTIONS[2]; break;
                default: direction = DIRECTIONS[1]; break;
            }
            if (!Vector2.Multiply(-1, direction).Equals(Direction)) Direction = direction;
        }

        public void Forward()
        {
            Position = Vector2.Add(Position, Direction);
        }

    }
}
