using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    public struct Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Vector2 position)
                return false;

            return (X == position.X && Y == position.Y);
        }
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

        
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
