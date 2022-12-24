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
        const string input = "....#..\r\n..###.#\r\n#...#.#\r\n.#...##\r\n#.###..\r\n##.#.##\r\n.#..#..";
        //const string input = ".....\r\n..##.\r\n..#..\r\n.....\r\n..##.\r\n.....";
        //const string input = "##.....#..#..##....#..##.#.##.###.#...#.####..###..#.#.##.#....#.#.##.#\r\n.##...#.###.#...###.##....#######..##..#..#.####..#####.....#..#.#....#\r\n.#..#.##..#.######...##...##...##...#.#.#.#..####.#..###....###..##..##\r\n..#.#...#.#.#...####..#.####....##..###.#.#.#..#.....#....#..###.##.#..\r\n#.##.######..#.###.####.##.###.....####.#######.#...##..#.#.#...##..###\r\n.#..####.####.##.#####..#.#.#...##.#.###.####...#.#..#...##.#..####.##.\r\n.#..##.######.###..##.#.#.##.#.##..###.#...#..##.########...###..#.####\r\n.#..##.........#.#...####.#...#..#.#.##.#.#..###......######.##..######\r\n#...#.#...#.###.##..#.#.#..#.#.#.#..##.#.###....#....#.....#.##.#...###\r\n##.##...#..##.#...#..####..#..#.#.....#...####.##.....#####.#.#..#..#..\r\n....####....#.#......####..#.##.........###....##.##.#...##..#..#.###.#\r\n#..#.#.......#.####.#..#......###.#.....#...##.###....###...#...#....#.\r\n#....###.#..###....#..#####...###..####..#..#...##..####..#####..##.#..\r\n#.####.####..###....##..##.##.....##..#.#.....##..#...#...####.#.##.##.\r\n.....#.###..#.##.#.....###....######.#..##.###.##.#.##.##....#.#...##.#\r\n#....###...#..##.##.###.#.#..#.#..#.##.###...##...#.##.##.#####.###...#\r\n###..####.##.#....##...##.###.#.##..######.#####.###.#.##.#..#..##.#..#\r\n..#.##..#.####..#....#..##..#..#..#..##..#..#..##...#.###.#.###...#.#..\r\n########...#..###.#...#.#...##...##.##.#...#...#.#..#.##.##.#..#...#.#.\r\n..#.....###..#.###.##.#.##..##..#####..#.####.###.#..#...#.###...#####.\r\n###..##....#.##.##.#.#....###..###.#....##..###.....#.#.....#...#..###.\r\n#.#.#...#.##.##.#####.#.###..#..###.#.####..#.#........#.#...#.##..####\r\n.##.#.#.#..##.##.#####.###.....#.#....#..####.##....##.##..###..#.###..\r\n.........#.#.#.##.#.#####.#.###.#.####.#..#.####.##.#..#...#.....###.##\r\n...#.#.#.##..##..####.#####.#..##...###..###.#..#..#..###...#.#..#.####\r\n##....#..##..##..##.#..#...#.##..###..####.#....##.#.#..#....#####.#.#.\r\n.##.##.###........##...#.##....#.#..#....###.#.#####.#..#.##.#.#..##.#.\r\n#.#....#.##.#..##..#..#..#######..#####....#...#.##.#.##.#...#..##.#.##\r\n###....##..#.###.##..##.#.#.###.#..#.#####.#.#....###..#.#..#######.###\r\n.##.#........#####.#.#..##.#..###...#.##.#.#.##...#......##..###..#..#.\r\n#..#..#..#......#.#...#..#.#.##........##..#.#.#.#.###.....#.###.#...##\r\n.####.#.##.............#...##.#.#########.###.#####.....#..##..#...####\r\n.......#####.###..#...#..#...#.###.#.##.##...#...####.##.##.#...###.##.\r\n..###.####....#..#...######.###..##.....#.#.#.##.......#.##...#.#...##.\r\n..##.###..##.#..#.#..#.#.#.###.#..##.##...#.#.#........#..##.##.#..#.#.\r\n.####.....#...##..####.#.##..##........#.#.####..##.....###..#####....#\r\n#####...#.....###.#.####.#.#..#.#..#.####.#.###.#...#######.###..#.##.#\r\n.#.##.###..#.#.##.#..#.#.##....##.......#..##...##..#..#.#####..###..#.\r\n.#.##..#.##.##.###.##.#..#...##.####...........#.##..##...#.#.####..#..\r\n.#.#.#......##.#.#..##..#.##......#...#..#.#.##..####.##..#.....#.##.#.\r\n..#.##...#.##.#.#..#.##..##...#...#.#...##..#.####.##..#.##.#.#..#..##.\r\n.#....#.....##.####.#.##..#....#....#..#.##...##...##.##.##...##.###.##\r\n##..###...####..#...###..###..#.##.#...##.##...#.#.#.#...#...#.#####.#.\r\n#.##....#.###...#.#.#.....###..##.#.##..##.#.#.#.#...#.#.###..#..#..##.\r\n..#..###.#.#.#..###..##...###.....##.#.##..#.######..##..#.#.##..#..###\r\n..##....####.###.##........#...#.#.#.#.##..#.#....#....###..###..####..\r\n..###.....#.##.##.#.#..#.#.####.#.#.#..##..#..##.#...#..#..###.....###.\r\n##..#....#.##....#.#.#..#..#.#..##....#....#.#.##..#..####..##..##.#.#.\r\n...###.#..##.###.####..####..##.##.#..#.####..#.#.#.#####.#.###..#.##.#\r\n##.######.###.###.##..#.#....#.######.#..#.#.#.#..#...#..##.####...#...\r\n###.##..#..##.#..#.#..#.....###...#.##.##...#####.#.###.#...#.##..#....\r\n###.###.##.##.#.#.###.#..###..##..#....#...#.####.#.##...#####.###..#.#\r\n#.....#.###.###.##.#..#....#.....#.##..#.###.####.###.#...###.#....####\r\n.##.#.#...#.....#####....##.##.#.#...###.###.#.#...##.#####...#####..##\r\n..#...######...###.###.##.#..####.#........##.#....#.#.#...#..#...##.#.\r\n.###.#......#.##.###..###.##.##...##..##.#..#.....###.#....##.##.....#.\r\n...###.##.....##...########.######.....##.##..#.#.#.#..##.####.########\r\n##...##....#####.......#..#.###.#####....#...#..#...#.#..##.#.#....#.##\r\n.##.#...##.##..####..###.###....##...#......#.....##.#.#......#.....##.\r\n...#..........#.#...#..#..#.##...#.#...####.....###..##.###.#..###...##\r\n.###..##....#..#.#.##.##.#..#####..###.##......#..#....####.##.#..###.#\r\n#.#.#.#..######.#.##.####.....#.#.#.##..###.##...####........#########.\r\n#.##.####.....###.######......##.##.##.##.....#..#.##..##.###.#.##.#..#\r\n..#####.###.#######..#....#...###...##.##...#..###.####...#.##.....#..#\r\n#.##..##.##..#.##..##.#..##.#..##...###....#.#.#.##.###...###.#..######\r\n###....###.##.##....##..##.##.#.#...#.#.#..###...#..#.#.#..#...#.##....\r\n##.#..#.#.####..#.#.##.#.#.#.#.#####.#.#..###.##.###.#.##....#.##..#.#.\r\n##.#.#.#.###.#.####.##..##.##..#####......##.....#..###.#.#..#####..##.\r\n.#####...###.#....##.##.##..#..#...#.###.#....#...##....##..##..##.##..\r\n#..#..##..####..##..##..#.###....#.#..####.####..##.##.###...##.......#\r\n..######.#.#.####.##........##...####.#.##.##..##..##.......######..##.";

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
            Console.WriteLine($"First turn where noone moved: {board.gamestate.turnsElapsed + 1}");
            board.Draw();


        }

        public class Elf
        {
            public System.Drawing.Point coords;
            public static char sprite = '#';
            public static string[] propositionDirs = { "N", "S", "W", "E" };


            public Elf(System.Drawing.Point coords)
            {
                this.coords = coords;
            }

            public override string? ToString()
            {
                return coords.ToString();
            }

            public void Move(System.Drawing.Point coords)
            {
                this.coords = coords;
            }

            public void ProposeMovement(Gamestate gamestate)
            {
                Dictionary<System.Drawing.Point, Elf> elves = gamestate.board.elves;

                List<string> takenSpots = new();
                foreach (KeyValuePair<string, (short, short)> entry in Dir2Offset)
                {
                    string dir = entry.Key;
                    (short X, short Y) = entry.Value;
                    System.Drawing.Point toCheck = new(coords.X + X, coords.Y + Y);
                    if (elves.ContainsKey(toCheck))
                    {
                        takenSpots.Add(dir);
                    }
                }
                if(takenSpots.Count == 0)
                {
                    return;
                }
               
                for (int i = 0; i < propositionDirs.Length; i++)
                {
                    int index = Utils.RealModulo(gamestate.turnsElapsed + i, propositionDirs.Length);
                    string dir = propositionDirs[index];
                    List<string> dirsToCheck = new() { dir };
                    dirsToCheck.AddRange(AdjacentDirs[dir]);

                    if(takenSpots.Intersect(dirsToCheck).Count() == 0)
                    {
                        (short X, short Y) = Dir2Offset[dir];
                        System.Drawing.Point myDestination = new(coords.X + X, coords.Y + Y);
                        gamestate.AddProposition(myDestination, this);
                        return;
                    }
                }
            }
        }

        public class Gamestate
        {
            public int turnsElapsed = 0;
            public Dictionary<System.Drawing.Point, List<Elf>> elfPropositions = new();
            public Board board;

            public Gamestate(Board board)
            {
                this.board = board;
            }

            public void ElfPropositionPhase()
            {
                foreach(Elf elf in board.elves.Values)
                {
                    elf.ProposeMovement(this);
                }
            }

            public void ElfMovingPhase()
            {

                foreach(KeyValuePair<System.Drawing.Point, List<Elf>> entry in elfPropositions){
                    System.Drawing.Point p = entry.Key;
                    List<Elf> list = entry.Value;
                    if(list.Count > 1)
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
                if(elfPropositions.Count == 0)
                {
                    return false;
                }
                ElfMovingPhase();
                elfPropositions.Clear();
                turnsElapsed += 1;
                return true;
            }

            public void MoveElf(System.Drawing.Point oldLoc, System.Drawing.Point newLoc)
            {
                Elf elf = board.elves[oldLoc];
                board.elves.Remove(oldLoc);
                board.elves.Add(newLoc, elf);
                elf.coords = newLoc;
                board.AdjustSize(newLoc);
            }

            public void AddProposition(System.Drawing.Point coords, Elf elf)
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
            public Dictionary<System.Drawing.Point, Elf> elves;
            public char background;
            public Gamestate gamestate;

            public Board(string input, char background)
            {
                elves = new();
                this.background = background;
                this.gamestate = new(this);

                List<string> inputByLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.
                int height = inputByLine.Count;
                int width = inputByLine[0].Length;
                viewport = new Rectangle(0, 0, width, height);
                for (int y = height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < width; x++)
                    {
                        char currChar = inputByLine[height - 1 - y][x];
                        if(currChar == Elf.sprite)
                        {
                            Elf elf = new(new System.Drawing.Point(x, y));
                            elves.Add(elf.coords, elf);
                            AdjustSize(elf.coords);
                        }
                    }
                }
            }

            public void Draw()
            {
                GridRenderer.Render(20 - viewport.Width / 2, 20 - viewport.Height / 2, ToCharGrid());
            }
            
            public void AdjustSize(System.Drawing.Point coords)
            {
                if(coords.X < viewport.X)
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
                if(elves.ContainsKey(new System.Drawing.Point(x, y)))
                {
                    return Elf.sprite;
                }
                return background;
            }

            public int GetEmptySpots()
            {
                int emptySpots = 0;
                int minx = int.MaxValue; int miny = int.MaxValue, maxx = int.MinValue, maxy = int.MinValue;
                foreach(System.Drawing.Point p in elves.Keys)
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
                        if (!elves.ContainsKey(new System.Drawing.Point(x, y)))
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
