using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022.libs
{
    internal class Trig
    {
        //Note how this is a class, not a struct, unlike Microsoft's Drawing.Point
        //This is because this is mutable and mutable structs are awful
        public class Point3D
        {
            public double x;
            public double y;
            public double z;

            public Point3D(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Point3D(Point3D copy)
            {
                this.x = copy.x;
                this.y = copy.y;
                this.z = copy.z;
            }

            public override string? ToString()
            {
                return $"{{{x}, {y}, {z}}}";
            }

            public void Translate(double x, double y, double z)
            {
                this.x += x;
                this.y += y;
                this.z += z;
            }

            public double Distance(Point3D b)
            {
                return Math.Sqrt((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y) + (z - b.z) * (z - b.z));
            }
            public override bool Equals(object? obj)
            {
                return obj is Point3D d &&
                x == d.x &&
                y == d.y &&
                z == d.z;
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(x, y, z);
            }
            public static bool operator ==(Point3D? left, Point3D? right)
            {
                return EqualityComparer<Point3D>.Default.Equals(left, right);
            }
            public static bool operator !=(Point3D? left, Point3D? right)
            {
                return !(left == right);
            }
        }

        public class Line3D
        {
            public Point3D point1;
            public Point3D point2;

            public Line3D(Point3D point1, Point3D point2)
            {
                this.point1 = point1;
                this.point2 = point2;
            }

            public List<Point3D> GetPoints()
            {
                return new List<Point3D> { point1, point2 };
            }

            public double Length()
            {
                return Math.Sqrt((point2.x - point1.x) * (point2.x - point1.x) + (point2.y - point1.y) * (point2.y - point1.y) + (point2.z - point1.z) * (point2.z - point1.z));
            }

            public double DistPointA(Point3D point)
            {
                return point1.Distance(point);
            }

            public double DistPointB(Point3D point)
            {
                return point2.Distance(point);
            }

            public bool Intersects(Point3D point)
            {
                double AB = Length();
                //Distance from point1 to point
                double AP = DistPointA(point);
                //Distance from point2 to point
                double PB = DistPointB(point);
                //If distance from point to point1 + distance to point to point2 = our length, then the point intersects us
                if (AB == AP + PB)
                {
                    return true;
                }
                return false;
            }

            public bool Coincident(Line3D line2)
            {
                return (point1 == line2.point1 && point2 == line2.point2) || (point2 == line2.point1 && point1 == line2.point2);
            }

            public override string? ToString()
            {
                return $"{{{point1},{point2}}}";
            }
        }
        public class Rect3D
        {
            public Point3D point1;
            public Point3D point2;
            public Point3D point3;
            public Point3D point4;

            public Rect3D(Point3D point1, Point3D point2, Point3D point3, Point3D point4)
            {
                this.point1 = point1;
                this.point2 = point2;
                this.point3 = point3;
                this.point4 = point4;
            }

            public List<Point3D> GetPoints()
            {
                return new List<Point3D> { point1, point2, point3, point4 };
            }

            public void Translate(double x, double y, double z)
            {
                List<Point3D> points = GetPoints();
                for (int i = 0; i < points.Count; i++)
                {
                    points[i].Translate(x, y, z);
                }
            }

            public void RotateX(double degrees, Point3D origin)
            {
                RotateX3D(Degrees2Radians(degrees), GetPoints(), origin);
            }

            public void RotateY(double degrees, Point3D origin)
            {
                RotateY3D(Degrees2Radians(degrees), GetPoints(), origin);
            }

            public void RotateZ(double degrees, Point3D origin)
            {
                RotateZ3D(Degrees2Radians(degrees), GetPoints(), origin);
            }

            public override string? ToString()
            {
                return string.Join(", ", GetPoints());
            }
        }

        public static void RotateX3D(double theta, List<Point3D> nodes, Point3D origin)
        {
            double sinTheta = Math.Round(Math.Sin(theta), 3);
            double cosTheta = Math.Round(Math.Cos(theta), 3);

            for (var n = 0; n < nodes.Count; n++)
            {
                Point3D node = nodes[n];
                node.Translate(-origin.x, -origin.y, -origin.z);
                double y = node.y;
                double z = node.z;
                node.y = y * cosTheta - z * sinTheta;
                node.z = z * cosTheta + y * sinTheta;
                node.Translate(origin.x, origin.y, origin.z);
            }
        }

        public static void RotateY3D(double theta, List<Point3D> nodes, Point3D origin)
        {
            double sinTheta = Math.Round(Math.Sin(theta), 3);
            double cosTheta = Math.Round(Math.Cos(theta), 3);

            for (var n = 0; n < nodes.Count; n++)
            {
                Point3D node = nodes[n];
                node.Translate(-origin.x, -origin.y, -origin.z);
                double x = node.x;
                double z = node.z;
                node.x = x * cosTheta + z * sinTheta;
                node.z = z * cosTheta - x * sinTheta;
                node.Translate(origin.x, origin.y, origin.z);
            }
        }

        public static void RotateZ3D(double theta, List<Point3D> nodes, Point3D origin)
        {
            double sinTheta = Math.Round(Math.Sin(theta), 3);
            double cosTheta = Math.Round(Math.Cos(theta), 3);

            for (var n = 0; n < nodes.Count; n++)
            {
                Point3D node = nodes[n];
                node.Translate(-origin.x, -origin.y, -origin.z);
                double x = node.x;
                double y = node.y;
                node.x = x * cosTheta - y * sinTheta;
                node.y = y * cosTheta + x * sinTheta;
                node.Translate(origin.x, origin.y, origin.z);
            }
        }

        public static double Degrees2Radians(double angle)
        {
            return Math.PI / 180 * angle;
        }

        public static double Radians2Degrees(double rad)
        {
            return 180 / Math.PI * rad;
        }
    }
}
