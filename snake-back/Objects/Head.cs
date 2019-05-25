using System;
using System.Numerics;

namespace snake_back.Objects
{
    internal class Head : MovingEntity
    {
        Vector<byte> Looking;

        public Head (int x, int y)
        {
            this.Position = new Vector2(x, y);
        }


    }
}
