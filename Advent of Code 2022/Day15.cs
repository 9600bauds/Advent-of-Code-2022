using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Advent_of_Code_2022.libs;
using static Advent_of_Code_2022.Day15;

namespace Advent_of_Code_2022
{
    internal class Day15
    {
        //public static int yToCheck = 10;
        public static int yToCheck = 2000000;
        public static int beaconCoordsMin = 0;
        public static int beaconCoordsMax = 4000000;
        //public static int beaconCoordsMax = 20;    


        static Regex parsingRegex = new Regex(@"Sensor at x=(?<sensorX>[0-9\-]+), y=(?<sensorY>[0-9\-]+): closest beacon is at x=(?<beaconX>[0-9\-]+), y=(?<beaconY>[0-9\-]+)");

        public static void Run()
        {
            //string input = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15\r\nSensor at x=9, y=16: closest beacon is at x=10, y=16\r\nSensor at x=13, y=2: closest beacon is at x=15, y=3\r\nSensor at x=12, y=14: closest beacon is at x=10, y=16\r\nSensor at x=10, y=20: closest beacon is at x=10, y=16\r\nSensor at x=14, y=17: closest beacon is at x=10, y=16\r\nSensor at x=8, y=7: closest beacon is at x=2, y=10\r\nSensor at x=2, y=0: closest beacon is at x=2, y=10\r\nSensor at x=0, y=11: closest beacon is at x=2, y=10\r\nSensor at x=20, y=14: closest beacon is at x=25, y=17\r\nSensor at x=17, y=20: closest beacon is at x=21, y=22\r\nSensor at x=16, y=7: closest beacon is at x=15, y=3\r\nSensor at x=14, y=3: closest beacon is at x=15, y=3\r\nSensor at x=20, y=1: closest beacon is at x=15, y=3";
            string input = "Sensor at x=3890859, y=2762958: closest beacon is at x=4037927, y=2985317\r\nSensor at x=671793, y=1531646: closest beacon is at x=351996, y=1184837\r\nSensor at x=3699203, y=3052069: closest beacon is at x=4037927, y=2985317\r\nSensor at x=3969720, y=629205: closest beacon is at x=4285415, y=81270\r\nSensor at x=41343, y=57178: closest beacon is at x=351996, y=1184837\r\nSensor at x=2135702, y=1658955: closest beacon is at x=1295288, y=2000000\r\nSensor at x=24022, y=1500343: closest beacon is at x=351996, y=1184837\r\nSensor at x=3040604, y=3457552: closest beacon is at x=2994959, y=4070511\r\nSensor at x=357905, y=3997215: closest beacon is at x=-101509, y=3502675\r\nSensor at x=117943, y=3670308: closest beacon is at x=-101509, y=3502675\r\nSensor at x=841852, y=702520: closest beacon is at x=351996, y=1184837\r\nSensor at x=3425318, y=3984088: closest beacon is at x=2994959, y=4070511\r\nSensor at x=3825628, y=3589947: closest beacon is at x=4299658, y=3299020\r\nSensor at x=2745170, y=139176: closest beacon is at x=4285415, y=81270\r\nSensor at x=878421, y=2039332: closest beacon is at x=1295288, y=2000000\r\nSensor at x=1736736, y=811875: closest beacon is at x=1295288, y=2000000\r\nSensor at x=180028, y=2627284: closest beacon is at x=-101509, y=3502675\r\nSensor at x=3957016, y=2468479: closest beacon is at x=3640739, y=2511853\r\nSensor at x=3227780, y=2760865: closest beacon is at x=3640739, y=2511853\r\nSensor at x=1083678, y=2357766: closest beacon is at x=1295288, y=2000000\r\nSensor at x=1336681, y=2182469: closest beacon is at x=1295288, y=2000000\r\nSensor at x=3332913, y=1556848: closest beacon is at x=3640739, y=2511853\r\nSensor at x=3663725, y=2525708: closest beacon is at x=3640739, y=2511853\r\nSensor at x=2570900, y=2419316: closest beacon is at x=3640739, y=2511853\r\nSensor at x=1879148, y=3584980: closest beacon is at x=2994959, y=4070511\r\nSensor at x=3949871, y=2889309: closest beacon is at x=4037927, y=2985317";
            List<string> inputByLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            Dictionary<Point, Sensor> sensors = new Dictionary<Point, Sensor>();
            Dictionary<Point, Beacon> beacons = new Dictionary<Point, Beacon>();
            int minx = int.MaxValue, maxx = int.MinValue;

            foreach (string line in inputByLine)
            {
                Match match = parsingRegex.Match(line);
                if (match.Success)
                {
                    int beaconX = int.Parse(match.Groups["beaconX"].Value);
                    int beaconY = int.Parse(match.Groups["beaconY"].Value);
                    Point beaconLoc = new Point(beaconX, beaconY);
                    Beacon currentBeacon;
                    if (beacons.ContainsKey(beaconLoc))
                    {
                        currentBeacon = beacons[beaconLoc];
                    }
                    else
                    {
                        currentBeacon = new Beacon(beaconLoc);
                        beacons.Add(beaconLoc, currentBeacon);
                    }
                    int sensorX = int.Parse(match.Groups["sensorX"].Value);
                    int sensorY = int.Parse(match.Groups["sensorY"].Value);
                    Point sensorLoc = new Point(sensorX, sensorY);
                    Sensor currentSensor = new Sensor(sensorLoc, currentBeacon);
                    sensors.Add(sensorLoc, currentSensor);
                    minx = Math.Min(minx, sensorLoc.x - currentSensor.distanceToBeacon - 1);
                    maxx = Math.Max(maxx, sensorLoc.x + currentSensor.distanceToBeacon + 1);
                }
                else
                {
                    Debug.Fail($"Could not parse {line}!");
                }
            }
            Console.WriteLine($"Loaded {sensors.Count} sensors and {beacons.Count} beacons. Maxx is {maxx} and minx is {minx}.");

            /*int locationsWhereABeaconCannotBe = 0;
            for (int x = minx; x <= maxx; x++)
            {
                Point currentLoc = new Point(x, yToCheck);
                if (beacons.ContainsKey(currentLoc))
                {
                    //This tile evidently can contain a beacon, seeing as it contains one.
                    continue;
                }
                if (!CanContainUnknownBeacon(currentLoc, sensors.Values.ToList()))
                {
                    if (x == minx || x == maxx)
                    {
                        Debug.Fail("WARNING: Checking area is too small!");
                    }
                    locationsWhereABeaconCannotBe++;
                }
            }
            Console.WriteLine($"In row {yToCheck}, there are {locationsWhereABeaconCannotBe} tiles where there cannot be a beacon.");*/

            List<Sensor> sensorList = sensors.Values.ToList();
            for (int i = 0; i < sensorList.Count; i++)
            {
                for(int j = i+1; j < sensorList.Count; j++)
                {
                    Sensor sensorA = sensorList[i];
                    Sensor sensorB = sensorList[j];
                    int dist = ManhattanDistance(sensorA.loc, sensorB.loc);
                    if(dist > sensorA.distanceToBeacon && dist > sensorB.distanceToBeacon)
                    {
                        Point likelyPoint = AveragePoint(sensorA.loc, sensorB.loc);
                        //Console.WriteLine($"Sensors {sensorA.loc} and {sensorB.loc} are far apart enough to contain a beacon between them... Average: {likelyPoint} ");
                        foreach (Point point in likelyPoint.SurroundingPoints())
                        {
                            if (CanContainUnknownBeacon(point, sensors.Values.ToList()))
                            {
                                Console.WriteLine($"The beacon can be at {point}. Tuning frequency: {point.x * 4000000 + point.y}");
                                return;
                            }
                            else
                            {
                                Console.WriteLine($"It's not at {point}...");
                            }
                        }
                        
                    }
                }

            }

            Console.WriteLine($"Checking the hard way...");
            //backup plan
            for (int i = beaconCoordsMin; i <= beaconCoordsMax; i++)
            {
                if (CanContainUnknownBeacon(new Point(i, beaconCoordsMin), sensors.Values.ToList())
                    || CanContainUnknownBeacon(new Point(i, beaconCoordsMax), sensors.Values.ToList())
                    || CanContainUnknownBeacon(new Point(beaconCoordsMin, i), sensors.Values.ToList())
                    || CanContainUnknownBeacon(new Point(beaconCoordsMax, i), sensors.Values.ToList()))
                {
                    Console.WriteLine($"The beacon can be at asdasd. Tuning frequency: asdasd");
                    return;
                }
            }
            Console.WriteLine($"Checking the HARDER way...");
            for (int y = beaconCoordsMin; y <= beaconCoordsMax; y++)
            {
                for (int x = beaconCoordsMin; x <= beaconCoordsMax; x++)
                {
                    Point currentLoc = new Point(x, y);
                    if(CanContainUnknownBeacon(currentLoc, sensors.Values.ToList()))
                    {
                        Console.WriteLine($"The beacon can be at {currentLoc}. Tuning frequency: {x*4000000+y}");
                        return;
                    }
                }
            }
        }

