using Advent_of_Code_2022.libs;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Drawing;

namespace Advent_of_Code_2022
{
    internal class Day24
    {
        //https://adventofcode.com/2022/day/24
        //const string input = "#.######\r\n#>>.<^<#\r\n#.<..<<#\r\n#>v.><>#\r\n#<^v^^>#\r\n######.#";
        const string input = "#.########################################################################################################################\r\n#.v^<>^^.<^^<v>v>>>.<^<<v.^>vv>>^<<<v>.v<^v^<v<<^<^^<^<^v><^vv.v^^.>^><vv><^<.<^v<>.v<v..^>><v>.vvv.v>^^<^>.<<^<^<^>v.^^<#\r\n#.^^<v>><<v><vv<>..<>v<^v><<>><>v.>v.^^<<.v.^<^<vv><v<<v><<^<>^v>v>><>v..v^<^.v><>^>><v<<>v^<<v<v>v.v<v>><<v>^v<v^...<<<>#\r\n#><vv>>v>v<^>^^^^vv^<v^<<v<>^<^.^^>^<^vv>^v>><<^^<.>^>v<^v<.v.^<^^v.<.>.<^>v^>.v>>^vv^v.>>>v<<<<v.^^v<^^<^><<<<.^>.>vvv>>#\r\n#<.vv>.><<.<^v.>v^v>><v>><<^vv>^v^>.><v>>><^><v<v^^vv>.v^^<v>vv<>v>^v.>>v^>..v<>^v.^>><.vv><^...<>^^>v>vvv>^<^<><v>v<^^^<#\r\n#>^.^>vvv>vv>^^vv>v^^v>vv>v^v>^<v>>vvvv^>.v^<v^><^>vvv<>vv<^v<.<^v^>^vv^<><>.^.^>><<^^>^<v^>>>>v><<v^^>^^>>v^v.<^vv^<^v<>#\r\n#><^>><vv^vvv.v><v<>^v>^<<<^^<><^<<v<>^<<v><<<v>><v<^^<vv<.>^v>^<v>.>v>>^^>^>><>.<<v<^><>>>^.<vv>.^^<.^^>>v.><<v<>><>v^><#\r\n#>>^.<<v.^v>^^v.>v.vv^<<.v<v<..<<v^^>^v.><>v<^^<<.>v>v>v>^v>.<>v<><<^v><^>><^v>v^v>^vvv>>>..>^>>.><v><>.^^v.><<vv<.v>^^<.#\r\n#>vv>^^.<>^v<^<<v^>v<^^v><>>>>v^vv>v<^v^><><^.<v^>.<^.v^>><vv>>vvv>^v<<<><vv<v^<<>v>>^v>^^^>^v><^^>^^^<<^^<v<<v<v>^^^<^>>#\r\n#>.v^<<.vv<^v>^>>v<>v^v^^v^v<^^<<..<<^v<<<<^<v>^>.<>v<v<v<.<.v>vv^>><^.<.v<^<^v><v<v>.v.><<^>>v^.^vv.vv^.>^^>vv<>^..v>^v<#\r\n#..v.>^><<>..<>.<^<<v>^^^^><<><<vv><^>v>^v<vv>v><vv.^<.<<<<v^v<>^^^vv>.>>>v^v<v<^.<v<<^.v<><<>>v<<<.>>v.^^>^^.>.<.>vv>^>>#\r\n#>^^vv<<><<v<^.v>>v>^^^v^<v.^><<<<<v^v>v<<^v..^<.vv.^v>vvv>^v<..v<><<^<<vv<>>>>^>^^<>^<^<^^.vv>>^>^>^v^>.<^.<<.>v^>vv<.^<#\r\n#<v^vv>^^v>vv>^.^>v>v^v>vv.>>.>v^v^>.^v<^.>^<<<v.>^>^^<>vv<.<^^<^v<^><v^v^.^<><v^^v^>.<vv^>v^v<v^><>^<vv>v<><^v<v.<<^.>^>#\r\n#<>^<^<v><^^.^^>..^^>v>>>>^v<.<>>.<^v^>vvvvv>^<<.><^<v<.v<^><^^>vv<^<^<>v>v<>^^v>>^^>>v<^^<v>v^^^vvv<<<<<>>>v>^v.<^^>^>^<#\r\n#>.<^v<.<^v.v>^.>>><^<<^^<<.<>><>>>^vvv<v<v<<^^vv<<<^v^v^vv<^v>>^^vv.^>^.v^^^>>v^>.<>.^^>v^^^^><^^>^>>.v<v^<^>^v^>^<<<v<<#\r\n#>><><.>v^<>^^>.^>^v>^.^<v><><>.<v<^v>>>>v.<>>.^vv>v.vv.><vv^v>^<>>v>vv.v>v>v<><>>>^..^v>^^><..^..^..^vvv>><>v<>v<^<<>v<<#\r\n#<vv^vvv><>v^v.<^v^^v<.<>v<>.^v^<<^<><.^vv<>^>>.v<<><vv<^^<>>v^.^v><v^^<>v.v<.>^^v^<<<^^<<v<^^^<<<<>^^v>><><<><>v>v<v.>^>#\r\n#.<.^>^>^>^v..v>^.<v<^<<<^vvv>vv><^^v^<.>>.^<.^^<<>>^><<>>^^.^<<^^><^v<.><>.<<<.vvv>>vv^v<^v<>vv<<^v^^<v.v^<<^>v^>v<><vv<#\r\n#.vvvv>>^>^<..^>>^>vv^.^>^<<v>^^v>v>^<>.>vv<v^>>>^.^<<^>>^>^>vvv><vv^^<^.^^.<^^v.<v<>^<<<v^>><<.^^^^>^>>>v<<>>v>v<>v<v><.#\r\n#<<vv.<v>^^v<.>>^>^<>^><.<v^><>>.^<v^v<<.v>>.<>.v>^>^v><><^<><<<v^<><<v^..^v^v>^.><>>>v^.^>vv<<^>v<><.^^v<>vv>v^v<><^>>><#\r\n#><>^v>v<>><vv>>v<>^<v>v^^>^v^>^^<v>v>^^v><<^v>>vv<^><>^>^^>>v^^<^<v>.^>v^vv^<.v>^v^.v^><><>>v.v^vv^<v>^>^><v>^>^>v>^v..<#\r\n#>v<^^<^>.<>v<v<.^vv^>>v><^^v<^^>>^>^<^^>>>^<v<^v<>v<^>v>^>v^v>^.<<v^>vv<^<.><^><<^>v><^<v>^<^v>v^>><^vvv^>>v>>vv>v^>^><<#\r\n#<vvv<><^.>v.^><v<^^<v><^<vvv.^..v^>...v^><<^^><^>^^vv>^v>v^<v<<>^>^^..<^<<v><<>.><<>^vvvv>v^><.^^>>v>>>^>>^<^<^<v^>vvv>>#\r\n#><<<^^.^<.^.^^<>^.vv^^^<v^<<<vv<<>^<v<^>>v^>>v<<v^^.v^<.vv<v<><<.v><<^>>v><.v><v>v^^v^v<^><vvvvv<^.<<>v^.<>^.^><>^v><>^<#\r\n#<.<>.>v^><<>^^<<vv>^>^v>>>v>v><^v><v.>>^<>>.<vv<<<v<v^<<vv^<.v^^>vv>>^<^<v<v<<>vv.><v..>>>.>^v<<vv><v^^^vv^^<>^>v<^^>v.>#\r\n#<>^^<>>^v>v<<>^.>>^^^<<v>^vv^<^<.<<<vv>>v>^^<^v><><>.<>.^><<^^^>^vv><>v.<>v<.<v>>><v.^>^>vv<v>^<v^<<v^v>v..>^^<^^.><>^><#\r\n########################################################################################################################.#";

