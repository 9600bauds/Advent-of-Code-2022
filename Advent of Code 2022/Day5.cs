using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day5
    {
        //https://adventofcode.com/2022/day/5

        static int maxStackHeight = 10;

        class Instruction
        {
            public int amount;
            public int fromRack;
            public int toRack;
        }

        public static List<List<char>> LoadRacks(List<string> rowStrings, int rackCount)
        {
            List<List<char>> racks = new List<List<char>>();
            for (int i = 0; i < rackCount; i++)
            {
                racks.Add(new List<char>()); //Initializing all the racks at 0
            }

            for (int i = rowStrings.Count - 1; i >= 0; i--)
            {
                string rowString = rowStrings[i];
                //Console.WriteLine("Analyzing {0}...", rowString);
                char[] rowArray = rowString.ToCharArray();

                int currentRack = 0;
                for (int j = 1; j < rowArray.Length; j += 4) //Starting at 1, since that skips the first bracket, then adding 4 to get to the next letter
                {
                    char crate = rowArray[j];
                    if (crate != ' ')
                    {
                        //Console.WriteLine("Popping {0} into rack {1}...", crate, currentRack);
                        racks[currentRack].Add(crate);
                    }
                    currentRack++;
                }
            }
            return racks;
        }

        public static void PrintRacks(List<List<char>> racks)
        {
            for (int i = maxStackHeight; i >= 0; i--)
            {
                //Console.WriteLine("Printing {0}...", i);
                string rowVisualization = "";
                for (int j = 0; j < racks.Count; j++)
                {
                    List<char> rack = racks[j];
                    //Console.WriteLine("Printing rack {0}, which has a count of {1}...", j, rack.Count);
                    if (rack.Count > i)
                    {
                        rowVisualization += "[" + rack[i].ToString() + "] ";
                    }
                    else
                    {
                        rowVisualization += "    ";
                    }
                }
                Console.WriteLine(rowVisualization);
            }
            string numbers = "";
            for (int i = 0; i < racks.Count; i++)
            {
                numbers += " " + (i + 1).ToString() + "  ";
            }
            Console.WriteLine(numbers);
        }

        public static void MoveCrate(List<List<char>> racks, int fromRackIndex, int toRackIndex, int amount, bool multipleAtATime = false)
        {
            List<char> fromRack = racks[fromRackIndex];
            List<char> toRack = racks[toRackIndex];

            if (multipleAtATime)
            {
                int index = fromRack.Count - amount;
                for (int i = 0; i < amount; i++)
                {
                    toRack.Add(fromRack[index]);
                    fromRack.RemoveAt(index);
                }
            }
            else
            {
                for (int i = 0; i < amount; i++)
                {
                    int index = fromRack.Count - 1;
                    toRack.Add(fromRack[index]);
                    fromRack.RemoveAt(index);
                }
            }
        }

        public static string GetSolution(List<List<char>> racks)
        {
            string solution = "";
            foreach (List<char> rack in racks)
            {
                solution += rack.Last();
            }
            return solution;
        }

        public static void Run()
        {
            //string inputRows = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]";
            //string inputInstructions = "move 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";
            string inputRows = "            [J] [Z] [G]            \r\n            [Z] [T] [S] [P] [R]    \r\n[R]         [Q] [V] [B] [G] [J]    \r\n[W] [W]     [N] [L] [V] [W] [C]    \r\n[F] [Q]     [T] [G] [C] [T] [T] [W]\r\n[H] [D] [W] [W] [H] [T] [R] [M] [B]\r\n[T] [G] [T] [R] [B] [P] [B] [G] [G]\r\n[S] [S] [B] [D] [F] [L] [Z] [N] [L]";
            string inputInstructions = "move 4 from 2 to 1\r\nmove 1 from 6 to 9\r\nmove 6 from 4 to 7\r\nmove 1 from 2 to 5\r\nmove 3 from 6 to 3\r\nmove 4 from 3 to 9\r\nmove 2 from 1 to 3\r\nmove 6 from 7 to 5\r\nmove 5 from 7 to 6\r\nmove 6 from 8 to 7\r\nmove 6 from 7 to 6\r\nmove 1 from 8 to 3\r\nmove 15 from 6 to 4\r\nmove 7 from 5 to 6\r\nmove 1 from 7 to 2\r\nmove 2 from 5 to 3\r\nmove 5 from 9 to 8\r\nmove 5 from 5 to 6\r\nmove 1 from 7 to 4\r\nmove 5 from 6 to 5\r\nmove 3 from 3 to 8\r\nmove 4 from 5 to 8\r\nmove 1 from 2 to 8\r\nmove 7 from 1 to 2\r\nmove 2 from 6 to 2\r\nmove 2 from 5 to 8\r\nmove 1 from 1 to 8\r\nmove 8 from 2 to 6\r\nmove 3 from 3 to 4\r\nmove 4 from 9 to 3\r\nmove 5 from 3 to 6\r\nmove 5 from 6 to 8\r\nmove 3 from 4 to 8\r\nmove 13 from 6 to 5\r\nmove 14 from 4 to 8\r\nmove 1 from 2 to 6\r\nmove 1 from 4 to 2\r\nmove 12 from 5 to 4\r\nmove 30 from 8 to 6\r\nmove 1 from 8 to 9\r\nmove 1 from 9 to 4\r\nmove 15 from 4 to 5\r\nmove 1 from 2 to 9\r\nmove 1 from 4 to 2\r\nmove 1 from 2 to 1\r\nmove 1 from 9 to 3\r\nmove 8 from 5 to 7\r\nmove 2 from 5 to 6\r\nmove 7 from 8 to 1\r\nmove 1 from 3 to 4\r\nmove 1 from 7 to 3\r\nmove 1 from 4 to 6\r\nmove 26 from 6 to 7\r\nmove 1 from 3 to 7\r\nmove 3 from 7 to 2\r\nmove 1 from 1 to 9\r\nmove 16 from 7 to 5\r\nmove 2 from 7 to 4\r\nmove 12 from 7 to 6\r\nmove 1 from 1 to 9\r\nmove 4 from 6 to 1\r\nmove 7 from 1 to 5\r\nmove 2 from 1 to 8\r\nmove 1 from 7 to 2\r\nmove 1 from 1 to 4\r\nmove 2 from 4 to 5\r\nmove 1 from 9 to 4\r\nmove 3 from 6 to 9\r\nmove 8 from 6 to 5\r\nmove 5 from 5 to 9\r\nmove 19 from 5 to 8\r\nmove 1 from 9 to 8\r\nmove 3 from 8 to 7\r\nmove 1 from 7 to 3\r\nmove 8 from 5 to 2\r\nmove 2 from 4 to 2\r\nmove 4 from 9 to 8\r\nmove 1 from 2 to 3\r\nmove 2 from 3 to 2\r\nmove 4 from 9 to 5\r\nmove 8 from 8 to 4\r\nmove 9 from 8 to 5\r\nmove 5 from 8 to 4\r\nmove 5 from 5 to 7\r\nmove 12 from 2 to 3\r\nmove 2 from 2 to 8\r\nmove 1 from 8 to 6\r\nmove 1 from 8 to 7\r\nmove 10 from 4 to 3\r\nmove 1 from 2 to 9\r\nmove 13 from 5 to 3\r\nmove 1 from 7 to 5\r\nmove 27 from 3 to 4\r\nmove 1 from 8 to 7\r\nmove 3 from 5 to 2\r\nmove 6 from 6 to 3\r\nmove 2 from 4 to 1\r\nmove 27 from 4 to 2\r\nmove 2 from 7 to 8\r\nmove 23 from 2 to 4\r\nmove 2 from 1 to 4\r\nmove 2 from 7 to 2\r\nmove 4 from 2 to 9\r\nmove 10 from 3 to 4\r\nmove 1 from 3 to 5\r\nmove 1 from 5 to 1\r\nmove 5 from 2 to 5\r\nmove 30 from 4 to 2\r\nmove 1 from 8 to 9\r\nmove 1 from 8 to 1\r\nmove 27 from 2 to 3\r\nmove 2 from 4 to 2\r\nmove 1 from 9 to 4\r\nmove 2 from 1 to 3\r\nmove 8 from 3 to 7\r\nmove 19 from 3 to 1\r\nmove 1 from 4 to 7\r\nmove 5 from 9 to 1\r\nmove 4 from 2 to 9\r\nmove 4 from 3 to 4\r\nmove 1 from 3 to 5\r\nmove 1 from 2 to 7\r\nmove 1 from 9 to 3\r\nmove 1 from 9 to 1\r\nmove 5 from 5 to 4\r\nmove 5 from 7 to 3\r\nmove 1 from 5 to 6\r\nmove 23 from 1 to 6\r\nmove 1 from 9 to 2\r\nmove 1 from 2 to 5\r\nmove 24 from 6 to 9\r\nmove 6 from 4 to 7\r\nmove 4 from 4 to 8\r\nmove 1 from 4 to 9\r\nmove 4 from 7 to 4\r\nmove 4 from 3 to 4\r\nmove 4 from 9 to 8\r\nmove 6 from 7 to 9\r\nmove 4 from 7 to 6\r\nmove 1 from 1 to 4\r\nmove 2 from 6 to 4\r\nmove 1 from 6 to 2\r\nmove 1 from 1 to 8\r\nmove 1 from 7 to 3\r\nmove 1 from 6 to 9\r\nmove 13 from 4 to 2\r\nmove 3 from 3 to 2\r\nmove 15 from 9 to 8\r\nmove 1 from 5 to 9\r\nmove 5 from 9 to 1\r\nmove 4 from 1 to 7\r\nmove 4 from 7 to 3\r\nmove 8 from 2 to 7\r\nmove 9 from 8 to 2\r\nmove 1 from 1 to 2\r\nmove 7 from 9 to 2\r\nmove 4 from 3 to 1\r\nmove 4 from 1 to 4\r\nmove 2 from 9 to 1\r\nmove 20 from 2 to 8\r\nmove 3 from 4 to 8\r\nmove 1 from 2 to 3\r\nmove 4 from 2 to 7\r\nmove 1 from 3 to 4\r\nmove 1 from 9 to 3\r\nmove 1 from 4 to 7\r\nmove 1 from 2 to 5\r\nmove 1 from 4 to 3\r\nmove 2 from 1 to 6\r\nmove 1 from 5 to 6\r\nmove 1 from 7 to 1\r\nmove 12 from 7 to 2\r\nmove 12 from 2 to 6\r\nmove 9 from 6 to 2\r\nmove 1 from 6 to 8\r\nmove 1 from 3 to 9\r\nmove 8 from 2 to 4\r\nmove 1 from 9 to 6\r\nmove 1 from 4 to 6\r\nmove 4 from 4 to 9\r\nmove 1 from 4 to 9\r\nmove 1 from 1 to 5\r\nmove 2 from 6 to 3\r\nmove 1 from 5 to 4\r\nmove 1 from 2 to 8\r\nmove 10 from 8 to 6\r\nmove 10 from 8 to 3\r\nmove 1 from 3 to 4\r\nmove 8 from 8 to 1\r\nmove 3 from 9 to 8\r\nmove 2 from 9 to 1\r\nmove 11 from 6 to 7\r\nmove 1 from 1 to 7\r\nmove 8 from 1 to 4\r\nmove 3 from 6 to 7\r\nmove 1 from 1 to 4\r\nmove 14 from 8 to 6\r\nmove 1 from 8 to 7\r\nmove 1 from 6 to 8\r\nmove 6 from 4 to 1\r\nmove 1 from 8 to 5\r\nmove 4 from 1 to 8\r\nmove 2 from 7 to 1\r\nmove 1 from 6 to 7\r\nmove 5 from 4 to 2\r\nmove 2 from 4 to 3\r\nmove 4 from 2 to 8\r\nmove 15 from 7 to 3\r\nmove 3 from 3 to 6\r\nmove 1 from 5 to 2\r\nmove 21 from 3 to 6\r\nmove 2 from 8 to 7\r\nmove 1 from 7 to 8\r\nmove 32 from 6 to 9\r\nmove 1 from 7 to 8\r\nmove 5 from 8 to 4\r\nmove 2 from 8 to 7\r\nmove 14 from 9 to 8\r\nmove 14 from 8 to 1\r\nmove 2 from 6 to 1\r\nmove 2 from 7 to 4\r\nmove 1 from 9 to 3\r\nmove 17 from 9 to 5\r\nmove 6 from 1 to 8\r\nmove 4 from 4 to 6\r\nmove 2 from 2 to 5\r\nmove 2 from 8 to 2\r\nmove 1 from 6 to 7\r\nmove 2 from 2 to 6\r\nmove 4 from 3 to 2\r\nmove 7 from 6 to 3\r\nmove 6 from 5 to 7\r\nmove 1 from 8 to 9\r\nmove 1 from 6 to 7\r\nmove 4 from 8 to 6\r\nmove 1 from 9 to 3\r\nmove 4 from 1 to 4\r\nmove 12 from 5 to 9\r\nmove 7 from 7 to 8\r\nmove 3 from 4 to 2\r\nmove 8 from 9 to 4\r\nmove 2 from 6 to 2\r\nmove 1 from 7 to 4\r\nmove 2 from 6 to 9\r\nmove 1 from 5 to 3\r\nmove 1 from 8 to 1\r\nmove 2 from 8 to 7\r\nmove 2 from 2 to 9\r\nmove 7 from 2 to 3\r\nmove 8 from 4 to 1\r\nmove 2 from 8 to 4\r\nmove 4 from 9 to 7\r\nmove 2 from 9 to 5\r\nmove 16 from 1 to 3\r\nmove 3 from 7 to 4\r\nmove 1 from 7 to 6\r\nmove 1 from 6 to 2\r\nmove 2 from 5 to 3\r\nmove 10 from 4 to 2\r\nmove 2 from 8 to 7\r\nmove 19 from 3 to 8\r\nmove 17 from 3 to 9\r\nmove 3 from 1 to 7\r\nmove 17 from 9 to 2\r\nmove 1 from 7 to 5\r\nmove 1 from 7 to 5\r\nmove 2 from 5 to 7\r\nmove 2 from 9 to 2\r\nmove 6 from 7 to 6\r\nmove 3 from 6 to 7\r\nmove 1 from 8 to 9\r\nmove 1 from 9 to 3\r\nmove 4 from 2 to 5\r\nmove 17 from 2 to 3\r\nmove 3 from 7 to 5\r\nmove 1 from 5 to 3\r\nmove 7 from 2 to 3\r\nmove 2 from 2 to 4\r\nmove 1 from 7 to 1\r\nmove 1 from 1 to 5\r\nmove 2 from 5 to 3\r\nmove 1 from 4 to 5\r\nmove 1 from 4 to 3\r\nmove 14 from 3 to 5\r\nmove 17 from 8 to 7\r\nmove 2 from 6 to 2\r\nmove 12 from 3 to 5\r\nmove 15 from 5 to 9\r\nmove 7 from 7 to 3\r\nmove 7 from 7 to 6\r\nmove 1 from 2 to 3\r\nmove 11 from 9 to 6\r\nmove 13 from 5 to 7\r\nmove 10 from 6 to 8\r\nmove 6 from 8 to 3\r\nmove 2 from 5 to 8\r\nmove 1 from 2 to 9\r\nmove 10 from 7 to 6\r\nmove 9 from 6 to 8\r\nmove 1 from 5 to 1\r\nmove 10 from 6 to 4\r\nmove 8 from 4 to 5\r\nmove 1 from 1 to 2\r\nmove 3 from 9 to 1\r\nmove 10 from 3 to 7\r\nmove 1 from 4 to 7\r\nmove 12 from 7 to 9\r\nmove 7 from 3 to 5\r\nmove 13 from 8 to 7\r\nmove 3 from 9 to 5\r\nmove 5 from 5 to 6\r\nmove 3 from 1 to 9\r\nmove 5 from 9 to 6\r\nmove 10 from 6 to 4\r\nmove 15 from 7 to 5\r\nmove 3 from 9 to 4\r\nmove 1 from 4 to 3\r\nmove 3 from 8 to 9\r\nmove 6 from 9 to 6\r\nmove 2 from 5 to 1\r\nmove 1 from 2 to 7\r\nmove 12 from 5 to 8\r\nmove 3 from 9 to 5\r\nmove 11 from 5 to 6\r\nmove 1 from 1 to 2\r\nmove 1 from 2 to 8\r\nmove 3 from 7 to 8\r\nmove 10 from 8 to 3\r\nmove 1 from 1 to 7\r\nmove 10 from 4 to 9\r\nmove 1 from 7 to 8\r\nmove 5 from 5 to 3\r\nmove 15 from 6 to 5\r\nmove 8 from 3 to 9\r\nmove 3 from 4 to 5\r\nmove 1 from 7 to 8\r\nmove 8 from 8 to 9\r\nmove 1 from 6 to 5\r\nmove 5 from 3 to 2\r\nmove 5 from 2 to 3\r\nmove 5 from 9 to 8\r\nmove 1 from 6 to 8\r\nmove 2 from 5 to 1\r\nmove 4 from 3 to 2\r\nmove 16 from 5 to 6\r\nmove 3 from 5 to 9\r\nmove 4 from 8 to 5\r\nmove 8 from 6 to 4\r\nmove 4 from 2 to 3\r\nmove 1 from 1 to 4\r\nmove 6 from 3 to 6\r\nmove 24 from 9 to 2\r\nmove 1 from 1 to 9\r\nmove 1 from 9 to 4\r\nmove 2 from 4 to 5\r\nmove 1 from 3 to 2\r\nmove 10 from 6 to 8\r\nmove 22 from 2 to 6\r\nmove 1 from 2 to 7\r\nmove 1 from 7 to 5\r\nmove 10 from 8 to 9\r\nmove 7 from 9 to 3\r\nmove 6 from 4 to 8\r\nmove 3 from 9 to 2\r\nmove 5 from 8 to 3\r\nmove 1 from 4 to 1\r\nmove 1 from 8 to 3\r\nmove 3 from 6 to 2\r\nmove 5 from 5 to 1\r\nmove 1 from 5 to 3\r\nmove 5 from 6 to 3\r\nmove 1 from 2 to 7\r\nmove 16 from 3 to 2\r\nmove 1 from 8 to 1\r\nmove 1 from 4 to 7\r\nmove 1 from 5 to 3\r\nmove 6 from 6 to 4\r\nmove 14 from 2 to 8\r\nmove 3 from 3 to 5\r\nmove 2 from 3 to 6\r\nmove 3 from 5 to 6\r\nmove 4 from 6 to 4\r\nmove 3 from 4 to 8\r\nmove 7 from 2 to 9\r\nmove 2 from 2 to 1\r\nmove 9 from 8 to 4\r\nmove 7 from 1 to 7\r\nmove 8 from 7 to 5\r\nmove 2 from 8 to 4\r\nmove 3 from 9 to 6\r\nmove 4 from 4 to 6\r\nmove 1 from 7 to 3\r\nmove 4 from 8 to 2\r\nmove 2 from 9 to 8\r\nmove 9 from 6 to 7\r\nmove 1 from 9 to 8\r\nmove 1 from 1 to 5\r\nmove 3 from 4 to 5\r\nmove 1 from 3 to 2\r\nmove 5 from 8 to 2\r\nmove 9 from 2 to 7\r\nmove 1 from 6 to 7\r\nmove 1 from 6 to 2\r\nmove 9 from 7 to 4\r\nmove 2 from 5 to 9\r\nmove 10 from 4 to 6\r\nmove 1 from 8 to 6\r\nmove 5 from 4 to 3\r\nmove 5 from 4 to 9\r\nmove 5 from 9 to 5\r\nmove 1 from 1 to 7\r\nmove 4 from 7 to 8\r\nmove 8 from 5 to 3\r\nmove 3 from 3 to 8\r\nmove 6 from 7 to 6\r\nmove 3 from 3 to 1\r\nmove 5 from 3 to 7\r\nmove 1 from 9 to 6\r\nmove 2 from 7 to 6\r\nmove 1 from 9 to 3\r\nmove 4 from 6 to 9\r\nmove 2 from 2 to 6\r\nmove 1 from 7 to 3\r\nmove 6 from 5 to 4\r\nmove 7 from 6 to 9\r\nmove 6 from 6 to 8\r\nmove 2 from 1 to 2\r\nmove 1 from 5 to 1\r\nmove 5 from 8 to 5\r\nmove 1 from 3 to 9\r\nmove 4 from 4 to 5\r\nmove 10 from 9 to 2\r\nmove 14 from 6 to 4\r\nmove 1 from 3 to 8\r\nmove 1 from 8 to 5\r\nmove 2 from 7 to 9\r\nmove 1 from 1 to 2\r\nmove 14 from 4 to 7\r\nmove 1 from 1 to 4\r\nmove 3 from 4 to 1\r\nmove 3 from 5 to 1\r\nmove 6 from 5 to 1\r\nmove 10 from 7 to 3\r\nmove 6 from 1 to 5\r\nmove 6 from 1 to 7\r\nmove 3 from 8 to 3\r\nmove 1 from 5 to 1\r\nmove 3 from 9 to 6\r\nmove 1 from 9 to 3\r\nmove 6 from 5 to 9\r\nmove 2 from 6 to 1\r\nmove 9 from 2 to 1\r\nmove 6 from 9 to 6\r\nmove 2 from 8 to 7\r\nmove 5 from 7 to 3\r\nmove 7 from 7 to 5\r\nmove 4 from 2 to 8\r\nmove 6 from 8 to 3\r\nmove 1 from 9 to 4\r\nmove 1 from 7 to 3\r\nmove 2 from 5 to 3\r\nmove 7 from 6 to 4\r\nmove 28 from 3 to 4\r\nmove 1 from 3 to 8\r\nmove 1 from 5 to 9\r\nmove 9 from 4 to 5\r\nmove 12 from 4 to 5\r\nmove 2 from 4 to 6\r\nmove 5 from 4 to 6\r\nmove 1 from 3 to 8\r\nmove 10 from 5 to 8\r\nmove 10 from 5 to 4\r\nmove 5 from 5 to 9\r\nmove 3 from 4 to 1\r\nmove 5 from 6 to 9\r\nmove 2 from 6 to 7\r\nmove 2 from 7 to 5\r\nmove 10 from 9 to 4\r\nmove 1 from 8 to 5\r\nmove 5 from 1 to 5\r\nmove 8 from 8 to 7\r\nmove 8 from 5 to 3\r\nmove 8 from 7 to 8\r\nmove 2 from 8 to 2\r\nmove 7 from 3 to 2\r\nmove 21 from 4 to 7\r\nmove 10 from 1 to 9\r\nmove 3 from 4 to 5\r\nmove 1 from 4 to 8\r\nmove 1 from 8 to 3\r\nmove 7 from 8 to 5\r\nmove 2 from 3 to 1\r\nmove 7 from 7 to 2\r\nmove 1 from 1 to 4\r\nmove 1 from 1 to 6\r\nmove 8 from 9 to 3\r\nmove 2 from 8 to 4\r\nmove 3 from 3 to 1\r\nmove 3 from 4 to 7\r\nmove 1 from 6 to 7\r\nmove 5 from 2 to 4\r\nmove 2 from 1 to 6";

            List<string> rowStrings = inputRows.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.
            List<string> instructionStrings = inputInstructions.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            int rackCount = (int)Math.Ceiling((double)rowStrings[0].Length / 4); //Rough attempt at determining how many racks there are, works for both inputs though
            List<List<char>> racks = LoadRacks(rowStrings, rackCount);

            string pattern = @"(\d+)"; //Regex pattern for digits 0-9
            Regex myRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            List<Instruction> finalInstructions = new List<Instruction>();
            foreach (string instructionString in instructionStrings)
            {
                MatchCollection matches = myRegex.Matches(instructionString);
                Instruction instruction = new Instruction();
                instruction.amount = int.Parse(matches[0].ToString());
                instruction.fromRack = int.Parse(matches[1].ToString()); //Note that this is the number of the rack, substract 1 to get the index of it
                instruction.toRack = int.Parse(matches[2].ToString()); //Note that this is the number of the rack, substract 1 to get the index of it
                finalInstructions.Add(instruction);
            }

            Console.WriteLine("Starting state:");
            PrintRacks(racks);
            foreach (Instruction instruction in finalInstructions)
            {
                MoveCrate(racks, instruction.fromRack - 1, instruction.toRack - 1, instruction.amount, false);
                //Console.WriteLine("Moving {0} from {1} to {2} with the CrateMover9000...", instruction.amount, instruction.fromRack, instruction.toRack);
                //PrintRacks(racks);
            }
            Console.WriteLine("Final state:");
            PrintRacks(racks);
            Console.WriteLine("Solution: {0}", GetSolution(racks));

            Console.WriteLine("----");
            Console.WriteLine("**Starting over with the CRATEMOVER9001**");
            Console.WriteLine("----");
            racks = LoadRacks(rowStrings, rackCount); //Yup, we're just regenerating this.

            Console.WriteLine("Starting state:");
            PrintRacks(racks);
            foreach (Instruction instruction in finalInstructions)
            {
                MoveCrate(racks, instruction.fromRack - 1, instruction.toRack - 1, instruction.amount, true);
                //Console.WriteLine("Moving {0} from {1} to {2} with the CrateMover9001...", instruction.amount, instruction.fromRack, instruction.toRack);
                //PrintRacks(racks);
            }
            Console.WriteLine("Final state:");
            PrintRacks(racks);
            Console.WriteLine("Solution: {0}", GetSolution(racks));

        }
    }
}
