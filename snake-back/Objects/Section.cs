using System;
using System.Numerics;

namespace snake_back.Objects
{
    internal class Section : IMovingEntity
    {
        private Vector2 Position;
        private IMovingEntity Father;

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

        public Section (IMovingEntity father)
        {
            this.Father = father;
        }

        public void MoveToFatherPosition ()
        {
            this.pPosition = Father.pPosition;
        }

    }
}
