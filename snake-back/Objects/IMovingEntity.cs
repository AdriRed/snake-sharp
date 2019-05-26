using System;
using System.Numerics;

namespace snake_back.Objects
{
    internal interface IMovingEntity
    {
        Vector2 pPosition {
            get; set;
        }
    }
}