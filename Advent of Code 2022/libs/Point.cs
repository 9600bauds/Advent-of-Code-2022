using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.libs
{
    public class DeprecatedPoint
    {
        public int x;
        public int y;

        public bool Equals(DeprecatedPoint p)
        {
            return (x == p.x) && (y == p.y);
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            DeprecatedPoint p = (DeprecatedPoint)obj;
            return (x == p.x) && (y == p.y);
        }

        public override int GetHashCode()
        {
            return (x << 2) ^ y;
        }

        public DeprecatedPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{x},{y}";
        }

        public double GetDistance(DeprecatedPoint b)
        {
            return Math.Sqrt(Math.Pow((b.x - x), 2) + Math.Pow((b.y - y), 2));
        }

        public List<DeprecatedPoint> SurroundingPoints()
        {
            return new List<DeprecatedPoint> { new DeprecatedPoint(x + 1, y), new DeprecatedPoint(x - 1, y), new DeprecatedPoint(x, y + 1), new DeprecatedPoint(x, y -1 ),
                new DeprecatedPoint(x + 1, y + 1), new DeprecatedPoint(x - 1, y - 1), new DeprecatedPoint(x + 1, y - 1), new DeprecatedPoint(x - 1, y + 1 )};
        }
    }
}
