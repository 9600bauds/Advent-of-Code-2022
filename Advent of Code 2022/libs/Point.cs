using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.libs
{
    public class DeprecatedPoint
    {
        public int X;
        public int Y;

        public bool Equals(DeprecatedPoint p)
        {
            return (X == p.X) && (Y == p.Y);
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            DeprecatedPoint p = (DeprecatedPoint)obj;
            return (X == p.X) && (Y == p.Y);
        }

        public override int GetHashCode()
        {
            return (X << 2) ^ Y;
        }

        public DeprecatedPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public double GetDistance(DeprecatedPoint b)
        {
            return Math.Sqrt(Math.Pow((b.X - X), 2) + Math.Pow((b.Y - Y), 2));
        }

        public List<DeprecatedPoint> SurroundingPoints()
        {
            return new List<DeprecatedPoint> { new DeprecatedPoint(X + 1, Y), new DeprecatedPoint(X - 1, Y), new DeprecatedPoint(X, Y + 1), new DeprecatedPoint(X, Y -1 ),
                new DeprecatedPoint(X + 1, Y + 1), new DeprecatedPoint(X - 1, Y - 1), new DeprecatedPoint(X + 1, Y - 1), new DeprecatedPoint(X - 1, Y + 1 )};
        }
    }
}
