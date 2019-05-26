using System.Numerics;

namespace snake_back.Objects
{
    internal class Section : IMovingEntity
    {
        private Vector2 Position, Direction;
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

        public Vector2 pDirection
        {
            get
            {
                return Direction;
            }
            set
            {
                Direction = value;
            }
        }

        public Section(IMovingEntity father)
        {
            this.Father = father;
            this.Direction = Father.pDirection;
            this.Position = Vector2.Subtract(Father.pPosition, Direction);
        }

        public void MoveToFatherPosition()
        {
            this.Direction = Father.pDirection;
            this.Position = Father.pPosition;
        }

    }
}
