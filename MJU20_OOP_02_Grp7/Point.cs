using System;
using System.Collections.Generic;
using System.Text;

namespace MJU20_OOP_02_Grp7
{
    struct Point
    {
        public int X;
        public int Y;

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
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
