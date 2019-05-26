using System;
using System.Collections.Generic;

namespace snake_back.Objects
{
    public class Snake
    {
        private Leader Head;
        private List<Section> Tail;

        public Snake()
        {
            Head = new Leader(0, 0);
            Tail = new List<Section>();

            Tail.Add(new Section(Head));
            AddSection();
            AddSection();
        }

        public void Move()
        {
            Head.Forward();
            UpdateTail();
            
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
    }
}