        public static bool CanContainUnknownBeacon(Point p, List<Sensor> sensors)
        {
            foreach (Sensor sensor in sensors)
            {
                int distSensorToUs = ManhattanDistance(p, sensor.loc);
                int distSensorToKnownBeacon = ManhattanDistance(sensor.loc, sensor.nearestBeacon.loc);

                if (distSensorToUs <= distSensorToKnownBeacon)
                {
                    return false;
                }
            }
            return true;
        }

        public static int ManhattanDistance(Point a, Point b)
        {
            int distance = 0;
            distance += Math.Abs(a.x - b.x);
            distance += Math.Abs(a.y - b.y);
            return distance;
        }

        public static Point AveragePoint(Point a, Point b)
        {
            int averageX = (a.x + b.x) / 2;
            int averageY = (a.y + b.y) / 2;
            return new Point(averageX, averageY);
        }

        public class Sensor
        {
            public Point loc;
            public Beacon nearestBeacon;
            public int distanceToBeacon;

            public Sensor(Point loc, Beacon nearestBeacon)
            {
                this.loc = loc;
                this.nearestBeacon = nearestBeacon;
                distanceToBeacon = ManhattanDistance(loc, nearestBeacon.loc);
            }
        }

        public class Beacon
        {
            public Point loc;

            public Beacon(Point loc)
            {
                this.loc = loc;
            }
        }
    }
}
