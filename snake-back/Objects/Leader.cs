using System;
using System.Numerics;

namespace snake_back.Objects
{
    internal class Leader : IMovingEntity
    {

        private Vector2 LookingAt, Position;


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

        public Vector2 pLookingAt {
            get
            {
                return LookingAt;
            }
            set
            {
                LookingAt = value;
            }
        }


        public Leader (int x, int y)
        {
            this.pPosition = new Vector2(x, y);

        }

        public void Forward()
        {
            pPosition = Vector2.Add(pPosition, pLookingAt);
        }

    }
}
