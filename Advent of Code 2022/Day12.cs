using Advent_of_Code_2022.libs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day12
    {
        //https://adventofcode.com/2022/day/12
        public static void Run()
        {
            //string input = "Sabqponm\r\nabcryxxl\r\naccszExk\r\nacctuvwj\r\nabdefghi";
            string input = "abaaaaaaaaccccccccccccccccccaaaaaccccaaaaaaccccccccccccccccccccccaaaaaaaaaacccccccccccccccccccccccccccccccaaaaaccccccccccccccccccccccccccccccccccccccccccaaaaaa\r\nabaaaaaaaacccccccccccccccccccaaaaaccccaaaacccccaaaacccccccccccccccaaaaaaaaaacccccccccccccccccccccccccccccaaaaaaccccccccccccccccccccccccccccccccccccccccccccaaaa\r\nabccaaaaaaccccccccccccccccccaaaaaaccccaaaaccccaaaaaccccccccccaaaaaaaaaaaaaaacccccccccccccccccccccccccccccaaaacccccccccccccccccccccccccccccaaaccccccccccccccaaaa\r\nabcaaaaaaaccccccccccccccccccaaaaccccccaccaccccaaaaaacccccccccaaaaaaaaaaaaaaacccccccccccccccccccccacccccccccaacccccccccccccccccccccccccccccaaaccccccccccccccaaaa\r\nabccaacccaccccccccccccccccccccaaacccccccccccccaaaaaaccccccccccaaaaaaaaacaaacccccccccccccccccccaaaacccccccccccccccccccccccccaacccccccaaccccaaacccccccccccccaaaaa\r\nabcaaaaaacccccccccccccccccccccccccccccccccccccaaaaaccccccccccaaaaaaaaaaccccaacaaccccccccccccccaaaaaacccccccccccccccccccccccaacccccccaaaacaaaaccccccccccccccaccc\r\nabccaaaaacccccccccccccccccccccccccccccccccccaaccaaacccccccccaaaaaaaaaaaacccaaaaccccccccccccccccaaaaacccccccccccccccaacaaaaaaacccccccaaaaaaaaacccccccccccccccccc\r\nabccaaaaaacccccccccccccccccccccccccccccaaacaaaccccccccccccccaaaaaaaaaaacccaaaaacccccccccccccccaaaaacccccccccccccaaaaaccaaaaaaaaccccccaaaaaalllllllcccaacccccccc\r\nabccaaaaaaccccccaaaaacccccccccaaaccccccaaaaaaaccccccccccccccaaacaaacaaacccaaaaaaccccccccccccccaccaaccccccccccccccaaaaacaaaaaaaaajkkkkkkkkkklllllllccccaaaaacccc\r\nabccaaaaacccccccaaaaacccccccccaaaaccccccaaaaaaccccccccaacaacccccaaacccccccacaaaaccccccccaaaccccccccccccccccccccccaaaaaccaaaaaaajjkkkkkkkkkkllssllllcccaaaaacccc\r\nabcccaaaaccccccaaaaaacccccccccaaaaccccccaaaaaaaaccccccaaaaacccccaaccccccccccaacccccccccaaaacccccccccccccccaaccccaaaaaccaaaaaacjjjjkkkkkkkkssssssslllccaaaaccccc\r\nabcccccccccccccaaaaaacccccccccaaaccccccaaaaaaaaacaaccccaaaaacccccccccccccccaaccccccccccaaaaccccccccccccccaaacccccccaaccaaaaaajjjjrrrrrrsssssssssslllcccaaaccccc\r\nabcccccccccccccaaaaaacccccccccccccccccaaaaaaaaaaaaaaacaaaaaacccccccccccaaacaacccccccccccaaaccccaaacccccaaaaaaaaccccccccaacaaajjjrrrrrrrsssssuusssslmcccaaaacccc\r\nabcccccccccccccccaacccccccccccccccaacaaaacaaaccaaaaaacaaaaccccccccccccccaaaaaccccccccccccccccccaaaaacccaaaaaaaaccccccccccccaajjjrrrruuurssuuuuvsqqmmcddaaaacccc\r\nabccccccccccccccccccccccccccccccccaaaaacccaaacccaaaaccccaaccccccccccccccaaaaaaacccccccccccccccaaaaaaccccaaaaaacccccccccccccccjjrrruuuuuuuuuuuuvvqqmmmdddccccccc\r\nabcccccccccccccccccccccccacccccccccaaaaaccaaacccaaaaccccccccccccccccccccaaaaaaacccccccccccccccaaaaaaccccaaaaaacccccccccaaccccjjjrrtuuuuuuuuyyvvvqqmmmddddcccccc\r\nabccccccccccccccccccccaaaaccccccccaaaaaacccccaacaccacccccccccccccccccccaaaaaaccccccccccccccccccaaaaaccccaaaaaaccccccccaaaccccjjjrrttuxxxuuxyyyvvqqmmmmdddcccccc\r\nabcccccccccaacccccccccaaaaaaccccccaaaaccccccaaaccccccccccccccccccccccccaacaaaccccccccccccccccccaacaaccccaaccaaccccaaaaaaaccccjjjrrtttxxxxxyyyyvvqqqmmmddddccccc\r\nabccccccccaaaacccccccccaaaacccccccccaaccccccaaacaaaccccccccccccccccccaaccccaacccccccccccccccccccccccccccccccccccccaaaaaaaaaacijjqrtttxxxxxyyyvvvqqqqmmmdddccccc\r\nabcccccacaaaaaccccccccaaaaaccccccccccccccaaaaaaaaaacccccccccccccccccaaaccccccccccccccccccccccccccccccccccccccccccccaaaaaaaaaciiiqqqttxxxxxyyyvvvvqqqqmmmdddcccc\r\nSbcccccaaaaaaaaaacccccaacaaccccccccccccccaaaaaaaaaccccccccccccccaaacaaacccccccccccccccccccccccccccccccccccccccccccccaaaaaaaciiiqqqtttxxxEzzyyyyvvvqqqmmmdddcccc\r\nabcccccaaaaaaaaaaccccccccccccaaccccccccccccaaaaaccccccccccccccccaaaaaaaaaacccccccaacccccccccccccaacccccccccccccccccaaaaaaccciiiqqqttxxxxyyyyyyyyvvvqqqmmmeddccc\r\nabcccccccaaaaaacccccccccccaaaaccccccccccaaaaaaaaacccccccaaaacccccaaaaaaaaacccccaaaaccccccccccaacaaaccccccccccccccccaaaaaaaciiiqqqtttxxyyyyyyyyyvvvvqqqnnneeeccc\r\nabcccccccaaaaaacccccccccccaaaaaaccccccccaaaaaaaaaaccccccaaaaccccccaaaaaaaccccccaaaaaaccccccccaaaaacccccccccccccccccaaccaaaciiiqqtttxxxxwwyyywwvvvvrrrnnnneeeccc\r\nabcccccccaaaaaaccccccccccccaaaaacccccccaaaaaaacaaaccccccaaaacccccaaaaaacccccccccaaaaccccccccccaaaaaaccccaaccccccccccccccaaciiqqqtttxxxwwwyywwwwvvrrrrnnneeecccc\r\nabccccccaaaaaaaaccccccccccaaaaaccccccccaaaaaaccccccccccccaaacccccaaaaaaacccccccaaaaaccccccccaaaaaaaaacccaaccccccccccccccccciiqqqtttttwwswwyywwrrrrrrnnnneeecccc\r\nabccccccccccccacccccccccccaccaaccccaaccaaaaaacccccccccccaccccccccaaacaaacccccccaacaaccccccccaaaaacaaaaaaaacccccccccaacccccciiqqqqttssssswwwwwrrrrnnnnnneeeecccc\r\nabcccccccccccccccccccccccccccccaaaaaaccccaacccccccaaacaaacccccccccccccaacaaacccccccccccccccccccaaaccaaaaaaaaccccaacaacccccciiiqqpppsssssswwwwrrrnnnnneeeeeccccc\r\nabcccccccccccccccccccccccccccccaaaaaaaccccccccccccaaaaaaaccccccccccccccccaaacccccccccccccccccccaaaccaaaaaaaaacccaaaaacccccchhhhppppppppssswwwrroonnfeeeeacccccc\r\nabccccccccccccccccccccaaaaaccccaaaaaaaaccccccccccccaaaaaaccccccccccccccaaaaaaaacccccccccccccccccccccaaaaaaaaaccccaaaaaaccccchhhhhpppppppsssssrroonfffeeaaaacccc\r\nabccccccccccccccccccccaaaaacccccaaaaaaaccccccccccccaaaaaaaaccccccccccccaaaaaaaacccccccccccccccccccccaaaaaacccccaaaaaaaacccccchhhhhhhppppsssssrooofffffaaaaacccc\r\nabcccccaacaaacccccccccaaaaaacccaaaaaacccccccccccccaaaaaaaaacccccccccccccaaaaacccccccccccccccccccccccaaaaaaaccccaaaaaccaccccccchhhhhhhhpppssssrooofffcaaaaaccccc\r\nabcccccaaaaaacccccccccaaaaaacccaaaaaaccccccccccccaaaaaaaaaacccccccccccccaaaaaaccccccccccccccccccccccaccaaaccccccacaaaccaacccccccchhhhhgppooooooofffcaaaaacccccc\r\nabcccccaaaaaacccccccccaaaaaaccccccaaacaacccccccccaaacaaaccccccccccaaacccaaaaaaccccccccccccccccccccccccccaaacccccccaaacaaaccccccccccchgggoooooooffffcaaaaaaccccc\r\nabaccccaaaaaaaccccccccccaaccccccccaaaaaacccccccccccccaaaccccccccccaaaaccaaaccacaacaacccccccccccccccccccccccccccccccaaaaaaaaccccccccccggggoooooffffccaccaaaccccc\r\nabacccaaaaaaaaccccccccccccccccccccaaaaaccccccccccccccaacccccccaaacaaaacccaaccccaaaaacccccccccccccccccccaacaacccccccaaaaaaaacccccccccccggggggggfffcccccccccccccc\r\nabacccaaaaaaaaccccccccaaacccccccccaaaaaaccccccccccccccccccccccaaacaaaacaaaaccccaaaaaaccccccccaaccccccccaaaaaccccccccaaaaaaacccccccccccaaggggggffcccccccccccccca\r\nabcccccccaaacccccccccaaaaaaccccccaaaaaaaacccccccccccccccccccaaaaaaaaaaaaaaaccccaaaaaaccccccacaaaacccccccaaaaacccccccaaaaaccccccccccccaaacgggggaccccccccccccccaa\r\nabcccccccaaccccccccccaaaaaaccccccaaaaaaaacccccccaaacccccccccaaaaaaaaaaaaaaaacccaaaaaaccccccaaaaaaccccccaaaaaaccccccaaaaaaacccccccccccaaaccccaaaccccccccccaaacaa\r\nabcccccccccccccccccccaaaaaccccccccccaaccccccccaaaaaccccccccccaaaaaaaaaaaaaaaaccccaaaccccccccaaaacccccccaaaaccccccccccccaaccccccccccccccccccccccccccccccccaaaaaa\r\nabccccccccccccccccccccaaaaacccccccccaaccccccccaaaaaacccccccccaaaaaaaaaaaaaaaacccccccccccccccaaaacccccccccaacccccccccccccccccccccccccccccccccccccccccccccccaaaaa";
            //string input = "Saxcdexxxmnuvz\r\naaxcxfxxxlotwz\r\nbbxcxgxxxkpsxE\r\nbbccxhihijqryz";

            char[,] charGrid = String2Grid(input);
            int gridHeight = charGrid.GetLength(1);
            int gridWidth = charGrid.GetLength(0);
            (int x, int y) sPos = (-1, -1);
            (int x, int y) ePos = (-1, -1);
            for (int y = gridHeight - 1; y >= 0; y--)
            {
                for (int x = 0; x <= gridWidth - 1; x++)
                {
                    char c = charGrid[x, y];
                    if (c == 'S')
                    {
                        sPos = (x, y);
                    }
                    else if (c == 'E')
                    {
                        ePos = (x, y);
                    }
                }
            }
            //Console.WriteLine($"Grid has height {gridHeight} and width {gridWidth}. Start is at {start.x}, {start.y}; end is at {end.x}, {end.y}");

            RenderGrid(charGrid);
            Console.WriteLine($"Insert a delay for the simulation in miliseconds...");
            string? userInput = Console.ReadLine();
            if (userInput == null)
            {
                throw new ArgumentNullException();
            }
            int sleepTime = int.Parse(userInput);
            int stepsPart1 = RunSimulation(charGrid, sPos, 'E', false, sleepTime);
            Console.WriteLine($"\r\nWent from S to E in {stepsPart1} steps!");
            Thread.Sleep(1000);
            int stepsPart2 = RunSimulation(charGrid, ePos, 'a', true, sleepTime);
            Console.WriteLine($"\r\n\r\nWent from E to a in {stepsPart2} steps!\r\n");

        }

        public static char[,] String2Grid(string input)
        {
            string[] inputPerLine = Utils.SplitLines(input); 
            int gridHeight = inputPerLine.Length;
            int gridWidth = inputPerLine[0].Length;

            char[,] grid = new char[gridWidth, gridHeight];
            for (int row = gridHeight - 1; row >= 0; row--)
            {
                int inverseRow = gridHeight - 1 - row; //we're flipping the Y axis around so that we end up with a nice grid where [0,0] results in what you'd expect as a coordinate
                for (int col = 0; col <= gridWidth - 1; col++)
                {
                    grid[col, inverseRow] = inputPerLine[row][col];
                }
            }
            return grid;
        }

        public static int Char2Elevation(char c)
        {
            if (c == 'S')
            {
                return Char2Elevation('a'); //I spent 2 hours tearing my hair out because I thought S's height was a-1 and E was z+1.
            }
            if (c == 'E')
            {
                return Char2Elevation('z'); //This worked for the example but not the input because the example goes S->a->b...y->z->E anyways.
            }
            return c - 96; //Chars are also ints, so I can just do this
        }

        public static List<(int x, int y)> GetClimbableNeighbors(char[,] charGrid, (int x, int y) square, bool descending = false, int maxHeightDiff = 1)
        {
            char ourChar = charGrid[square.x, square.y];
            List<(int x, int y)> candidates = new List<(int x, int y)>
            {
                (square.x + 1, square.y),
                (square.x - 1, square.y),
                (square.x, square.y + 1),
                (square.x, square.y - 1)
            };

            for (int i = 0; i < candidates.Count; i++)
            {
                (int x, int y) candidate = candidates[i];
                if (candidate.x < 0 || candidate.x > charGrid.GetLength(0) - 1 || candidate.y < 0 || candidate.y > charGrid.GetLength(1) - 1) //outta bounds!!
                {
                    candidates.Remove(candidate);
                    i--; //We're removing an item, so we better reduce i by 1 or we'll skip the next one
                    continue;
                }
                char candidateChar = charGrid[candidate.x, candidate.y];
                int ourHeight = Char2Elevation(ourChar);
                int candidateHeight = Char2Elevation(candidateChar);
                int heightDiff;
                if (descending)
                {
                    heightDiff = ourHeight - candidateHeight;
                }
                else
                {
                    heightDiff = candidateHeight - ourHeight;
                }

                //Console.WriteLine($"Comparing {ourChar} at {square.x},{square.y} with height {ourHeight} vs {candidateChar} at {candidate.x},{candidate.y} with height {candidateHeight}... A difference of {heightDiff}!");
                if (heightDiff > maxHeightDiff)
                {
                    //Console.WriteLine($"{ourChar} at {square.x},{square.y} FAILED TO CLIMB {candidateChar} at {candidate.x},{candidate.y}! ({ourHeight} vs {candidateHeight})!");
                    candidates.Remove(candidate);
                    i--; //We're removing an item, so we better reduce i by 1 or we'll skip the next one
                    continue;
                }
            }
            return candidates;
        }

        //Unused unless you want to know how many steps an arbitrary tile takes to reach
        public static void PrintSteps(int[,] stepsGrid, char[,] charGrid)
        {
            for (int y = stepsGrid.GetLength(1) - 1; y >= 0; y--)
            {
                string line = "";
                for (int x = 0; x <= stepsGrid.GetLength(0) - 1; x++)
                {
                    line += $"{charGrid[x, y]} {stepsGrid[x, y],-4}"; //Magic formatting!!!
                }
                Console.WriteLine(line);
            }
        }

        public static void RenderGrid(char[,] charGrid, List<(int x, int y)>? highlights = null, char highlightChar = '█')
        {
            string temp = "";
            for (int y = charGrid.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x <= charGrid.GetLength(0) - 1; x++)
                {
                    if (highlights != null && highlights.Contains((x, y)))
                    {
                        temp += highlightChar;
                    }
                    else
                    {
                        temp += $"{charGrid[x, y]}";
                    }
                }
                temp += "\n";
            }
            Console.SetWindowSize(Math.Max(50, charGrid.GetLength(0) + 1), charGrid.GetLength(1) + 5);
            Console.SetCursorPosition(0, 0);
            Console.Write(temp);
        }

        public static int RunSimulation(char[,] charGrid, (int x, int y) start, char endChar, bool descending = false, int sleepTime = 5)
        {
            List<(int x, int y)> activeSquares = new List<(int x, int y)>();
            activeSquares.Add(start);

            int[,] stepsGrid = new int[charGrid.GetLength(0), charGrid.GetLength(1)]; //Used to keep track of how many steps each tile takes to reach.
            List<(int x, int y)> successes; //The entries in this list will be added to activeSquares each turn.
            int finished = 0;
            while (finished == 0)
            {
                successes = new List<(int x, int y)>();
                for (int i = 0; i < activeSquares.Count; i++)
                {
                    (int x, int y) activeSquare = activeSquares[i];
                    int ourSteps = stepsGrid[activeSquare.x, activeSquare.y];
                    List<(int x, int y)> climbableNeighbors = GetClimbableNeighbors(charGrid, activeSquare, descending);
                    for (int j = 0; j < climbableNeighbors.Count; j++)
                    {
                        (int x, int y) climbableSquare = climbableNeighbors[j];
                        int climbableHeight = stepsGrid[climbableSquare.x, climbableSquare.y];
                        //Console.WriteLine($"Checking height of {climbableSquare.x},{climbableSquare.y}... It's {climbableHeight}!");
                        if (climbableHeight == 0) //Unmarked territory!
                        {
                            stepsGrid[climbableSquare.x, climbableSquare.y] = ourSteps + 1;
                            //Console.WriteLine($"{charGrid[activeSquare.x, activeSquare.y]} at {activeSquare.x},{activeSquare.y} climbs {charGrid[climbableSquare.x, climbableSquare.y]} at {climbableSquare.x},{climbableSquare.y}!");
                            if (charGrid[climbableSquare.x, climbableSquare.y] == endChar)
                            {
                                finished = ourSteps + 1;
                            }
                            successes.Add(climbableSquare);
                        }
                    }
                }
                RenderGrid(charGrid, successes);
                activeSquares = successes;
                Thread.Sleep(sleepTime);
            }
            return finished;
        }
    }
}