        public static void Run()
        {
            Board board = new(input);

            Gamestate game = new(board.start, board.end, 0, "");
            GamestateIterator iterator = new(board);
            //iterator.PlaybackSequence(game, "SS·NEESWNE·SSEEESS"); return;

            game = iterator.FindOptimalSolution(game);
            Console.WriteLine($"Extraction point reached in {game.time} turns! Sequence: {game.sequence}");
            board.Render(game);
            game.targetPos = board.start;
            game = iterator.FindOptimalSolution(game);
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine($"Got the snacks in {game.time} turns! Sequence: {game.sequence}");
            board.Render(game);
            game.targetPos = board.end;
            game = iterator.FindOptimalSolution(game);
            Console.ReadKey();

            board.Render(game);
            Console.Clear();
            Console.WriteLine($"All done in {game.time} turns! Sequence: {game.sequence}");
            board.Render(game);
        }

        class Board
        {
            public Point start;
            public Point end;
            public int width;
            public int height;
            //Blizzards are stored as a set of 2d arrays representing their initial position. To get the position of a blizzard at minute M,
            //we read the contents of array[+-M % arraymax]. Note that the arrays do not include the walls, so they effectively start at coords 1,1.
            public bool[,] blizzardsLeft;
            public bool[,] blizzardsRight;
            public bool[,] blizzardsUp;
            public bool[,] blizzardsDown;

