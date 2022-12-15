using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.libs
{
    public class Point
    {
        public int x;
        public int y;

        public bool Equals(Point p)
        {
            return (x == p.x) && (y == p.y);
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Point p = (Point)obj;
            return (x == p.x) && (y == p.y);
        }

        public override int GetHashCode()
        {
            return (x << 2) ^ y;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{x},{y}";
        }

        public List<Point> SurroundingPoints()
        {
            return new List<Point> { new Point(x + 1, y), new Point(x - 1, y), new Point(x, y + 1), new Point(x, y -1 ),
                new Point(x + 1, y + 1), new Point(x - 1, y - 1), new Point(x + 1, y - 1), new Point(x - 1, y + 1 )};
        }
    }
}
