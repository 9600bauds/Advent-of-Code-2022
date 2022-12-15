using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day10
    {
        class Display
        {
            public int screenWidth;
            public List<String> screenLines = new List<string>();
            public String currentScreenLine = "";

            public Display(int screenWidth)
            {
                this.screenWidth = screenWidth;
            }

            public void Tick(int tick, int register)
            {
                int pixelBeingDrawn = tick % screenWidth - 1;
                //Console.WriteLine($"At tick {tick}, our register is {register}, pixel being drawn is {pixelBeingDrawn}, and their difference is {Math.Abs(pixelBeingDrawn - register)}");
                currentScreenLine += GetPixel(pixelBeingDrawn, register);
                if (pixelBeingDrawn == screenWidth - 2) //Why -2? I don't know.
                {
                    screenLines.Add(currentScreenLine);
                    currentScreenLine = "";
                }
                //Console.WriteLine($"Line being drawn is now {currentScreenLine}");
            }

            public char GetPixel(int pixelIndex, int register)
            {
                if (Math.Abs(register - pixelIndex) < 2) //We are within 1 pixel of the register address
                {
                    return '#';
                }
                else
                {
                    return '.';
                }
            }

            public override string ToString()
            {
                return String.Join("\r\n", screenLines);
            }
        }

        class Processor
        {
            public int register = 1;
            public int busy = 0; //In ticks, so busy = 2 would mean busy for the next 2 ticks.
            public int offset = 0; //By how much will the register be affected when we stop being busy?
            public int tick = 0;

            public void Tick(List<String> instructions)
            {
                tick++;
                if (busy > 0)
                {
                    busy--;
                    return;
                }

                register += offset;
                offset = 0;

                if (instructions.Count == 0)
                {
                    return;
                }

                String line = instructions[0];
                String[] lineSplit = line.Split(' ');
                String command = lineSplit[0];
                switch (command)
                {
                    case "noop":
                        break;
                    case "addx":
                        offset = int.Parse(lineSplit[1]);
                        busy++;
                        break;
                }
                instructions.RemoveAt(0); //delete instructions as we read them
            }
        }

        public static void Run()
        {
            //String input = "noop\r\naddx 3\r\naddx -5";
            //String input = "addx 15\r\naddx -11\r\naddx 6\r\naddx -3\r\naddx 5\r\naddx -1\r\naddx -8\r\naddx 13\r\naddx 4\r\nnoop\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx 5\r\naddx -1\r\naddx -35\r\naddx 1\r\naddx 24\r\naddx -19\r\naddx 1\r\naddx 16\r\naddx -11\r\nnoop\r\nnoop\r\naddx 21\r\naddx -15\r\nnoop\r\nnoop\r\naddx -3\r\naddx 9\r\naddx 1\r\naddx -3\r\naddx 8\r\naddx 1\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx -36\r\nnoop\r\naddx 1\r\naddx 7\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\naddx 6\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\nnoop\r\naddx 7\r\naddx 1\r\nnoop\r\naddx -13\r\naddx 13\r\naddx 7\r\nnoop\r\naddx 1\r\naddx -33\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\nnoop\r\nnoop\r\nnoop\r\naddx 8\r\nnoop\r\naddx -1\r\naddx 2\r\naddx 1\r\nnoop\r\naddx 17\r\naddx -9\r\naddx 1\r\naddx 1\r\naddx -3\r\naddx 11\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\naddx 1\r\nnoop\r\nnoop\r\naddx -13\r\naddx -19\r\naddx 1\r\naddx 3\r\naddx 26\r\naddx -30\r\naddx 12\r\naddx -1\r\naddx 3\r\naddx 1\r\nnoop\r\nnoop\r\nnoop\r\naddx -9\r\naddx 18\r\naddx 1\r\naddx 2\r\nnoop\r\nnoop\r\naddx 9\r\nnoop\r\nnoop\r\nnoop\r\naddx -1\r\naddx 2\r\naddx -37\r\naddx 1\r\naddx 3\r\nnoop\r\naddx 15\r\naddx -21\r\naddx 22\r\naddx -6\r\naddx 1\r\nnoop\r\naddx 2\r\naddx 1\r\nnoop\r\naddx -10\r\nnoop\r\nnoop\r\naddx 20\r\naddx 1\r\naddx 2\r\naddx 2\r\naddx -6\r\naddx -11\r\nnoop\r\nnoop\r\nnoop";
            String input = "noop\r\nnoop\r\nnoop\r\naddx 6\r\naddx -1\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\naddx 5\r\naddx 11\r\naddx -10\r\naddx 4\r\nnoop\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\naddx 1\r\nnoop\r\naddx 4\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\naddx -35\r\naddx -2\r\naddx 5\r\naddx 2\r\naddx 3\r\naddx -2\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx 3\r\naddx -2\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx 3\r\naddx -28\r\naddx 28\r\naddx 5\r\naddx 2\r\naddx -9\r\naddx 10\r\naddx -38\r\nnoop\r\naddx 3\r\naddx 2\r\naddx 7\r\nnoop\r\nnoop\r\naddx -9\r\naddx 10\r\naddx 4\r\naddx 2\r\naddx 3\r\nnoop\r\nnoop\r\naddx -2\r\naddx 7\r\nnoop\r\nnoop\r\nnoop\r\naddx 3\r\naddx 5\r\naddx 2\r\nnoop\r\nnoop\r\nnoop\r\naddx -35\r\nnoop\r\nnoop\r\nnoop\r\naddx 5\r\naddx 2\r\nnoop\r\naddx 3\r\nnoop\r\nnoop\r\nnoop\r\naddx 5\r\naddx 3\r\naddx -2\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx -25\r\nnoop\r\naddx 30\r\nnoop\r\naddx 1\r\nnoop\r\naddx 2\r\nnoop\r\naddx 3\r\naddx -38\r\nnoop\r\naddx 7\r\naddx -2\r\naddx 5\r\naddx 2\r\naddx -8\r\naddx 13\r\naddx -2\r\nnoop\r\naddx 3\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx -15\r\nnoop\r\naddx 20\r\naddx 3\r\nnoop\r\naddx 2\r\naddx -4\r\naddx 5\r\naddx -38\r\naddx 8\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\naddx 2\r\naddx 17\r\naddx -10\r\naddx 3\r\nnoop\r\naddx 2\r\naddx 1\r\naddx -16\r\naddx 19\r\naddx 2\r\nnoop\r\naddx 2\r\naddx 5\r\naddx 2\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop\r\nnoop";
            List<String> instructions = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            Processor processor = new Processor();
            Display display = new Display(40);

            int sumOfSignalStrengths = 0;
            List<int> interestingTicks = new List<int> { 20, 60, 100, 140, 180, 220 };

            while(true)
            {
                //Console.WriteLine($"At tick {tick}, our register is {register}, we're busy for {busy} ticks and our pending offset is {offset}.");
                if (interestingTicks.Contains(processor.tick))
                {
                    int signalStrength = processor.tick * processor.register;
                    Console.WriteLine($"At tick {processor.tick}, our register is {processor.register}, we're busy for {processor.busy} ticks and our pending offset is {processor.offset}. Signal strength is: {signalStrength}");
                    sumOfSignalStrengths += signalStrength;
                }

                display.Tick(processor.tick, processor.register);

                processor.Tick(instructions);

                if (instructions.Count == 0) //processor deletes instructions from the list as it executes them, thus if the list is empty, there is nothing to be done
                {
                    Console.WriteLine($"Done! Sum of signal strengths: {sumOfSignalStrengths}");
                    Console.WriteLine($"Final drawing:");
                    Console.WriteLine(display.ToString());
                    return;
                }
            }
        }
    }
}
