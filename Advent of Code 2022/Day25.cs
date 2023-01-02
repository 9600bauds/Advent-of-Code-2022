using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2022
{

    internal class Day25
    {
        //https://adventofcode.com/2022/day/25
        //const string input = "1=-0-2\r\n12111\r\n2=0=\r\n21\r\n2=01\r\n111\r\n20012\r\n112\r\n1=-1=\r\n1-12\r\n12\r\n1=\r\n122";
        const string input = "11-00\r\n2--2==212=12\r\n1=0110121=2\r\n1=012-21-=121\r\n1==0-1121-=200=2212\r\n1=1210===00=\r\n11210021-0001010-\r\n12=1-10-1-\r\n212-2==221-210-21\r\n1=-01=0-02-2-=-222=\r\n1=022000===-22010\r\n1=01=12202\r\n11=\r\n202-1\r\n2-12-2=--1\r\n10-=-00=101=-0-=-0\r\n1112-1\r\n2--1201\r\n1=1==-020=1-\r\n1--0-=2-0022-\r\n1=-1-21-200-102=\r\n11=100021210\r\n1=2=01=2-=01-=\r\n1=0120-11-0-=-2=-2\r\n1=-20221=2=-2=\r\n1-0\r\n1=00=-=11100--=2\r\n22122\r\n1=102222\r\n1210=1=001-=000\r\n1--200102022-=\r\n102=12=-1==\r\n100=\r\n20-02\r\n10\r\n10==-102\r\n11=020-0210-1-2012=\r\n12-11=0-1-=\r\n20=-\r\n212=1-1-10\r\n1=20=1-=2-11=0\r\n1=22\r\n120=2202=12200\r\n1-0-1\r\n211011-11=\r\n2=120=--==0==--0-0\r\n110-0-=-10-1-112\r\n1=2=1-=1-2\r\n1=12==10\r\n10=2110\r\n22222-1=01-1\r\n111-=2=22-==-00\r\n10===2-2=21100-1=\r\n100-21-0-1=021\r\n2-21=0\r\n1===002012=2=-1121\r\n122222-101=1-==2-2=\r\n112=0\r\n2--212=0\r\n110--2-0022--01=-\r\n1-0-0=0-1011-2-=0--2\r\n1=--0-2=1\r\n2=\r\n1=1\r\n1022=1--2---120\r\n2-1=2-22--21=1-212\r\n22=-11-0=-1\r\n2==210022=\r\n11=000=002-2002-1=\r\n2-2=02=0\r\n1=00-=----=\r\n1=121-2\r\n12-2=2-=2=2022\r\n2=110=1=2=02\r\n2\r\n1=0--02-121\r\n1200-2000=0\r\n1==--021--2=-\r\n12-1=22=-02--2-\r\n1=1=1--121-1221\r\n2-0212=\r\n21-==0-201-\r\n20212=1\r\n111--\r\n22-2=-1\r\n112\r\n2=2-==101\r\n1-=1\r\n12211=010=-=10--\r\n2211\r\n21-110-1-22==-10\r\n121-1-\r\n22000=-=2-0=012\r\n212-02\r\n102\r\n2-110=11=--\r\n11=11===0\r\n1=210-0120\r\n1=--1011\r\n2=00022==21-1=-2\r\n21=1-==2---2=0-2\r\n1220-11=022122\r\n21210=01\r\n1==1-2\r\n2=2\r\n11-11122=-\r\n200-0=21202-=\r\n2=-11\r\n2==2=0=1120221\r\n101010\r\n1=2=-=--=-2-0=\r\n111=0=--\r\n1=0121-=2\r\n1==1=1\r\n2-0222=2=-\r\n12=\r\n10-=0-2";

        public static Dictionary<char, int> char2Dec = new() { { '2', 2 }, { '1', 1 }, { '0', 0 }, { '-', -1 }, { '=', -2 } };
        public static Dictionary<int, char> dec2Char = char2Dec.ToDictionary(x => x.Value, x => x.Key);
        public static void Run()
        {
            List<string> inputPerLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            long sum = 0;
            foreach (string line in inputPerLine)
            {
                sum += Snafu2Dec(line);

            }
            Console.WriteLine($"The sum of fuel requirements is {sum}. That's {Dec2Snafu(sum)} in SNAFU.");
        }

        public static long Snafu2Dec(string input)
        {
            long output = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char currDigit = input[input.Length - i - 1];
                long digit2Dec = char2Dec[currDigit];
                output += digit2Dec * (long)Math.Pow(5, i);
            }
            return output;
        }

        public static string Dec2Snafu(long input)
        {
            string output = "";
            int pow = 0;
            while (input > 0)
            {
                long currPow = (long)Math.Pow(5, pow);
                long nextPow = (long)Math.Pow(5, pow + 1);
                pow++;

                long tmp = input % nextPow;
                if (tmp == 0)
                {
                    output = dec2Char[0] + output;
                }
                else if (tmp <= currPow * 2)
                {
                    output = dec2Char[(int)(tmp / currPow)] + output;
                    input -= tmp;
                }
                else if (tmp < nextPow) //Should always be true
                {
                    long times = (nextPow - tmp) / currPow;
                    output = dec2Char[(int)times * -1] + output;
                    input += currPow * times;
                }
                else
                {
                    throw new Exception($"Failed to parse dec2snafu for number: {input}");
                }
            }
            return output;
        }
    }
}