            public Board(string input)
            {
                List<String> inputPerLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.
                width = inputPerLine[0].Length;
                height = inputPerLine.Count;
                blizzardsLeft = new bool[width - 2, height - 2];
                blizzardsRight = new bool[width - 2, height - 2];
                blizzardsUp = new bool[width - 2, height - 2];
                blizzardsDown = new bool[width - 2, height - 2];
                for (int y = 0; y < inputPerLine.Count; y++)
                {
                    string line = inputPerLine[inputPerLine.Count - 1 - y];
                    if (y == inputPerLine.Count - 1)
                    {
                        start = new(line.IndexOf('.'), y);
                        continue;
                    }
                    else if (y == 0)
                    {
                        end = new(line.IndexOf("."), y);
                        continue;
                    }
                    for (int x = 0; x < line.Length; x++)
                    {
                        switch (line[x])
                        {
                            case '<':
                                blizzardsLeft[x - 1, y - 1] = true; break;
                            case '>':
                                blizzardsRight[x - 1, y - 1] = true; break;
                            case '^':
                                blizzardsUp[x - 1, y - 1] = true; break;
                            case 'v':
                                blizzardsDown[x - 1, y - 1] = true; break;
                        }
                    }
                }
            }

            public char[,] Board2Grid(Point expedition, int time)
            {
                char[,] grid = new char[width, height];
                for (int y = height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < width; x++)
                    {
                        grid[x, y] = GetPixel(x, y, expedition, time);
                    }
                }
                return grid;
            }

            public char GetPixel(int x, int y, Point expedition, int time)
            {
                Point p = new(x, y);
                if (p == expedition)
                {
                    return 'E';
                }
                if ((x <= 0) || (x >= width - 1) || (y <= 0) || (y >= height - 1))
                {
                    if (p == start || p == end)
                    {
                        return '·';
                    }
                    return '#';
                }
                char? blizz = BlizzardChar(x, y, time);
                if (blizz != null)
                {
                    return blizz.Value;
                }
                return '·';
            }

            public char? BlizzardChar(int x, int y, int time)
            {
                x = x - 1; //Our arrays are 1 smaller in each direction
                y = y - 1; //since they don't include the walls of the valley
                int maxx = width - 2;
                int maxy = height - 2;

                List<char> blizzards = new();
                if (blizzardsRight[Utils.RealModulo(x - time, maxx), y])
                {
                    blizzards.Add('>');
                }
                if (blizzardsLeft[Utils.RealModulo(x + time, maxx), y])
                {
                    blizzards.Add('<');
                }
                if (blizzardsUp[x, Utils.RealModulo(y - time, maxy)])
                {
                    blizzards.Add('^');
                }
                if (blizzardsDown[x, Utils.RealModulo(y + time, maxy)])
                {
                    blizzards.Add('v');
                }

                if (blizzards.Count == 1)
                {
                    return blizzards[0];
                }
                else if (blizzards.Count > 1)
                {
                    return char.Parse(blizzards.Count.ToString());
                }
                return null;
            }

            //Basically a more performant way of checking if getPixel == '·'
            public bool CoordIsSafe(int x, int y, int time)
            {
                Point coord = new(x, y);
                if (coord == start || coord == end)
                {
                    return true;
                }
                if ((x <= 0) || (x >= width - 1) || (y <= 0) || (y >= height - 1))
                {
                    return false;
                }
                x = x - 1; //Our arrays are 1 smaller in each direction
                y = y - 1; //since they don't include the walls of the valley
                int maxx = width - 2;
                int maxy = height - 2;

                if (blizzardsRight[Utils.RealModulo(x - time, maxx), y])
                {
                    return false;
                }
                if (blizzardsLeft[Utils.RealModulo(x + time, maxx), y])
                {
                    return false;
                }
                if (blizzardsUp[x, Utils.RealModulo(y - time, maxy)])
                {
                    return false;
                }
                if (blizzardsDown[x, Utils.RealModulo(y + time, maxy)])
                {
                    return false;
                }
                return true;
            }

            public void Render(Gamestate game)
            {
                GridRenderer.Render(0, 10, Board2Grid(game.expeditionPos, game.time), new List<Point>() { game.expeditionPos });
            }
        }

