using System;

namespace ConwaysGameOfLife.Entities
{
    public class Coordinate
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
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Coordinate) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        
        public static bool operator ==(Coordinate left, Coordinate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Coordinate left, Coordinate right)
        {
            return !Equals(left, right);
        }
    }
}