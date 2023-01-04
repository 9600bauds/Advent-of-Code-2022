using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day2
    {
        //https://adventofcode.com/2022/day/2

        //How to properly set defines for the strings? I had a bug because I typed "Scissor" instead of "Scissors" in an if.
        static Dictionary<string, string> dictColumnA = new Dictionary<string, string>(){
            {"A", "Rock"},
            {"B", "Paper"},
            {"C", "Scissors"}
        };
        static Dictionary<string, string> dictColumnB = new Dictionary<string, string>(){
            {"X", "Rock"},
            {"Y", "Paper"},
            {"Z", "Scissors"}
        };
        static Dictionary<string, long> shapeToScore = new Dictionary<string, long>(){
            {"Rock", 1},
            {"Paper", 2},
            {"Scissors", 3}
        };
        static Dictionary<string, string> beats = new Dictionary<string, string>
        {
            {"Rock", "Scissors" },
            {"Paper", "Rock" },
            {"Scissors", "Paper" }
        };
        static Dictionary<string, string> beatenBy = new Dictionary<string, string>
        {
            {"Rock", "Paper" },
            {"Paper", "Scissors" },
            {"Scissors", "Rock" }
        };

        static long pointsPerDraw = 3;
        static long pointsPerWin = 6;
        static long pointsPerLoss = 0;

        static long roundToScore(string[] round) //round[0] = elf's play, round[1] = my play
        {
            long score = 0;
            string elfPlays = round[0];
            string myPlay = round[1];

            score += shapeToScore[myPlay];

            if (elfPlays == myPlay)
            {
                score += pointsPerDraw;
            }
            else if (beats[elfPlays] == myPlay)
            {
                score += pointsPerLoss;
            }
            else if (beats[myPlay] == elfPlays)
            {
                score += pointsPerWin;
            }
            return score;
        }
        public static void Run()
        {
            string input = "B Z\r\nB Z\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nC Y\r\nA Z\r\nB Y\r\nA Y\r\nC X\r\nA Y\r\nA Y\r\nC Y\r\nA Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nA Y\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nB X\r\nA X\r\nA Y\r\nC X\r\nB Y\r\nC Y\r\nB Y\r\nB X\r\nC X\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nA X\r\nA Y\r\nB Y\r\nC Y\r\nC X\r\nA X\r\nB Y\r\nC Z\r\nB Y\r\nC X\r\nA Y\r\nA X\r\nC X\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nB X\r\nC Y\r\nC Z\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nC X\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nC X\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nA X\r\nA X\r\nB Y\r\nB Y\r\nC Z\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nA Y\r\nA Y\r\nA X\r\nC Y\r\nA X\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nA Y\r\nA X\r\nB Z\r\nC Y\r\nA Y\r\nA X\r\nC Y\r\nB Y\r\nC Y\r\nA Y\r\nA X\r\nA X\r\nA X\r\nA Y\r\nA X\r\nB Y\r\nA Y\r\nC Y\r\nA X\r\nB Y\r\nC Y\r\nB Y\r\nA X\r\nB Y\r\nB Y\r\nC Z\r\nC Y\r\nC X\r\nA Y\r\nC X\r\nB Y\r\nB Y\r\nC Y\r\nA X\r\nA X\r\nC Z\r\nB Z\r\nC Y\r\nC Y\r\nA X\r\nA X\r\nB Y\r\nB Z\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nA X\r\nA X\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nC Y\r\nA X\r\nB Y\r\nA Y\r\nA X\r\nC Y\r\nC X\r\nA Y\r\nA Y\r\nC Y\r\nC X\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nC Y\r\nB Y\r\nC X\r\nA Y\r\nC X\r\nA X\r\nB Y\r\nC X\r\nA Y\r\nA Y\r\nA Y\r\nC Y\r\nC Y\r\nA Y\r\nA X\r\nC Y\r\nC Z\r\nB X\r\nC Z\r\nB Z\r\nA Z\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nC X\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nB Z\r\nA Y\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nB X\r\nA Y\r\nA X\r\nA Y\r\nA X\r\nA Y\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nA X\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nA Z\r\nC Y\r\nB Z\r\nC X\r\nC Y\r\nC X\r\nB Y\r\nC X\r\nB Y\r\nA Y\r\nC Y\r\nA Y\r\nA X\r\nC Y\r\nA X\r\nA X\r\nC X\r\nC X\r\nC Y\r\nC X\r\nC Y\r\nA X\r\nB Z\r\nA Y\r\nB X\r\nB Y\r\nC Z\r\nB Y\r\nB Y\r\nB Y\r\nC X\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nC Y\r\nB Z\r\nB Y\r\nA X\r\nA Y\r\nC Y\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nA X\r\nB Y\r\nB Z\r\nC Y\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nC X\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nA Z\r\nC Y\r\nA Y\r\nA Y\r\nC Y\r\nC X\r\nA Y\r\nB Y\r\nA Y\r\nC X\r\nB Y\r\nA Y\r\nC Y\r\nB Y\r\nB Z\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nA Y\r\nB Y\r\nC Y\r\nB Y\r\nA X\r\nC Z\r\nC Y\r\nA Y\r\nC Y\r\nB Y\r\nC Z\r\nA Y\r\nA Y\r\nC Y\r\nC X\r\nB Y\r\nC Y\r\nC X\r\nB Y\r\nC X\r\nA Y\r\nC X\r\nC Y\r\nB Y\r\nB Y\r\nA Y\r\nB Y\r\nA X\r\nC X\r\nC Y\r\nB Y\r\nA Y\r\nA X\r\nC Y\r\nC Y\r\nC Y\r\nC X\r\nB Z\r\nB Y\r\nC Y\r\nA X\r\nC Y\r\nA X\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nC X\r\nC Y\r\nC Y\r\nA Z\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nB X\r\nA Y\r\nB Y\r\nB Y\r\nB Z\r\nC Y\r\nA X\r\nA X\r\nA Y\r\nB Z\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nA X\r\nB Y\r\nC Y\r\nA Y\r\nB Y\r\nA X\r\nC Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nA X\r\nA Y\r\nB X\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nA X\r\nB Y\r\nA X\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nA Y\r\nA X\r\nC Y\r\nA Y\r\nA Y\r\nB Z\r\nC Y\r\nA X\r\nC X\r\nB Y\r\nC X\r\nC Y\r\nC X\r\nC X\r\nC Z\r\nA Y\r\nA X\r\nA Y\r\nB Z\r\nB Y\r\nA X\r\nA Y\r\nA X\r\nB Y\r\nA Y\r\nC X\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nC Y\r\nA Y\r\nA Z\r\nC Y\r\nC Y\r\nC Z\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nC Y\r\nA X\r\nB X\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nA Y\r\nC Y\r\nC X\r\nC X\r\nC X\r\nC X\r\nC Y\r\nC Y\r\nC X\r\nB Y\r\nA Y\r\nA X\r\nB Y\r\nC X\r\nB X\r\nC Y\r\nB Y\r\nC Y\r\nC X\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nA Y\r\nC Y\r\nC Y\r\nA X\r\nA X\r\nC X\r\nA Y\r\nA Y\r\nB Y\r\nB X\r\nB Z\r\nC Z\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nC Z\r\nA Y\r\nC X\r\nA Y\r\nA Y\r\nC Y\r\nC X\r\nB Y\r\nA Y\r\nB Y\r\nB Y\r\nC Z\r\nA Y\r\nA Y\r\nA X\r\nC Y\r\nC Z\r\nB Y\r\nA X\r\nC Y\r\nC X\r\nB Y\r\nC Z\r\nA X\r\nA X\r\nA Y\r\nC Y\r\nA Z\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nC X\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nA Y\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nC X\r\nA X\r\nC X\r\nB Y\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nB X\r\nA Y\r\nA Y\r\nC Y\r\nC X\r\nC X\r\nC Y\r\nC X\r\nA X\r\nA Y\r\nA Z\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nC X\r\nC Y\r\nA Y\r\nB Z\r\nA Y\r\nA X\r\nA Y\r\nC Y\r\nA Y\r\nA X\r\nC Y\r\nB Y\r\nB Y\r\nC X\r\nA X\r\nA Z\r\nC Y\r\nB Y\r\nA X\r\nA Y\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nB Y\r\nA Y\r\nA X\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nC X\r\nB Y\r\nB Y\r\nB Y\r\nC Z\r\nC Y\r\nC X\r\nC X\r\nB Y\r\nA X\r\nA Y\r\nB X\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nC Y\r\nC Z\r\nA Y\r\nC X\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nB X\r\nB X\r\nB Y\r\nA Y\r\nA Y\r\nA Y\r\nC Y\r\nC Z\r\nB X\r\nC Y\r\nA Z\r\nA X\r\nB Y\r\nC Y\r\nB Y\r\nB X\r\nA Y\r\nA Y\r\nC Y\r\nB Y\r\nA X\r\nC X\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nA X\r\nA Y\r\nA X\r\nC Y\r\nA Y\r\nC Y\r\nB Y\r\nA Y\r\nC Y\r\nA X\r\nA Y\r\nC Y\r\nC X\r\nC Y\r\nA X\r\nB Y\r\nB Y\r\nB Z\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nA X\r\nC X\r\nC Y\r\nC Y\r\nB Y\r\nC Y\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nB Y\r\nC X\r\nB Y\r\nC X\r\nA Y\r\nC Y\r\nA X\r\nC X\r\nB Y\r\nA Y\r\nB Y\r\nC X\r\nB Y\r\nC Y\r\nC Z\r\nA Y\r\nC Z\r\nC X\r\nC X\r\nA Y\r\nA X\r\nA Y\r\nB Z\r\nC Y\r\nC Y\r\nB Y\r\nA X\r\nA Y\r\nB Y\r\nC Y\r\nA Y\r\nA X\r\nB Y\r\nC Y\r\nA Z\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nC X\r\nA X\r\nA Y\r\nB Y\r\nC Y\r\nB X\r\nC Y\r\nA X\r\nA Y\r\nA Y\r\nC Y\r\nA Y\r\nC Y\r\nA Y\r\nA X\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nA Y\r\nC Y\r\nA X\r\nC Y\r\nB Y\r\nB X\r\nC Y\r\nB Z\r\nC Y\r\nB X\r\nB Y\r\nC X\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nA X\r\nC Z\r\nC X\r\nB Y\r\nA X\r\nA X\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nA X\r\nC Y\r\nB Y\r\nA X\r\nA Y\r\nB Y\r\nC Y\r\nA X\r\nA X\r\nA Y\r\nA X\r\nA X\r\nA Y\r\nA Y\r\nA Y\r\nA X\r\nC Y\r\nA X\r\nA Y\r\nA Y\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nB Y\r\nB Z\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nC X\r\nA Y\r\nC Y\r\nA Y\r\nC Y\r\nB Y\r\nC X\r\nB Y\r\nB Y\r\nC Z\r\nC Y\r\nB Z\r\nB X\r\nB Y\r\nA Z\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nA X\r\nB Y\r\nC Y\r\nA Z\r\nA Y\r\nC Y\r\nC Y\r\nB Y\r\nC Y\r\nC X\r\nB Y\r\nC Y\r\nC X\r\nB X\r\nC X\r\nA X\r\nA X\r\nA Y\r\nC Y\r\nB Y\r\nC X\r\nB X\r\nA X\r\nB Y\r\nC Y\r\nA Y\r\nC X\r\nC Y\r\nB Y\r\nC Y\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nB X\r\nC X\r\nA Y\r\nB Y\r\nA X\r\nB Y\r\nC Y\r\nB Y\r\nA X\r\nA Y\r\nC Y\r\nA X\r\nC Z\r\nC Y\r\nA X\r\nB Y\r\nA Y\r\nB X\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nB Y\r\nB X\r\nA Y\r\nB Y\r\nC X\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nB X\r\nA Y\r\nA X\r\nB Y\r\nA X\r\nA X\r\nA Y\r\nB Y\r\nA Y\r\nA Y\r\nC Y\r\nB X\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nC Y\r\nA Y\r\nC Y\r\nA X\r\nB Y\r\nB Y\r\nA X\r\nA X\r\nA X\r\nA Y\r\nA X\r\nC Y\r\nC Z\r\nB Y\r\nB Y\r\nA X\r\nC Y\r\nB X\r\nA Y\r\nB Y\r\nA Y\r\nB Z\r\nB Y\r\nB Y\r\nA Z\r\nB Y\r\nA Y\r\nB Y\r\nB Y\r\nC X\r\nB Y\r\nA X\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nA X\r\nC Y\r\nC Y\r\nC X\r\nC Y\r\nB Y\r\nB Z\r\nA Y\r\nB Y\r\nC X\r\nA Y\r\nB Y\r\nB Y\r\nA X\r\nB Y\r\nA Z\r\nB Y\r\nA Y\r\nC X\r\nB Y\r\nA Y\r\nB X\r\nA X\r\nC X\r\nC Y\r\nB Y\r\nA X\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nA Y\r\nC X\r\nC Y\r\nA Y\r\nC Y\r\nA Y\r\nC Z\r\nA Y\r\nB Y\r\nA Y\r\nC Z\r\nA Y\r\nC Y\r\nA Y\r\nC X\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nC Z\r\nA X\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nB Y\r\nB Z\r\nB X\r\nA Y\r\nA Y\r\nA Y\r\nC X\r\nB Y\r\nA Y\r\nC Y\r\nA Y\r\nA Z\r\nB Y\r\nB Y\r\nA X\r\nB Y\r\nB Y\r\nA Y\r\nC X\r\nA X\r\nA Y\r\nA Y\r\nC Y\r\nB X\r\nA Y\r\nC Y\r\nC X\r\nA Z\r\nB Y\r\nB Y\r\nA X\r\nA Y\r\nC X\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nB X\r\nC Y\r\nA X\r\nA Y\r\nC X\r\nA Y\r\nC Y\r\nA Y\r\nC X\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nA X\r\nB Y\r\nB Y\r\nB Y\r\nA Y\r\nB Y\r\nB Y\r\nB Y\r\nC X\r\nB Y\r\nA Y\r\nC X\r\nB Y\r\nB Y\r\nA Y\r\nC Y\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nC X\r\nC X\r\nC Y\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nA Z\r\nB Y\r\nC X\r\nB Y\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nA X\r\nA Y\r\nA Y\r\nC X\r\nC X\r\nB Y\r\nC Z\r\nC X\r\nA Z\r\nB Y\r\nA Y\r\nB Y\r\nC X\r\nA Y\r\nB Z\r\nC Y\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nC Y\r\nA X\r\nB Y\r\nA Y\r\nC Y\r\nA Y\r\nC X\r\nB Z\r\nB X\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nC X\r\nA Y\r\nA Y\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nA X\r\nA Y\r\nA Y\r\nB Z\r\nA X\r\nA X\r\nC Y\r\nC Y\r\nC X\r\nB X\r\nA Z\r\nB Y\r\nA X\r\nA Y\r\nB Y\r\nA Y\r\nB X\r\nA Y\r\nA Z\r\nB Y\r\nA X\r\nB Y\r\nA Y\r\nA X\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nA X\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nA X\r\nC Y\r\nA Y\r\nB Z\r\nC Y\r\nB Y\r\nA Y\r\nC Z\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nB Z\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nC Z\r\nB Y\r\nB Y\r\nA X\r\nB Y\r\nC Y\r\nA Y\r\nB Y\r\nA X\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nC X\r\nC X\r\nB Y\r\nC Y\r\nB Y\r\nA Y\r\nA X\r\nB Z\r\nB Y\r\nC Y\r\nA Y\r\nC X\r\nB Y\r\nC Z\r\nB Y\r\nA Y\r\nB Y\r\nA X\r\nA X\r\nA Y\r\nB Y\r\nA Y\r\nA X\r\nC Y\r\nC Y\r\nC X\r\nA X\r\nA X\r\nA Z\r\nC Y\r\nA Y\r\nA X\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nC X\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nA Y\r\nA X\r\nC X\r\nA Y\r\nC X\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nA X\r\nC Y\r\nA X\r\nB Y\r\nA X\r\nB X\r\nA X\r\nB X\r\nC Y\r\nB X\r\nB Y\r\nB Y\r\nA X\r\nA Z\r\nC Z\r\nB Y\r\nC X\r\nA Y\r\nC Y\r\nA Y\r\nB Y\r\nC X\r\nB Y\r\nC Y\r\nC Y\r\nB Y\r\nA X\r\nB X\r\nC Z\r\nC X\r\nA X\r\nC Y\r\nB Y\r\nA X\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nB Y\r\nB Z\r\nA Y\r\nA X\r\nC X\r\nB Y\r\nB Y\r\nC X\r\nA Y\r\nA Y\r\nB Y\r\nA X\r\nB Y\r\nB Y\r\nC X\r\nA Y\r\nB Y\r\nB Z\r\nC Y\r\nA X\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nB Y\r\nB X\r\nA Z\r\nB Z\r\nA Z\r\nA Y\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nC Y\r\nA Y\r\nC X\r\nA Y\r\nC X\r\nB Y\r\nB X\r\nC Y\r\nC X\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nC Y\r\nA Z\r\nA Y\r\nB Z\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nC X\r\nA X\r\nA Y\r\nC Y\r\nA Y\r\nC Y\r\nA X\r\nA X\r\nC Y\r\nB Z\r\nA X\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nA Y\r\nB Y\r\nB X\r\nA Y\r\nC X\r\nB Y\r\nC X\r\nC Y\r\nC Z\r\nC Y\r\nA X\r\nC Y\r\nA Y\r\nC Y\r\nC X\r\nA Y\r\nA Z\r\nA X\r\nA X\r\nA X\r\nB Y\r\nA Y\r\nC Y\r\nC Y\r\nC X\r\nA Y\r\nB Y\r\nA Y\r\nA X\r\nC X\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nC Y\r\nC X\r\nB Y\r\nC X\r\nB X\r\nA X\r\nC Y\r\nB X\r\nC Z\r\nB Z\r\nB Y\r\nA Y\r\nB Y\r\nB X\r\nC X\r\nC X\r\nB Y\r\nC Y\r\nC Y\r\nA X\r\nA X\r\nC Y\r\nA X\r\nA Y\r\nA Y\r\nA Y\r\nC Y\r\nA Z\r\nC X\r\nC X\r\nB Y\r\nB Y\r\nA Z\r\nB Y\r\nA Y\r\nA Y\r\nA Y\r\nC Y\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nC X\r\nA Y\r\nA Y\r\nC Y\r\nA X\r\nC Y\r\nB Y\r\nA Y\r\nC X\r\nC X\r\nB Y\r\nA Y\r\nA Y\r\nC Y\r\nC Z\r\nA X\r\nC Z\r\nB Y\r\nB Y\r\nB Y\r\nC X\r\nA Y\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nA Y\r\nB Y\r\nA Z\r\nA Y\r\nA X\r\nA Y\r\nA X\r\nA Y\r\nA X\r\nA Y\r\nA Y\r\nC Y\r\nA Y\r\nA Y\r\nB Z\r\nA Y\r\nA Y\r\nC Y\r\nB X\r\nC Y\r\nA Y\r\nC X\r\nC Y\r\nA Y\r\nC Y\r\nB Y\r\nA X\r\nA Y\r\nA X\r\nA Y\r\nB Y\r\nC X\r\nC Y\r\nC X\r\nC X\r\nA Y\r\nC Y\r\nA Y\r\nB Y\r\nC X\r\nC X\r\nA Y\r\nC Y\r\nB X\r\nC X\r\nB Y\r\nC X\r\nA Y\r\nC Y\r\nA X\r\nB X\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nA X\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nC Y\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nB Z\r\nA Y\r\nA X\r\nC Y\r\nB Y\r\nC Y\r\nC X\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nB Z\r\nA X\r\nB X\r\nB Y\r\nA X\r\nB Z\r\nA X\r\nA X\r\nB Y\r\nB X\r\nC X\r\nA Y\r\nA Y\r\nB Y\r\nB Z\r\nA Y\r\nB X\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nB Z\r\nC Y\r\nB Y\r\nA X\r\nC X\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nC X\r\nC Y\r\nC Z\r\nB Y\r\nB Y\r\nA Y\r\nC Y\r\nA X\r\nC X\r\nA X\r\nC X\r\nC Y\r\nB Y\r\nA Z\r\nA Y\r\nA X\r\nC Y\r\nA X\r\nC X\r\nA Y\r\nB Y\r\nC Z\r\nB Y\r\nC Z\r\nB Y\r\nB Y\r\nA Y\r\nA Z\r\nB Z\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nA Z\r\nB Y\r\nB Z\r\nB Y\r\nB Z\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nB Z\r\nB Y\r\nA Y\r\nB Y\r\nC X\r\nB Y\r\nC X\r\nA Y\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nB Z\r\nA Y\r\nA Y\r\nB Y\r\nC X\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nA X\r\nB Z\r\nA Y\r\nA X\r\nA X\r\nA Z\r\nA Z\r\nA Y\r\nC Y\r\nA Z\r\nA Y\r\nC Y\r\nA Y\r\nB Z\r\nC X\r\nC Y\r\nC Y\r\nB Y\r\nC X\r\nC X\r\nA Y\r\nC Y\r\nB X\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nB X\r\nC Y\r\nC Y\r\nA X\r\nA Y\r\nB Z\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nB Y\r\nB Z\r\nA X\r\nC Y\r\nA Y\r\nA X\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nB Y\r\nC X\r\nC Y\r\nA X\r\nB X\r\nC Y\r\nB Y\r\nC X\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nB Z\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nA X\r\nB X\r\nA Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nA Y\r\nA Y\r\nB X\r\nC X\r\nA Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nA Y\r\nC Y\r\nA X\r\nB Y\r\nA Y\r\nC Y\r\nA X\r\nA Y\r\nA Y\r\nC Y\r\nA Y\r\nB Y\r\nA X\r\nA Y\r\nB Y\r\nA X\r\nC X\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nC X\r\nB Y\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nB Z\r\nA Y\r\nB Z\r\nA X\r\nA Y\r\nA Y\r\nA X\r\nC Y\r\nA X\r\nA X\r\nC Y\r\nA X\r\nA X\r\nA Y\r\nC Y\r\nA Y\r\nB Y\r\nA X\r\nC Z\r\nA Y\r\nB X\r\nA Y\r\nB Y\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nB X\r\nC Y\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nA Y\r\nA Y\r\nC X\r\nA X\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nB Y\r\nB Z\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nB Y\r\nA X\r\nB Y\r\nC Y\r\nB Y\r\nA Y\r\nC Y\r\nC Y\r\nC X\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nC Z\r\nC X\r\nB Y\r\nA Y\r\nA X\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nB Y\r\nC Y\r\nC X\r\nA X\r\nC Y\r\nA Y\r\nA X\r\nA X\r\nA X\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nC Y\r\nC Z\r\nA X\r\nC Y\r\nC X\r\nB Z\r\nC Y\r\nA Y\r\nA X\r\nC X\r\nA Y\r\nC Z\r\nA Y\r\nC X\r\nB Y\r\nA Y\r\nC X\r\nA X\r\nB Y\r\nB Y\r\nA X\r\nC Y\r\nB Y\r\nC X\r\nC X\r\nB Y\r\nA Y\r\nC X\r\nC Z\r\nC X\r\nC X\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nA X\r\nB Y\r\nC Y\r\nA X\r\nC X\r\nC Y\r\nB X\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nB Y\r\nB Y\r\nB Y\r\nB Z\r\nB X\r\nC Y\r\nA X\r\nA Y\r\nA Y\r\nC Y\r\nA Y\r\nA X\r\nC X\r\nA Y\r\nA Y\r\nC X\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nC X\r\nA X\r\nC Y\r\nC Y\r\nB Z\r\nA Y\r\nC Z\r\nA X\r\nA X\r\nB Y\r\nA X\r\nA Y\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nA Y\r\nA X\r\nC Y\r\nC Y\r\nC Y\r\nA X\r\nC Y\r\nA Y\r\nA Z\r\nA X\r\nC Z\r\nC Y\r\nC X\r\nB Y\r\nC Y\r\nB Y\r\nC Y\r\nA Y\r\nC X\r\nB Y\r\nC Y\r\nC X\r\nA Y\r\nB Y\r\nC X\r\nC Y\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nA X\r\nB Y\r\nA Y\r\nC Y\r\nB X\r\nC Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nA X\r\nC Y\r\nA X\r\nA Y\r\nA Y\r\nB Z\r\nC X\r\nB Y\r\nB Y\r\nA X\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nA X\r\nB Z\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nA X\r\nA Y\r\nA Y\r\nC X\r\nC X\r\nA X\r\nB Y\r\nC X\r\nC Z\r\nC Y\r\nB Y\r\nC Z\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nC X\r\nA Z\r\nA X\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nA X\r\nA Y\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nA X\r\nA X\r\nC Y\r\nC X\r\nC Z\r\nA Y\r\nA Y\r\nA Y\r\nC Y\r\nC X\r\nB Y\r\nC Y\r\nA X\r\nB Y\r\nC Y\r\nA Y\r\nA X\r\nB Y\r\nC Y\r\nA Y\r\nB Y\r\nC X\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nA X\r\nB Z\r\nA X\r\nA Y\r\nC Y\r\nC Y\r\nA Y\r\nA Y\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nA X\r\nA Y\r\nC X\r\nC X\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nC X\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nC Y\r\nB Y\r\nC X\r\nC Y\r\nA Y\r\nA Y\r\nC Y\r\nB Y\r\nB X\r\nC Y\r\nC Y\r\nB Y\r\nB X\r\nA Y\r\nB X\r\nA X\r\nB Y\r\nC X\r\nA X\r\nB Y\r\nA Y\r\nA Y\r\nA Y\r\nC Y\r\nB X\r\nA Y\r\nB Y\r\nA Y\r\nA X\r\nC Z\r\nB Y\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nB Y\r\nC Y\r\nA X\r\nA Y\r\nC Y\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nB Y\r\nB Y\r\nA X\r\nA X\r\nC Y\r\nC Y\r\nB X\r\nC Z\r\nC Y\r\nA X\r\nA Y\r\nB Y\r\nA Y\r\nC Y\r\nC X\r\nB Y\r\nB Z\r\nC Y\r\nA X\r\nA Y\r\nA X\r\nB Y\r\nB X\r\nB Y\r\nB X\r\nC Y\r\nA Z\r\nB Y\r\nC Y\r\nA Y\r\nA X\r\nC Y\r\nC X\r\nB Y\r\nA Y\r\nA Y\r\nA X\r\nC X\r\nA Y\r\nC X\r\nA Y\r\nC Y\r\nC X\r\nA X\r\nC Z\r\nB Y\r\nA X\r\nB Y\r\nA Y\r\nA X\r\nA X\r\nA Y\r\nA Y\r\nA Y\r\nC X\r\nC X\r\nA Y\r\nA Y\r\nB Y\r\nC Y\r\nC Y\r\nB Y\r\nC Y\r\nA Y\r\nC Y\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nB Y\r\nC X\r\nB X\r\nA X\r\nA X\r\nB Y\r\nB Y\r\nB Y\r\nC Z\r\nC Y\r\nB X\r\nA X\r\nB Y\r\nA X\r\nB Y\r\nA Y\r\nB Y\r\nC Y\r\nA Y\r\nA Y\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nB Y\r\nA Y\r\nC Y\r\nC Y\r\nB X\r\nB Y\r\nB Y\r\nA Y\r\nB X\r\nA Y\r\nB Y\r\nC Z\r\nB Z\r\nB Y\r\nC Y\r\nB Z\r\nC Y\r\nC Y\r\nB Z\r\nA Y\r\nA Y\r\nA Y\r\nC Z\r\nB Y\r\nA Y\r\nA Y\r\nC Z\r\nA Y\r\nA Y\r\nA Y\r\nB Y\r\nC X\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nA Z\r\nC Y\r\nA X\r\nA Y\r\nA Y\r\nA Y\r\nB Y\r\nB Y\r\nA X\r\nB Y\r\nA Y\r\nA Z\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nA Y\r\nC Y\r\nB Y\r\nC X\r\nB Y\r\nC Y\r\nC X\r\nB Y\r\nA Y\r\nB Y\r\nA Y\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nA Y\r\nB Y\r\nB Y\r\nB Y\r\nA X\r\nC Y\r\nA Y\r\nB Y\r\nB X\r\nA Y\r\nC X\r\nB Y\r\nA X\r\nA Y\r\nA Y\r\nC Z\r\nC Y\r\nB Y\r\nC Y\r\nB Z\r\nA X\r\nB Y\r\nC Y\r\nB Y\r\nA Y\r\nA Y\r\nC Y\r\nA Y\r\nC Y\r\nA Y\r\nC Y\r\nA X\r\nA X\r\nA Y\r\nB Y\r\nB Y\r\nB X\r\nA X\r\nA Y\r\nA Y\r\nA X\r\nA Y\r\nC Y\r\nC Y\r\nB Y\r\nA X\r\nC Y\r\nA Y\r\nC X\r\nB Y\r\nA Y\r\nC Y\r\nC X\r\nA Y\r\nC Y\r\nB Y\r\nB Y\r\nA X\r\nA Y\r\nC Y\r\nA X\r\nA X\r\nB Y\r\nB Y\r\nA Y\r\nA X\r\nA Y\r\nB Y\r\nA X\r\nB Y\r\nA X\r\nA X\r\nC Z\r\nC Z\r\nB Y\r\nA X\r\nB Y\r\nA Y\r\nB Y\r\nB Z\r\nA Y\r\nA X\r\nC Y\r\nC Y\r\nC Z\r\nC Y\r\nC Z\r\nA X\r\nA Y\r\nC Y\r\nC Y\r\nC Y\r\nA Y\r\nB Y\r\nA Y\r\nA Y\r\nB Y\r\nC Y\r\nB Z\r\nA Y\r\nC Y";
            //string input = "A Y\r\nB X\r\nC Z";
            List<string> inputPerLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            List<string[]> rounds = new List<string[]>();
            for (int i = 0; i < inputPerLine.Count; i++)
            {
                string roundString = inputPerLine[i];
                string[] round = roundString.Split(' ');
                round[0] = dictColumnA[round[0]];
                round[1] = dictColumnB[round[1]];
                rounds.Add(round);
            }

            long score = 0;
            foreach (string[] round in rounds)
            {
                //Console.WriteLine("Elf plays {0}, you play {1}, results in a score of {2}", round[0], round[1], roundToScore(round));
                score += roundToScore(round);
            }
            Console.WriteLine("If you follow your first guess, you will get {0} points in {1} rounds, an average of {2}.", score, rounds.Count, (float)score / rounds.Count);

            score = 0;
            foreach (string[] round in rounds)
            {
                string elfPlays = round[0];
                string myPlay = round[1];
                if (myPlay == "Rock")
                {
                    round[1] = beats[elfPlays];
                    //Console.WriteLine("Playing {0} to lose against the elf, who picked {1}...", round[1], elfPlays);

                }
                else if (myPlay == "Paper")
                {
                    round[1] = elfPlays;
                    //Console.WriteLine("Playing {0} to draw the elf, who picked {1}...", round[1], elfPlays);
                }
                else if (myPlay == "Scissors")
                {
                    round[1] = beatenBy[elfPlays];
                    //Console.WriteLine("Playing {0} to win against the elf, who picked {1}...", round[1], elfPlays);
                }
                //Console.WriteLine("Elf plays {0}, you play {1}, results in a score of {2}", round[0], round[1], roundToScore(round));
                score += roundToScore(round);
            }
            Console.WriteLine("If you follow the elf's plan, you will get {0} points in {1} rounds, an average of {2}.", score, rounds.Count, (float)score / rounds.Count);
        }
    }
}
