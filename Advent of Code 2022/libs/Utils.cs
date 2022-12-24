using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static int RealModulo(int num, int mod)
        {
            num %= mod;
            if(num < 0)
            {
                num += mod;
            }
            return num;
        }

        public static void PrintList<T>(List<T> list)
        {
            Console.WriteLine(String.Join(", ", list));
        }
    }
}
