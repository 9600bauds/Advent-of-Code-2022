﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Advent_of_Code_2022.libs
{
    internal class Utils
    {
        //Dividing 2 ints normally rounds down (17 / 3 = 5)
        //This makes it round up (17 / 3 = 6) without needing to cast anything, so it's simple and cheap
        public static int DivideIntsAndRoundUp(int int1, int int2)
        {
            return (int1 - 1) / int2 + 1;
        }

        //For whatever god-forsaken reason, % is "remainder" and not "modulo" in C, so -2 % 6 = -2. This is effectively REAL modulo.
        public static int RealModulo(int num, int mod)
        {
            num %= mod;
            if (num < 0)
            {
                num += mod;
            }
            return num;
        }

        public static int ManhattanDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        public static int GaussSummation(int num)
        {
            return (num * (num + 1)) / 2; //1 + 2 + 3 + 4 + ... + n-2 + n-1 + n. Basically the story of how Gauss quickly worked out the sum of the numbers from 1 to 100 was 5050.
        }

        public static void WriteProgress(string s, int x)
        {
            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;
            // Console.WindowWidth = 10;  // this works. 
            int width = Console.WindowWidth;
            x = x % width;
            try
            {
                Console.SetCursorPosition(x, 1);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            finally
            {
                try
                {
                    Console.SetCursorPosition(origCol, origRow);
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }
        }

        public static void PrintList<T>(List<T> list)
        {
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
