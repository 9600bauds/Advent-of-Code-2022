using Advent_of_Code_2022.libs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2022
{
    internal class Day15
    {
        //https://adventofcode.com/2022/day/15

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
            

            (Dictionary<Point, Sensor> sensors, Dictionary<Point, Beacon> beacons) = processInput(input);
            Console.WriteLine($"Loaded {sensors.Count} sensors and {beacons.Count} beacons.");

            //Part 1: Calculating the squares in one slice of Y where a beacon cannot be.
            //First we calculate the leftmost and rightmost tiles that we'll need to check.
            //Technicaly this is all we need to calculate for our input, since we know that there are no gaps in sensor coverage in the middle of the board.
            //But this will work in a theoretical input where that might happen.
            //Anyways, when we detect that we are inside a sensor's coverage, we simply skip forward until the end of the sensor's coverage.
            int locationsWhereABeaconCannotBe = 0;
            int minx = int.MaxValue, maxx = int.MinValue; //Range in which we want to check in order to cover all of yToCheck.
            foreach (Sensor sensor in sensors.Values.ToList())
            {
                minx = Math.Min(minx, sensor.loc.X - sensor.distanceToBeacon + (Math.Abs(sensor.loc.Y - yToCheck)));
                maxx = Math.Max(maxx, sensor.loc.X + sensor.distanceToBeacon - (Math.Abs(sensor.loc.Y - yToCheck)));
            }
            HashSet<Beacon> beaconsEncountered = new HashSet<Beacon>();
            for (int x = minx; x <= maxx; x++)
            {
                Point currentLoc = new Point(x, yToCheck);
                //Console.WriteLine($"Checking {currentLoc}...");
                Sensor? sensor = FindSensorThatHasScannedThis(currentLoc, sensors.Values.ToList());
                if (sensor != null)
                {
                    if (sensor.nearestBeacon.loc.Y == yToCheck)
                    {
                        //Console.WriteLine($"Detected that this sensor's beacon, {sensor.nearestBeacon.loc} is in our y!");
                        beaconsEncountered.Add(sensor.nearestBeacon); //Keep track of these, since tiles where there are beacons... count as tiles where a beacon can be, I guess? Even though we don't really care about those
                    }

                    int xdiff = sensor.IntersectionWithY(yToCheck);
                    xdiff -= sensor.distanceToBeacon - Utils.ManhattanDistance(new(currentLoc.X, currentLoc.Y), new(sensor.loc.X, sensor.loc.Y)) + 1; //Because we might have skipped halfway into a sensor's range, we are not guaranteed to be at the border.
                    locationsWhereABeaconCannotBe += xdiff + 1;
                    x += xdiff;
                    //Console.WriteLine($"Skipping the next {xdiff} ({ManhattanDistance(currentLoc, sensor.loc)}) tiles because we bumped into {sensor.loc}, of range {sensor.distanceToBeacon}.");
                }
            }
            locationsWhereABeaconCannotBe -= beaconsEncountered.Count();
            Console.WriteLine($"In row {yToCheck}, there are {locationsWhereABeaconCannotBe} tiles where there cannot be a beacon.");

            //Since we know there's only 1 point in the whole area where the beacon CAN be, it must be exactly 1 tile further than a sensor's closest beacon.
            //So we can just iterate through all sensors and check all the tiles "surrounding" them.
            //I'm sure there's a proper calculus way to calculate this, but I suck at calculus.
            //That said, we can speed this up by only checking sensors that are close to touching.
            List<Sensor> almostTouchingSensors = new();
            for (int i = 0; i < sensors.Count; i++)
            {
                for (int j = i + 1; j < sensors.Count; j++)
                {
                    Sensor sensorA = sensors.Values.ToList()[i];
                    Sensor sensorB = sensors.Values.ToList()[j];
                    int distance = Utils.ManhattanDistance(new(sensorA.loc.X, sensorA.loc.Y), new(sensorB.loc.X, sensorB.loc.Y)) - sensorA.distanceToBeacon - sensorB.distanceToBeacon;
                    if (distance > 0 && distance < 5)
                    {
                        //Console.WriteLine($"Sensor {sensorA.loc} and Sensor {sensorB.loc} are {distance} tiles apart!");
                        almostTouchingSensors.Add(sensorA);
                        almostTouchingSensors.Add(sensorB);
                    }
                }
            }
            bool finished = false;
            foreach (Sensor sensor in almostTouchingSensors)
            {
                if (finished) break;
                List<Point> candidates = GenerateRhombus(sensor.loc, sensor.distanceToBeacon + 1);
                foreach (Point candidate in candidates)
                {
                    if (candidate.X < beaconCoordsMin || candidate.X > beaconCoordsMax || candidate.Y < beaconCoordsMin || candidate.Y > beaconCoordsMax)
                    {
                        continue;
                    }
                    if (FindSensorThatHasScannedThis(candidate, sensors.Values.ToList()) == null)
                    {
                        Console.WriteLine($"The beacon is at {candidate}. Tuning frequency: {Coords2TuningFrequency(candidate)}");
                        finished = true;
                        break;
                    }
                }
            }
        }

        public static (Dictionary<Point, Sensor>, Dictionary<Point, Beacon>) processInput(string input)
        {
            Dictionary<Point, Sensor> sensors = new Dictionary<Point, Sensor>();
            Dictionary<Point, Beacon> beacons = new Dictionary<Point, Beacon>();

            List<string> inputByLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

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

                }
                else
                {
                   throw new ArgumentException($"Could not parse {line}!");
                }
            }
            return (sensors, beacons);
        }

        //Returns a list of points that make up the outline of the rhombus.
        public static List<Point> GenerateRhombus(Point center, int radius)
        {
            List<Point> points = new List<Point>();
            int x = center.X;
            int y = center.Y;
            for (int i = 0; i < radius; i++)
            {
                points.Add(new Point(x + radius - i, y - i));
                points.Add(new Point(x - radius + i, y + i));
                points.Add(new Point(x - i, y - radius + i));
                points.Add(new Point(x + i, y + radius - i));
            }
            return points;
        }

        public static long Coords2TuningFrequency(Point p)
        {
            return (long)p.X * 4000000 + p.Y;
        }

        /// <summary>
        /// Finds the first sensor that's within scanning distance of this point. Meaning, the first sensor that considers this point its closest beacon.
        /// If no beacons think we're their closest beacon, then an extraneous beacon could be here!
        /// </summary>
        /// <param name="p">Location to check.</param>
        /// <param name="sensors">List of sensors to check from.</param>
        /// <returns>The first sensor we find that can see us, or null if no sensors can see us.</returns>
        public static Sensor? FindSensorThatHasScannedThis(Point p, List<Sensor> sensors)
        {
            foreach (Sensor sensor in sensors)
            {
                if (Utils.ManhattanDistance(new(p.X, p.Y), new(sensor.loc.X, sensor.loc.Y)) <= sensor.distanceToBeacon)
                {
                    return sensor;
                }
            }
            return null;
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
                distanceToBeacon = Utils.ManhattanDistance(new(loc.X, loc.Y), new(nearestBeacon.loc.X, nearestBeacon.loc.Y));
            }

            /// <summary>
            /// Draw a straight line of slope 0 at the provided Y coordinate. How many tiles of this line can this beacon "see"?
            /// Meaning, how many of these tiles are equal or closer to the distance to the sensor's closest beacon.
            /// </summary>
            /// <param name="y">Y coordinate to check</param>
            /// <returns>An integer representing our scanning range's intersection with that Y line.</returns>
            public int IntersectionWithY(int y)
            {
                int ydiff = Math.Abs(loc.Y - y);
                if (distanceToBeacon < ydiff)
                {
                    return 0;
                }
                return (distanceToBeacon - ydiff) * 2 + 1;
            }

            public override string ToString()
            {
                return loc.ToString();
            }
        }

        public class Beacon
        {
            public Point loc;

            public Beacon(Point loc)
            {
                this.loc = loc;
            }
            public override string ToString()
            {
                return loc.ToString();
            }
        }
    }
}
