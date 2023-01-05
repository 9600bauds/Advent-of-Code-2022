using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Advent_of_Code_2022.libs
{
    internal class Utils
    {
        /// <summary>
        /// Dividing 2 ints normally rounds down (17 / 3 = 5). This makes it round up (17 / 3 = 6) without needing to cast anything, so it's simple and cheap.
        /// </summary>
        /// <param name="int1">Integer A</param>
        /// <param name="int2">Integer B</param>
        /// <returns>A/B, rounded up</returns>
        public static int DivideIntsAndRoundUp(int int1, int int2)
        {
            return (int1 - 1) / int2 + 1;
        }

        /// <summary>
        /// For whatever god-forsaken reason, % is "remainder" and not "modulo" in C, so -2 % 6 = -2. This is effectively REAL modulo.
        /// </summary>
        /// <param name="num">Dividend</param>
        /// <param name="mod">Divisor</param>
        /// <returns>Remainder (aka the '%' operator in just about every other programming language)</returns>
        public static int RealModulo(int num, int mod)
        {
            num %= mod;
            if (num < 0)
            {
                num += mod;
            }
            return num;
        }

        /// <summary>
        /// Splits a multi-line string into an array of lines, using linebreaks. Effectively line.Split() with "\r\n".
        /// </summary>
        /// <param name="input">Multiline string</param>
        /// <returns>Array of lines, divided by linebreaks</returns>
        public static string[] SplitLines(string input)
        {
            return input.Split(new[] { "\r\n" }, StringSplitOptions.None); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.
        }

        /// <summary>
        /// Splits a multi-line string into an array of lines, using blank lines. Effectively line.Split() with "\r\n\r\n".
        /// </summary>
        /// <param name="input">Multiline string with blank lines</param>
        /// <returns>Array of lines, divided by blank lines</returns>
        public static string[] SplitBlankLines(string input)
        {
            return input.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.
        }

        public static int ManhattanDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        public static int GaussSummation(int num)
        {
            return (num * (num + 1)) / 2; //1 + 2 + 3 + 4 + ... + n-2 + n-1 + n. Basically the story of how Kid Gauss quickly worked out the sum of the numbers from 1 to 100 was 5050.
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
