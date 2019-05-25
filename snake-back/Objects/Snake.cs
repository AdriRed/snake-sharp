using System;
using System.Collections.Generic;

namespace snake_back.Objects
{
    internal class Snake
    {
        private Head First;
        private List<Body> Torso;

        public Snake()
        {
            First = new Head(0, 0);
            Torso = new List<Body>();

            Torso.Add(new Body());
            Torso.Add(new Body());
            Torso.Add(new Body());

        }


    }
}