        class GamestateIterator
        {
            public SortedSet<Gamestate> unfinishedGames;
            public Board board;
            public static Comparer<Gamestate> comparer = Comparer<Gamestate>.Create((a, b) => {return Gamestate.CompareGames(a, b);});

            public GamestateIterator(Board board)
            {
                this.unfinishedGames = new(comparer);
                this.board = board;
            }

            public Gamestate FindOptimalSolution(Gamestate starter)
            {
                unfinishedGames.Add(starter);
                while (unfinishedGames.Any())
                {
                    Gamestate game = unfinishedGames.First();
                    if (game.expeditionPos == game.targetPos)
                    {
                        unfinishedGames.Clear();
                        return game;
                    }
                    unfinishedGames.Remove(game);
                    List<Gamestate> children = game.Children(board);
                    unfinishedGames.UnionWith(children);
                }
                throw new Exception("Ran out of games to compare, without finding a winner!");
            }

            public void PlaybackSequence(Gamestate game, string sequence, int sleeptime = 5)
            {
                Utils.WriteProgress("INITIAL POSITION", 0);
                board.Render(game);
                Console.ReadKey();
                Console.Clear();

                for (int i = 0; i < sequence.Length; i++)
                {
                    char step = sequence[i];
                    (int X, int Y) = Gamestate.destinations[step];
                    game.expeditionPos.Offset(X, Y);
                    game.time++;
                    Utils.WriteProgress($"Minute {game.time}: {step}", 0);
                    board.Render(game);
                    Thread.Sleep(sleeptime);
                }
            }
        }

        class Gamestate
        {
            public Point expeditionPos;
            public Point targetPos;
            public int time;
            public int score;
            public int distance;
            public string sequence;
            //List of tiles that we could move to each turn, in order of preference: S, E, wait, N, W.
            public static Dictionary<char, (int, int)> destinations = new() { { 'S', (0, -1)}, { 'E', (1, 0) }, { '·', (0, 0) }, { 'N', (0, 1) }, { 'W', (-1, 0)} };

            public Gamestate(Point expeditionPos, Point targetPos, int time, string sequence)
            {
                this.expeditionPos = expeditionPos;
                this.targetPos = targetPos;
                this.time = time;
                this.sequence = sequence;

                distance = Utils.ManhattanDistance(expeditionPos, targetPos);
                score = 99999999 + time - distance;
            }

            public List<Gamestate> Children(Board board)
            {
                List<Gamestate> children = new();
                foreach (KeyValuePair<Point, char> entry in GetValidDestinations(board))
                {
                    Gamestate child = new(entry.Key, targetPos, time + 1, sequence + entry.Value);
                    children.Add(child);
                }
                return children;
            }

            public Dictionary<Point, char> GetValidDestinations(Board board)
            {
                Dictionary <Point, char> validDestinations = new();
                foreach (KeyValuePair<char, (int X, int Y)> entry in destinations)
                {
                    //Note that we don't actually care about the state of the board right now. 
                    //For some reason we can walk through blizzards. So we check the board's state 1 minute into the future.
                    //Blizzards can only hurt once per minute, I guess...
                    int x = expeditionPos.X + entry.Value.X;
                    int y = expeditionPos.Y + entry.Value.Y;
                    if (board.CoordIsSafe(x, y, time + 1))
                    {
                        validDestinations.Add(new Point(x, y), entry.Key);
                    }
                }
                return validDestinations;
            }

            // 0: Games are functionally equal.
            // 1: B is better than A.
            //-1: A is better than B, or the games are different but equally good. This will result in a nondeterministic order, which is OK for our purposes,
            //but would be improper for an IComparable, which is why we're doing it like this, so we can use a custom Comparer instead.
            public static int CompareGames(Gamestate a, Gamestate b)
            {
                if (a.score < b.score) return -1; //Smaller score is better (i don't really understand why but it is)
                if (a.score > b.score) return 1;

                if (a.distance < b.distance) return -1; //Smaller distance is better
                if (a.distance > b.distance) return 1;

                if (a.expeditionPos == b.expeditionPos)
                {
                    return 0; //Same score, same location? Yeah it doesn't matter how they got there, they're functionally identical
                }

                return -1; //Otherwise, they are different but equally good
            }

            public override string? ToString()
            {
                return $"S:{score} T:{time} D: {distance} {sequence}";
            }
        }
    }
}
