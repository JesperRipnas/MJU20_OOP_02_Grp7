using System;

namespace MJU20_OOP_02_Grp7
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Calculates the distance to the other Point and the others relative position from this
        /// </summary>
        /// <param name="other">The other Point that you want to get the distance to</param>
        /// <param name="relativeTo">Returns the position of the other point, compared to this one</param>
        /// <returns></returns>
        public int Distance(Point other, out Point relativeTo)
        {
            relativeTo = new Point(other.X - X, other.Y - Y);
            return (int)(Math.Sqrt(Math.Pow(relativeTo.X, 2) + Math.Pow(relativeTo.Y, 2)));
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static bool operator ==(Point a, Point b)
        {
            if (a.X == b.X && a.Y == b.Y) return true;
            return false;
        }

        public static bool operator !=(Point a, Point b)
        {
            if (a.X != b.X || a.Y != b.Y) return true;
            return false;
        }

        public static bool operator >(Point a, int b)
        {
            if (Math.Abs(a.X) > b || Math.Abs(a.Y) > b) return true;
            return false;
        }

        public static bool operator <(Point a, int b)
        {
            if (Math.Abs(a.X) < b || Math.Abs(a.Y) < b) return true;
            return false;
        }
    }
}