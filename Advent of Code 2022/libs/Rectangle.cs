using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.libs
{
    public class Rectangle
    {
        public Point loc;
        public int width;
        public int height;

        public Rectangle(Point loc, int width, int height)
        {
            this.loc = loc;
            this.width = width;
            this.height = height;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Rectangle r = (Rectangle)obj;
            return (r.loc == loc && r.width == width && r.height == height);
        }

        public override int GetHashCode() //I don't know what I'm doing.
        {
            return HashCode.Combine(loc, width, height);
        }

        public bool CollidesWith(Rectangle other)
        {
            if(other.loc.x > loc.x + width  || other.loc.x + other.width < loc.x || other.loc.y > loc.y + height || other.loc.y + other.height < loc.y)
            {
                return false;
            }
            return true;
        }

        public bool CollidesWith(Point point)
        {
            if(point.x > loc.x + width  || point.x < loc.x || point.y > loc.y + height || point.y < loc.y)
            {
                return false;
            }
            return true;
        }
    }
}


