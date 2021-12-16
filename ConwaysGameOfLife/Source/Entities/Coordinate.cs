using System;

namespace ConwaysGameOfLife.Source.Entities
{
    public readonly struct Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        private bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj.GetType() == GetType() && Equals((Coordinate) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}