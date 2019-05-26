using System;
using System.Collections.Generic;
using System.Numerics;

namespace snake_back.Objects
{
    public class Token
    {
        private Vector2 Position;

        public Vector2 pPosition {
            get
            {
                return Position;
            }
            set
            {
                Position = value;
            }
        }

        public Token (float x, float y)
        {
            Position = new Vector2(x, y);
        }
    }
}
