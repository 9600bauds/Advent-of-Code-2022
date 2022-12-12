using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day11
    {
        class Monkey //turns out
        {
            public List<long> items = new List<long>();
            public List<String> itemHistory = new List<string>();
            public String operation;
            public String test;
            public int preferredMonkey; //Monkey that they will chuck at if the test is successful
            public int secondaryMonkey; //Monkey that they will chuck at if the test is unsuccessful
            //public int boredomMultiplier = 3;
            public int boredomMultiplier = 1;
            public int activity; //Increased by 1 when we do something

            public long PerformOperation(long item, bool verbose)
            {
                String[] operationSplit = operation.Split(' ');
                String sign = operationSplit[1];
                String operandString = operationSplit[2];
                long operand;
                if (operandString == "old")
                {
                    operand = item;
                }
                else
                {
                    operand = long.Parse(operandString);
                }
                if (sign == "*")
                {
                    item *= operand;
                    if (verbose)
                    {
                        Console.WriteLine($"    Worry level is multiplied by {operand} to {item}.");
                    }
                }
                else if (sign == "+")
                {
                    item += operand;
                    if (verbose)
                    {
                        Console.WriteLine($"    Worry level increases by {operand} to {item}.");
                    }
                }
                else
                {
                    Debug.Fail($"Operation not recognized! ({operation})");
                }

                if (boredomMultiplier != 1) {
                    item /= boredomMultiplier;
                    if (verbose)
                    {
                        Console.WriteLine($"    Monkey gets bored with item. Worry level is divided by {boredomMultiplier} to {item}.");
                    }
                }
                else if(item > lowestCommonDenominator)
                {
                    item %= lowestCommonDenominator;
                    if (verbose)
                    {
                        Console.WriteLine($"    Item is getting too big! Applying modulo by {lowestCommonDenominator}... {item}.");
                    }
                }
                return item;
            }

            public bool TestPassed(long item, bool verbose)
            {
                String[] testSplit = test.Split(' ');
                String operation = testSplit[0];
                int operand = int.Parse(testSplit[2]);
                bool success = false;
                if (operation == "divisible")
                {
                    success = item % operand == 0;
                    if (verbose)
                    {
                        if (success)
                        {
                            Console.WriteLine($"    Current worry level is divisible by {operand}.");
                        }
                        else
                        {
                            Console.WriteLine($"    Current worry level is not divisible by {operand}.");
                        }
                    }
                }
                else
                {
                    Debug.Fail($"Test not recognized! ({test})");
                }
                return success;
            }

            public void ThrowItem(int itemIndex, int monkeyIndex, bool verbose = false)
            {
                long item = items[itemIndex];
                items.RemoveAt(itemIndex);

                Monkey recipient = monkeys[monkeyIndex];
                recipient.items.Add(item);

                recipient.itemHistory.Add(itemHistory[itemIndex]);
                itemHistory.RemoveAt(itemIndex);

                if (verbose)
                {
                    Console.WriteLine($"    Item with worry level {item} is thrown to monkey {monkeyIndex}.");
                }
            }

            public void TakeTurn(int index, bool verbose = false)
            {
                if (verbose)
                {
                    Console.WriteLine($"Monkey {index}:");
                }
                for (int i = 0; i < items.Count; i++)
                {
                    long item = items[i];

                    if (verbose)
                    {
                        Console.WriteLine($"  Monkey inspects an item with a worry level of {item}.");
                    }
                    item = PerformOperation(item, verbose);
                    items[i] = item;

                    itemHistory[i] += $"{operation.Split(' ')[1]}{operation.Split(' ')[2]}";

                    
                    bool success = TestPassed(item, verbose);
                    
                    int recipient;
                    if (success)
                    {
                        recipient = preferredMonkey;
                    }
                    else
                    {
                        recipient = secondaryMonkey;
                    }
                    ThrowItem(i, recipient, verbose);
                    i--; //Remember: We did just throw an item, so we need to reduce our index or we'll skip over the next one!
                    activity++;
                }
            }
        }

        static List<Monkey> monkeys = new List<Monkey>();
        //static int roundsToSimulate = 20;
        static int roundsToSimulate = 10000;
        static int monkeysICanChase = 2;
        static int lowestCommonDenominator = 1;

        static Regex newMonkeyRegex = new Regex(@"Monkey (?<newMonkey>\d+):");
        static Regex startingItemsRegex = new Regex(@"Starting items: (?<startingItems>[0-9 ,]+)");
        static Regex operationRegex = new Regex(@"Operation: new = (?<operation>.+)");
        static Regex testRegex = new Regex(@"Test: (?<test>.+)");
        static Regex preferredMonkeyRegex = new Regex(@"If true: throw to monkey (?<monkey>.+)");
        static Regex secondaryMonkeyRegex = new Regex(@"If false: throw to monkey (?<monkey>.+)");

        public static void DisplayMonkeys()
        {
            for (int monkeyIndex = 0; monkeyIndex < monkeys.Count; monkeyIndex++)
            {
                Monkey monkey = monkeys[monkeyIndex];
                Console.WriteLine($"Monkey {monkeyIndex}: {String.Join(", ", monkey.items)}");
            }
        }
        public static void DisplayHistory()
        {
            for (int monkeyIndex = 0; monkeyIndex < monkeys.Count; monkeyIndex++)
            {
                Monkey monkey = monkeys[monkeyIndex];
                Console.WriteLine($"Monkey {monkeyIndex}: {String.Join(", ", monkey.itemHistory)}");
            }
        }

        public static void Run()
        {
            //String input = "Monkey 0:\r\n  Starting items: 79, 98\r\n  Operation: new = old * 19\r\n  Test: divisible by 23\r\n    If true: throw to monkey 2\r\n    If false: throw to monkey 3\r\n\r\nMonkey 1:\r\n  Starting items: 54, 65, 75, 74\r\n  Operation: new = old + 6\r\n  Test: divisible by 19\r\n    If true: throw to monkey 2\r\n    If false: throw to monkey 0\r\n\r\nMonkey 2:\r\n  Starting items: 79, 60, 97\r\n  Operation: new = old * old\r\n  Test: divisible by 13\r\n    If true: throw to monkey 1\r\n    If false: throw to monkey 3\r\n\r\nMonkey 3:\r\n  Starting items: 74\r\n  Operation: new = old + 3\r\n  Test: divisible by 17\r\n    If true: throw to monkey 0\r\n    If false: throw to monkey 1";
            String input = "Monkey 0:\r\n  Starting items: 93, 98\r\n  Operation: new = old * 17\r\n  Test: divisible by 19\r\n    If true: throw to monkey 5\r\n    If false: throw to monkey 3\r\n\r\nMonkey 1:\r\n  Starting items: 95, 72, 98, 82, 86\r\n  Operation: new = old + 5\r\n  Test: divisible by 13\r\n    If true: throw to monkey 7\r\n    If false: throw to monkey 6\r\n\r\nMonkey 2:\r\n  Starting items: 85, 62, 82, 86, 70, 65, 83, 76\r\n  Operation: new = old + 8\r\n  Test: divisible by 5\r\n    If true: throw to monkey 3\r\n    If false: throw to monkey 0\r\n\r\nMonkey 3:\r\n  Starting items: 86, 70, 71, 56\r\n  Operation: new = old + 1\r\n  Test: divisible by 7\r\n    If true: throw to monkey 4\r\n    If false: throw to monkey 5\r\n\r\nMonkey 4:\r\n  Starting items: 77, 71, 86, 52, 81, 67\r\n  Operation: new = old + 4\r\n  Test: divisible by 17\r\n    If true: throw to monkey 1\r\n    If false: throw to monkey 6\r\n\r\nMonkey 5:\r\n  Starting items: 89, 87, 60, 78, 54, 77, 98\r\n  Operation: new = old * 7\r\n  Test: divisible by 2\r\n    If true: throw to monkey 1\r\n    If false: throw to monkey 4\r\n\r\nMonkey 6:\r\n  Starting items: 69, 65, 63\r\n  Operation: new = old + 6\r\n  Test: divisible by 3\r\n    If true: throw to monkey 7\r\n    If false: throw to monkey 2\r\n\r\nMonkey 7:\r\n  Starting items: 89\r\n  Operation: new = old * old\r\n  Test: divisible by 11\r\n    If true: throw to monkey 0\r\n    If false: throw to monkey 2";
            List<String> inputByLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.

            Monkey currentMonkey = null;
            foreach (String line in inputByLine)
            {
                Match match;
                match = newMonkeyRegex.Match(line);
                if (match.Success)
                {
                    if(currentMonkey != null)
                    {
                        monkeys.Add(currentMonkey);
                    }
                    currentMonkey = new Monkey();
                    continue;
                }
                match = startingItemsRegex.Match(line);
                if (match.Success)
                {
                    String startingItemsString = match.Groups["startingItems"].Value;
                    String[] startingItemsArray = startingItemsString.Split(new[] { ", " }, StringSplitOptions.None);
                    foreach(String startingItem in startingItemsArray)
                    {
                        currentMonkey.items.Add(int.Parse(startingItem));
                        currentMonkey.itemHistory.Add(startingItem);
                    }
                    continue;
                }
                match = operationRegex.Match(line);
                if (match.Success)
                {
                    String operation = match.Groups["operation"].Value;
                    currentMonkey.operation = operation;
                    continue;
                }
                match = testRegex.Match(line);
                if (match.Success)
                {
                    String test = match.Groups["test"].Value;
                    currentMonkey.test = test;
                    continue;
                }
                match = preferredMonkeyRegex.Match(line);
                if (match.Success)
                {
                    int monkeyIndex = int.Parse(match.Groups["monkey"].Value);
                    currentMonkey.preferredMonkey = monkeyIndex;
                    continue;
                }
                match = secondaryMonkeyRegex.Match(line);
                if (match.Success)
                {
                    int monkeyIndex = int.Parse(match.Groups["monkey"].Value);
                    currentMonkey.secondaryMonkey = monkeyIndex;
                    continue;
                }
            }
            monkeys.Add(currentMonkey); //Finish loading the last monkey
            foreach(Monkey monkey in monkeys)
            {
                lowestCommonDenominator *= int.Parse(monkey.test.Split(' ')[2]);
            }
            Console.WriteLine($"Loaded {monkeys.Count} monkeys. LCD is {lowestCommonDenominator}");

            int verbosity = 0;
            List<int> interestingRounds = new List<int> { 1, 20, 100, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };
            for (int round = 1; round <= roundsToSimulate; round++)
            {
                if (verbosity > 0)
                {
                    Console.WriteLine($" == ROUND {round} == ");
                }
                for(int monkeyIndex = 0; monkeyIndex < monkeys.Count; monkeyIndex++)
                {
                    Monkey monkey = monkeys[monkeyIndex];
                    monkey.TakeTurn(monkeyIndex, verbosity > 1);
                }
                if (verbosity > 0)
                {
                    Console.WriteLine($"After round {round}, the monkeys are holding items with these worry levels:");
                    DisplayMonkeys();
                    //DisplayHistory();
                }
                else if(verbosity == 0)
                {
                    if (interestingRounds.Contains(round))
                    {
                        Console.WriteLine($" == After round {round} ==");
                        //DisplayMonkeys();
                        for (int monkeyIndex = 0; monkeyIndex < monkeys.Count; monkeyIndex++)
                        {
                            Monkey monkey = monkeys[monkeyIndex];
                            Console.WriteLine($"Monkey {monkeyIndex} inspected items {monkey.activity} times.");
                        }
                    }
                }
            }

            Console.WriteLine($" == All done! ==");
            DisplayHistory();

            List<Monkey> monkeysSorted = monkeys.OrderByDescending(o => o.activity).ToList(); //According to StackOverflow, this is how you sort a list of objects based on a property of those objects.
            long monkeyBusiness = 1;
            for (int i = 0; i < monkeysICanChase; i++)
            {
                Monkey monkey = monkeysSorted[i];
                monkeyBusiness *= monkey.activity;
            }
            for (int monkeyIndex = 0; monkeyIndex < monkeys.Count; monkeyIndex++)
            {
                Monkey monkey = monkeys[monkeyIndex];
                String blurb = monkeysSorted.IndexOf(monkey) > monkeysICanChase-1 ? "" : "Winner!";
                Console.WriteLine($"Monkey {monkeyIndex} inspected items {monkey.activity} times. {blurb}");
            }
            Console.WriteLine($"Final monkey business: {monkeyBusiness}");
        }
    }
}
