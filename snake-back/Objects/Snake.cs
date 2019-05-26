using System;
using System.Collections.Generic;
using System.Numerics;

namespace snake_back.Objects
{
    public class Snake
    {
        private Leader Head;
        private List<Section> Tail;

        public Snake()
        {
            Head = new Leader(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Tail = new List<Section>();

            Tail.Add(new Section(Head));
            AddSection();
            AddSection();
        }

        public void Move()
        {
            UpdateTail();
            Head.Forward();
        }

        public void ChangeDir(byte dir)
        {
            Head.pLookingAt = Leader.directions[dir];
        }

        public bool IsAlive()
        {
            bool alive = true;

            Vector2 headPos = Head.pPosition;
            if (headPos.X >= 0 && headPos.X <= Console.WindowWidth && headPos.Y >= 0 && headPos.Y <= Console.WindowHeight)
            {
                for (int i = 2; i < Tail.Count && alive; i++)
                {
                    if (headPos.Equals(Tail[i].pPosition)) alive = false;
                }
            } else
            {
                alive = false;
            }

            return alive;
        }

        private void UpdateTail()
        {
            for (int i = Tail.Count - 1; i >= 0; i--)
            {
                Tail[i].MoveToFatherPosition();
            }
        }

        public void AddSection ()
        {
            Tail.Add(new Section(LastSection()));
        }

        internal IMovingEntity LastSection ()
        {
            return Tail[Tail.Count - 1];
        }


        internal List<Vector2> GetPositions()
        {
            List<Vector2> positions = new List<Vector2>();

            positions.Add(Head.pPosition);

            foreach (Section section in Tail)
            {
                positions.Add(section.pPosition);
            }

            return positions;
        }

    }
}