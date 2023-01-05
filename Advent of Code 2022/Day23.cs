using Advent_of_Code_2022.libs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day23
    {
        //https://adventofcode.com/2022/day/23

        //const string input = "....#..\r\n..###.#\r\n#...#.#\r\n.#...##\r\n#.###..\r\n##.#.##\r\n.#..#..";
        //const string input = ".....\r\n..##.\r\n..#..\r\n.....\r\n..##.\r\n.....";
        const string input = "##.....#..#..##....#..##.#.##.###.#...#.####..###..#.#.##.#....#.#.##.#\r\n.##...#.###.#...###.##....#######..##..#..#.####..#####.....#..#.#....#\r\n.#..#.##..#.######...##...##...##...#.#.#.#..####.#..###....###..##..##\r\n..#.#...#.#.#...####..#.####....##..###.#.#.#..#.....#....#..###.##.#..\r\n#.##.######..#.###.####.##.###.....####.#######.#...##..#.#.#...##..###\r\n.#..####.####.##.#####..#.#.#...##.#.###.####...#.#..#...##.#..####.##.\r\n.#..##.######.###..##.#.#.##.#.##..###.#...#..##.########...###..#.####\r\n.#..##.........#.#...####.#...#..#.#.##.#.#..###......######.##..######\r\n#...#.#...#.###.##..#.#.#..#.#.#.#..##.#.###....#....#.....#.##.#...###\r\n##.##...#..##.#...#..####..#..#.#.....#...####.##.....#####.#.#..#..#..\r\n....####....#.#......####..#.##.........###....##.##.#...##..#..#.###.#\r\n#..#.#.......#.####.#..#......###.#.....#...##.###....###...#...#....#.\r\n#....###.#..###....#..#####...###..####..#..#...##..####..#####..##.#..\r\n#.####.####..###....##..##.##.....##..#.#.....##..#...#...####.#.##.##.\r\n.....#.###..#.##.#.....###....######.#..##.###.##.#.##.##....#.#...##.#\r\n#....###...#..##.##.###.#.#..#.#..#.##.###...##...#.##.##.#####.###...#\r\n###..####.##.#....##...##.###.#.##..######.#####.###.#.##.#..#..##.#..#\r\n..#.##..#.####..#....#..##..#..#..#..##..#..#..##...#.###.#.###...#.#..\r\n########...#..###.#...#.#...##...##.##.#...#...#.#..#.##.##.#..#...#.#.\r\n..#.....###..#.###.##.#.##..##..#####..#.####.###.#..#...#.###...#####.\r\n###..##....#.##.##.#.#....###..###.#....##..###.....#.#.....#...#..###.\r\n#.#.#...#.##.##.#####.#.###..#..###.#.####..#.#........#.#...#.##..####\r\n.##.#.#.#..##.##.#####.###.....#.#....#..####.##....##.##..###..#.###..\r\n.........#.#.#.##.#.#####.#.###.#.####.#..#.####.##.#..#...#.....###.##\r\n...#.#.#.##..##..####.#####.#..##...###..###.#..#..#..###...#.#..#.####\r\n##....#..##..##..##.#..#...#.##..###..####.#....##.#.#..#....#####.#.#.\r\n.##.##.###........##...#.##....#.#..#....###.#.#####.#..#.##.#.#..##.#.\r\n#.#....#.##.#..##..#..#..#######..#####....#...#.##.#.##.#...#..##.#.##\r\n###....##..#.###.##..##.#.#.###.#..#.#####.#.#....###..#.#..#######.###\r\n.##.#........#####.#.#..##.#..###...#.##.#.#.##...#......##..###..#..#.\r\n#..#..#..#......#.#...#..#.#.##........##..#.#.#.#.###.....#.###.#...##\r\n.####.#.##.............#...##.#.#########.###.#####.....#..##..#...####\r\n.......#####.###..#...#..#...#.###.#.##.##...#...####.##.##.#...###.##.\r\n..###.####....#..#...######.###..##.....#.#.#.##.......#.##...#.#...##.\r\n..##.###..##.#..#.#..#.#.#.###.#..##.##...#.#.#........#..##.##.#..#.#.\r\n.####.....#...##..####.#.##..##........#.#.####..##.....###..#####....#\r\n#####...#.....###.#.####.#.#..#.#..#.####.#.###.#...#######.###..#.##.#\r\n.#.##.###..#.#.##.#..#.#.##....##.......#..##...##..#..#.#####..###..#.\r\n.#.##..#.##.##.###.##.#..#...##.####...........#.##..##...#.#.####..#..\r\n.#.#.#......##.#.#..##..#.##......#...#..#.#.##..####.##..#.....#.##.#.\r\n..#.##...#.##.#.#..#.##..##...#...#.#...##..#.####.##..#.##.#.#..#..##.\r\n.#....#.....##.####.#.##..#....#....#..#.##...##...##.##.##...##.###.##\r\n##..###...####..#...###..###..#.##.#...##.##...#.#.#.#...#...#.#####.#.\r\n#.##....#.###...#.#.#.....###..##.#.##..##.#.#.#.#...#.#.###..#..#..##.\r\n..#..###.#.#.#..###..##...###.....##.#.##..#.######..##..#.#.##..#..###\r\n..##....####.###.##........#...#.#.#.#.##..#.#....#....###..###..####..\r\n..###.....#.##.##.#.#..#.#.####.#.#.#..##..#..##.#...#..#..###.....###.\r\n##..#....#.##....#.#.#..#..#.#..##....#....#.#.##..#..####..##..##.#.#.\r\n...###.#..##.###.####..####..##.##.#..#.####..#.#.#.#####.#.###..#.##.#\r\n##.######.###.###.##..#.#....#.######.#..#.#.#.#..#...#..##.####...#...\r\n###.##..#..##.#..#.#..#.....###...#.##.##...#####.#.###.#...#.##..#....\r\n###.###.##.##.#.#.###.#..###..##..#....#...#.####.#.##...#####.###..#.#\r\n#.....#.###.###.##.#..#....#.....#.##..#.###.####.###.#...###.#....####\r\n.##.#.#...#.....#####....##.##.#.#...###.###.#.#...##.#####...#####..##\r\n..#...######...###.###.##.#..####.#........##.#....#.#.#...#..#...##.#.\r\n.###.#......#.##.###..###.##.##...##..##.#..#.....###.#....##.##.....#.\r\n...###.##.....##...########.######.....##.##..#.#.#.#..##.####.########\r\n##...##....#####.......#..#.###.#####....#...#..#...#.#..##.#.#....#.##\r\n.##.#...##.##..####..###.###....##...#......#.....##.#.#......#.....##.\r\n...#..........#.#...#..#..#.##...#.#...####.....###..##.###.#..###...##\r\n.###..##....#..#.#.##.##.#..#####..###.##......#..#....####.##.#..###.#\r\n#.#.#.#..######.#.##.####.....#.#.#.##..###.##...####........#########.\r\n#.##.####.....###.######......##.##.##.##.....#..#.##..##.###.#.##.#..#\r\n..#####.###.#######..#....#...###...##.##...#..###.####...#.##.....#..#\r\n#.##..##.##..#.##..##.#..##.#..##...###....#.#.#.##.###...###.#..######\r\n###....###.##.##....##..##.##.#.#...#.#.#..###...#..#.#.#..#...#.##....\r\n##.#..#.#.####..#.#.##.#.#.#.#.#####.#.#..###.##.###.#.##....#.##..#.#.\r\n##.#.#.#.###.#.####.##..##.##..#####......##.....#..###.#.#..#####..##.\r\n.#####...###.#....##.##.##..#..#...#.###.#....#...##....##..##..##.##..\r\n#..#..##..####..##..##..#.###....#.#..####.####..##.##.###...##.......#\r\n..######.#.#.####.##........##...####.#.##.##..##..##.......######..##.";

        public static Dictionary<string, (short, short)> Dir2Offset = new() { { "N", (0, 1) }, { "S", (0, -1) }, { "E", (1, 0) }, { "W", (-1, 0) },
                                                                   { "NE", (1, 1) }, { "NW", (-1, 1) }, { "SE", (1, -1) }, { "SW", (-1, -1) } };
        public static Dictionary<string, List<string>> AdjacentDirs = new() { { "N", new(){"NE", "NW"} }, { "S", new() { "SE", "SW" } },
                                                                   { "E", new(){"NE", "SE"} }, { "W", new() { "SW", "NW" } },};

        public static void Run()
        {
            Board board = new Board(input, '·');
            board.Draw();
            Console.WriteLine("Initial State");

            for (int i = 0; i < 10; i++)
            {
                Console.ReadKey();
                board.gamestate.TakeTurn();
                //Console.WriteLine($"End of Round {i+1}");
                board.Draw();
            }
            Console.WriteLine($"Empty tiles at round 10: {board.GetEmptySpots()}");
            while (board.gamestate.TakeTurn())
            {
                board.Draw();
            }
            //This assumes that the number of turns before people stop moving is >10, but whatever...
            Console.WriteLine($"First turn where noone moved: {board.gamestate.turnsElapsed + 1}");
            board.Draw();
        }

        public class Elf
        {
            public Point coords;
            public static char sprite = '#';
            public static string[] propositionDirs = { "N", "S", "W", "E" };


            public Elf(Point coords)
            {
                this.coords = coords;
            }

            public override string? ToString()
            {
                return coords.ToString();
            }

            public void Move(Point coords)
            {
                this.coords = coords;
            }

            public void ProposeMovement(Gamestate gamestate)
            {
                Dictionary<Point, Elf> elves = gamestate.board.elves;

                List<string> takenSpots = new();
                //First we simply check all 8 tiles around us, disregarding which one is supposed to come first.
                //This will tell us if we need to move at all, and also we can reference the results later so we don't need to check everything again.
                foreach (KeyValuePair<string, (short, short)> entry in Dir2Offset)
                {
                    string dir = entry.Key;
                    (short X, short Y) = entry.Value;
                    Point toCheck = new(coords.X + X, coords.Y + Y);
                    if (elves.ContainsKey(toCheck))
                    {
                        takenSpots.Add(dir);
                    }
                }
                if (takenSpots.Count == 0)
                {
                    return;
                }

                for (int i = 0; i < propositionDirs.Length; i++)
                {
                    //We know which direction to start from by keeping track of the turns elapsed and using modulo on the sequence of directions.
                    int index = Utils.RealModulo(gamestate.turnsElapsed + i, propositionDirs.Length);
                    string dir = propositionDirs[index];
                    List<string> dirsToCheck = new() { dir }; //We start with just the cardinal direction (e.g. North)
                    dirsToCheck.AddRange(AdjacentDirs[dir]); //We add the adjacent diagonal directions (e.g. NW, NE)

                    if (takenSpots.Intersect(dirsToCheck).Count() == 0) //Get the intersection between the tiles to check and the taken tiles.
                    {
                        (short X, short Y) = Dir2Offset[dir];
                        Point myDestination = new(coords.X + X, coords.Y + Y);
                        gamestate.AddProposition(myDestination, this);
                        return;
                    }
                }
            }
        }

        public class Gamestate
        {
            public int turnsElapsed = 0;
            public Dictionary<Point, List<Elf>> elfPropositions = new();
            public Board board;

            public Gamestate(Board board)
            {
                this.board = board;
            }

            public void ElfPropositionPhase()
            {
                foreach (Elf elf in board.elves.Values)
                {
                    elf.ProposeMovement(this);
                }
            }

            public void ElfMovingPhase()
            {
                foreach (KeyValuePair<Point, List<Elf>> entry in elfPropositions)
                {
                    Point p = entry.Key;
                    List<Elf> list = entry.Value;
                    if (list.Count > 1) //No move for you
                    {
                        continue;
                    }
                    Elf elf = list[0];
                    MoveElf(elf.coords, p);
                }
            }

            public bool TakeTurn()
            {
                ElfPropositionPhase();
                if (elfPropositions.Count == 0)
                {
                    return false;
                }
                ElfMovingPhase();
                elfPropositions.Clear();
                turnsElapsed += 1;
                return true;
            }

            public void MoveElf(Point oldLoc, Point newLoc)
            {
                Elf elf = board.elves[oldLoc];
                board.elves.Remove(oldLoc);
                board.elves.Add(newLoc, elf);
                elf.coords = newLoc;
                board.AdjustSize(newLoc);
            }

            public void AddProposition(Point coords, Elf elf)
            {
                if (!elfPropositions.ContainsKey(coords))
                {
                    elfPropositions.Add(coords, new List<Elf>());
                }
                elfPropositions[coords].Add(elf);
            }
        }

        public class Board
        {
            public Rectangle viewport;
            public Dictionary<Point, Elf> elves;
            public char background;
            public Gamestate gamestate;

            public Board(string input, char background)
            {
                elves = new();
                this.background = background;
                this.gamestate = new(this);

                string[] inputByLine = Utils.SplitLines(input); 
                int height = inputByLine.Length;
                int width = inputByLine[0].Length;
                viewport = new Rectangle(0, 0, width, height);
                for (int y = height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < width; x++)
                    {
                        char currChar = inputByLine[height - 1 - y][x];
                        if (currChar == Elf.sprite)
                        {
                            Elf elf = new(new Point(x, y));
                            elves.Add(elf.coords, elf);
                            AdjustSize(elf.coords);
                        }
                    }
                }
            }

            public void Draw()
            {
                GridRenderer.Render(70 - viewport.Width / 2, 70 - viewport.Height / 2, ToCharGrid()); //needs some work
            }

            public void AdjustSize(Point coords)
            {
                if (coords.X < viewport.X)
                {
                    int diff = Math.Abs(viewport.X - coords.X);
                    viewport.Width += diff;
                    viewport.X = coords.X;
                }
                if (coords.Y < viewport.Y)
                {
                    int diff = Math.Abs(viewport.Y - coords.Y);
                    viewport.Height += diff;
                    viewport.Y = coords.Y;
                }
                if (coords.X >= viewport.X + viewport.Width)
                {
                    int diff = Math.Abs(viewport.X + viewport.Width - 1 - coords.X);
                    viewport.Width += diff;
                }
                if (coords.Y >= viewport.Y + viewport.Height)
                {
                    int diff = Math.Abs(viewport.Y + viewport.Height - 1 - coords.Y);
                    viewport.Height += diff;
                }
            }

            public char[,] ToCharGrid()
            {
                char[,] grid = new char[viewport.Width, viewport.Height];
                for (int y = viewport.Height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < viewport.Width; x++)
                    {
                        grid[x, y] = GetPixel(viewport.X + x, viewport.Y + y);
                    }
                }
                return grid;
            }

            public char GetPixel(int x, int y)
            {
                if (elves.ContainsKey(new Point(x, y)))
                {
                    return Elf.sprite;
                }
                return background;
            }

            public int GetEmptySpots()
            {
                int emptySpots = 0;
                int minx = int.MaxValue; int miny = int.MaxValue, maxx = int.MinValue, maxy = int.MinValue;
                foreach (Point p in elves.Keys)
                {
                    minx = Math.Min(minx, p.X);
                    miny = Math.Min(miny, p.Y);
                    maxx = Math.Max(maxx, p.X);
                    maxy = Math.Max(maxy, p.Y);
                }

                for (int y = miny; y <= maxy; y++)
                {
                    for (int x = minx; x <= maxx; x++)
                    {
                        if (!elves.ContainsKey(new Point(x, y)))
                        {
                            emptySpots++;
                        }
                    }
                }
                return emptySpots;
            }
        }
    }
}
