using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day5
    {
        //https://adventofcode.com/2022/day/5
        public static void printRacks(List<List<char>> racks)
        {
            for(int i = 0; i < racks.Count; i++)
            {
                String rackVisualization = "";
                for(int j = 0; j < racks[i].Count; j++) { 
                    rackVisualization += "[" + racks[i][j].ToString() + "] ";
                }
                Console.WriteLine(rackVisualization);
            }
        }

        public static void Run()
        {
            string inputRacks = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]";
            string inputInstructions = "move 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";

            List<string> racksString = inputRacks.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.
            List<string> instructionsString = inputInstructions.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            int rackCount = (int)Math.Ceiling((double)racksString[0].Length / 4); //Rough attempt at determining how many racks there are, works for both inputs though
            List<List<char>> racks = new List<List<char>>();
            for(int i = 0; i < rackCount; i++)
            {
                List<char> rack = new List<char>();
                String rackString = racksString[i];
                char[] rackArray = rackString.ToCharArray();
                for (int j = 1; j < rackArray.Length; j += 4) //Starting at 1, since that skips the first bracket, then adding 4 to get to the next letter
                {
                    char crate = rackArray[j];
                    rack.Add(crate);
                }
                racks.Add(rack);
            }
            printRacks(racks);
        }
    }
}
