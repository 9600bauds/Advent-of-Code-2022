using Advent_of_Code_2022.libs;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2022
{
    internal class Day19
    {
        static Regex parsingRegex = new Regex(@"Blueprint (?<blueprintId>[0-9\-]+): Each ore robot costs (?<orebotCost>[0-9\-]+) ore\. Each clay robot costs (?<claybotCost>[0-9\-]+) ore. Each obsidian robot costs (?<obsidianBotCost1>[0-9\-]+) ore and (?<obsidianBotCost2>[0-9\-]+) clay\. Each geode robot costs (?<geodebotCost1>[0-9\-]+) ore and (?<geodebotCost2>[0-9\-]+) obsidian\.");

        //static string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";
        static string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 11 clay. Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 2: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 20 clay. Each geode robot costs 2 ore and 8 obsidian.\r\nBlueprint 3: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 15 clay. Each geode robot costs 4 ore and 16 obsidian.\r\nBlueprint 4: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 15 clay. Each geode robot costs 3 ore and 16 obsidian.\r\nBlueprint 5: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 4 ore and 8 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 6: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 18 clay. Each geode robot costs 3 ore and 8 obsidian.\r\nBlueprint 7: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 20 clay. Each geode robot costs 3 ore and 15 obsidian.\r\nBlueprint 8: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 15 clay. Each geode robot costs 3 ore and 20 obsidian.\r\nBlueprint 9: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 4 ore and 9 obsidian.\r\nBlueprint 10: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 9 clay. Each geode robot costs 3 ore and 15 obsidian.\r\nBlueprint 11: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 9 clay. Each geode robot costs 3 ore and 9 obsidian.\r\nBlueprint 12: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 16 clay. Each geode robot costs 3 ore and 14 obsidian.\r\nBlueprint 13: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 6 clay. Each geode robot costs 2 ore and 10 obsidian.\r\nBlueprint 14: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 3 ore and 8 obsidian.\r\nBlueprint 15: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 17 clay. Each geode robot costs 3 ore and 16 obsidian.\r\nBlueprint 16: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 15 clay. Each geode robot costs 4 ore and 17 obsidian.\r\nBlueprint 17: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 9 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 18: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 8 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 19: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 4 ore and 15 obsidian.\r\nBlueprint 20: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 21: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 15 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 22: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 7 clay. Each geode robot costs 2 ore and 16 obsidian.\r\nBlueprint 23: Each ore robot costs 2 ore. Each clay robot costs 2 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 2 ore and 14 obsidian.\r\nBlueprint 24: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 25: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 11 clay. Each geode robot costs 3 ore and 14 obsidian.\r\nBlueprint 26: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 7 clay. Each geode robot costs 3 ore and 9 obsidian.\r\nBlueprint 27: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 16 clay. Each geode robot costs 2 ore and 9 obsidian.\r\nBlueprint 28: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 19 clay. Each geode robot costs 4 ore and 11 obsidian.\r\nBlueprint 29: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 5 clay. Each geode robot costs 2 ore and 10 obsidian.\r\nBlueprint 30: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 17 obsidian.";

        static int starterTime = 32;

        public static void Run()
        {
            List<string> inputByLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.
            Dictionary<int, Blueprint> blueprints = new();
            foreach (string line in inputByLine)
            {
                Match match = parsingRegex.Match(line);
                if (!match.Success)
                {
                    Debug.Fail($"Could not parse {line}!");
                }
                int blueprintId = int.Parse(match.Groups["blueprintId"].Value);
                int orebotCost = int.Parse(match.Groups["orebotCost"].Value);
                int claybotCost = int.Parse(match.Groups["claybotCost"].Value);
                (int, int) obsidianbotCost = (int.Parse(match.Groups["obsidianBotCost1"].Value), int.Parse(match.Groups["obsidianBotCost2"].Value));
                (int, int) geodebotCost = (int.Parse(match.Groups["geodebotCost1"].Value), int.Parse(match.Groups["geodebotCost2"].Value));
                blueprints.Add(blueprintId, new Blueprint(orebotCost, claybotCost, obsidianbotCost, geodebotCost));
            }


            /*Gamestate bestGame = new Gamestate(blueprints[2], "", new[] { 1, 0, 0, 0 }, new[] { 0, 0, 0, 0 }, starterTime);
            GameIterator.PlaybackGame(bestGame, "ore,ore,clay,clay,clay,clay,clay,obsidian,clay,obsidian,obsidian,ore,obsidian,obsidian,geode,obsidian,geode,obsidian,geode,obsidian,geode");
            return;*/

            int qualityNumberSum = 0;
            foreach (KeyValuePair<int, Blueprint> entry in blueprints)
            {
                Gamestate starterGame = new Gamestate(entry.Value, "", new[] { 1, 0, 0, 0 }, new[] { 0, 0, 0, 0 }, starterTime);
                GameIterator iterator = new GameIterator(new HashSet<Gamestate>() { starterGame });
                iterator.StartDepthFirstSearch();
                Console.WriteLine($"Best game for blueprint {entry.Key} with {starterTime} minutes: {iterator.bestGame} with {iterator.bestGame.resources[3]} geodes, quality number: {iterator.bestGame.resources[3] * entry.Key}");
                qualityNumberSum += iterator.bestGame.resources[3] * entry.Key;
            }
            Console.WriteLine($"Sum of quality numbers: {qualityNumberSum}.");


            //HashSet<Gamestate> SortedList = iterator.finishedGames.OrderBy(o => o.resources[3]).Reverse().ToHashSet();
        }

        class Gamestate
        {
            public Blueprint blueprint;
            public string sequence;
            public int[] bots;
            public int[] resources;
            public int timeleft;
            public string? choice;
            public static string[] choices = new[] { "ore", "clay", "obsidian", "geode" };

            public Gamestate(Blueprint blueprint, string sequence, int[] bots, int[] resources, int timeleft)
            {
                this.blueprint = blueprint;
                this.sequence = sequence;
                this.bots = bots;
                this.resources = resources;
                this.timeleft = timeleft;
            }

            public Gamestate(Gamestate original, string choice)
            {
                this.blueprint = original.blueprint;
                this.sequence = original.sequence + "," + choice;
                this.bots = original.bots.ToArray();
                this.resources = original.resources.ToArray();
                this.timeleft = original.timeleft;
                this.choice = choice;
            }

            public override string ToString()
            {
                return $"{resources[3]}${sequence}";
            }

            public void SetChoice(string newChoice = "")
            {
                if (newChoice != "")
                {
                    choice = newChoice;
                    return;
                }
            }

            public void FastForward(bool verbose = false)
            {
                if (choice == "")
                {
                    while (!IsFinished())
                    {
                        PassTime(1, verbose);
                        return;
                    }
                }
                int tta = TimeToAfford(choice);
                if (tta > timeleft)
                {
                    PassTime(timeleft, verbose);
                    return;
                }
                if (tta > 0)
                {
                    PassTime(tta, verbose);
                }
                if (TimeToAfford(choice) <= 0 && timeleft > 0)
                {
                    PassTime(1, verbose);
                    AddBot(choice, verbose);
                }
            }

            public void PassTime(int turns, bool verbose)
            {
                timeleft -= turns;
                for (int i = 0; i < resources.Length; i++)
                {
                    resources[i] += bots[i] * turns;
                }
                if (verbose)
                {
                    Console.WriteLine($"==MINUTE {starterTime - timeleft}==");
                    Console.WriteLine($"Bots: {string.Join(",", bots)} | Resources: {string.Join(",", resources)}");
                }
            }

            public void AddBot(string newBot, bool verbose)
            {
                switch (newBot)
                {
                    case "ore":
                        resources[0] -= blueprint.orebotCost;
                        bots[0]++;
                        break;
                    case "clay":
                        resources[0] -= blueprint.claybotCost;
                        bots[1]++;
                        break;
                    case "obsidian":
                        resources[0] -= blueprint.obsidianbotCost.Item1;
                        resources[1] -= blueprint.obsidianbotCost.Item2;
                        bots[2]++;
                        break;
                    case "geode":
                        resources[0] -= blueprint.geodebotCost.Item1;
                        resources[2] -= blueprint.geodebotCost.Item2;
                        bots[3]++;
                        break;
                }
                if (verbose)
                {
                    Console.WriteLine($"Adding 1 {newBot}bot...");
                    Console.WriteLine($"Bots: {string.Join(",", bots)} | Resources: {string.Join(",", resources)}");
                }
            }

            public int TimeToAfford(string bot)
            {
                int tta = 999;
                int tta2;
                switch (bot)
                {
                    case "ore":
                        tta = blueprint.orebotCost - resources[0];
                        if (tta <= 0) { return 0; }
                        tta = Utils.DivideIntsAndRoundUp(tta, bots[0]);
                        break;
                    case "clay":
                        tta = blueprint.claybotCost - resources[0];
                        if (tta <= 0) { return 0; }
                        tta = Utils.DivideIntsAndRoundUp(tta, bots[0]);
                        break;
                    case "obsidian":
                        tta = blueprint.obsidianbotCost.Item1 - resources[0];
                        tta2 = blueprint.obsidianbotCost.Item2 - resources[1];
                        if (tta <= 0 && tta2 <= 0) { return 0; }
                        tta = Utils.DivideIntsAndRoundUp(tta, bots[0]);
                        tta2 = Utils.DivideIntsAndRoundUp(tta2, bots[1]);
                        tta = Math.Max(tta, tta2);
                        break;
                    case "geode":
                        tta = blueprint.geodebotCost.Item1 - resources[0];
                        tta2 = blueprint.geodebotCost.Item2 - resources[2];
                        if (tta <= 0 && tta2 <= 0) { return 0; }
                        tta = Utils.DivideIntsAndRoundUp(tta, bots[0]);
                        tta2 = Utils.DivideIntsAndRoundUp(tta2, bots[2]);
                        tta = Math.Max(tta, tta2);
                        break;
                    default:
                        Debug.Fail($"TTA called with invalid argument! {bot}");
                        break;
                }
                return tta;

            }

            public bool IsFinished()
            {
                return timeleft == 0;
            }

            public void GameOver()
            {

            }

            public void Clone(HashSet<Gamestate> unfinishedGames)
            {
                string[] myChoices = GetChoices();
                foreach (string newChoice in myChoices)
                {
                    Gamestate clone = new Gamestate(this, newChoice);
                    unfinishedGames.Add(clone);
                }
            }

            public string[] GetChoices()
            {
                List<string> myChoices = choices.ToList();

                int maxOreCost = new[] { blueprint.orebotCost, blueprint.claybotCost, blueprint.obsidianbotCost.Item1, blueprint.geodebotCost.Item1 }.Max();
                if (bots[0] >= maxOreCost || resources[0] > maxOreCost * 2 || TimeToAfford("ore") > timeleft)
                {
                    myChoices.Remove("ore");
                }
                if (bots[1] >= blueprint.obsidianbotCost.Item2 || resources[1] > blueprint.obsidianbotCost.Item2 * 2 || TimeToAfford("clay") > timeleft)
                {
                    myChoices.Remove("clay");
                }
                if (bots[2] >= blueprint.geodebotCost.Item2 || resources[2] >= blueprint.geodebotCost.Item2 * 2 || bots[1] == 0 || TimeToAfford("obsidian") > timeleft)
                {
                    myChoices.Remove("obsidian");
                }
                if (bots[2] == 0 || TimeToAfford("geode") > timeleft)
                {
                    myChoices.Remove("geode");
                }

                return myChoices.ToArray();
            }
        }

        class GameIterator
        {
            public HashSet<Gamestate> unfinishedGames;
            public HashSet<Gamestate> finishedGames;
            public Gamestate bestGame;

            public GameIterator(HashSet<Gamestate> unfinishedGames)
            {
                this.unfinishedGames = unfinishedGames;
                finishedGames = new();
            }

            public static void PlaybackGame(Gamestate game, string steps)
            {
                List<string> stepList = steps.Split(',').ToList();
                foreach (string step in stepList)
                {
                    game.SetChoice(step);
                    game.FastForward(true);
                }
                while (!game.IsFinished())
                {
                    game.FastForward(true);
                }
            }

            public void StartDepthFirstSearch()
            {
                if (unfinishedGames.Count == 1)
                {
                    unfinishedGames.First().Clone(unfinishedGames);
                    unfinishedGames.Remove(unfinishedGames.First());
                }
                while (unfinishedGames.Count > 0)
                {
                    Gamestate game = unfinishedGames.First();
                    if (game.sequence == "")
                    {
                        game.Clone(unfinishedGames);
                    }
                    game.FastForward();
                    if (game.IsFinished())
                    {
                        game.GameOver();
                        if (bestGame == null || bestGame.resources[3] < game.resources[3])
                        {
                            bestGame = game;
                            Console.WriteLine(game.sequence);
                        }
                    }
                    else
                    {
                        game.Clone(unfinishedGames);
                    }
                    //finishedGames.Add(game);
                    unfinishedGames.Remove(game);

                }
            }
        }

        class Blueprint
        {
            public int orebotCost;
            public int claybotCost;
            public (int, int) obsidianbotCost;
            public (int, int) geodebotCost;

            public Blueprint(int orebotCost, int claybotCost, (int, int) obsidianbotCost, (int, int) geodebotCost)
            {
                this.orebotCost = orebotCost;
                this.claybotCost = claybotCost;
                this.obsidianbotCost = obsidianbotCost;
                this.geodebotCost = geodebotCost;
            }
        }
    }
}
