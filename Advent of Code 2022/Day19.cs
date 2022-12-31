using Advent_of_Code_2022.libs;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2022
{
    internal class Day19
    {
        static Regex parsingRegex = new Regex(@"Blueprint (?<blueprintId>[0-9\-]+): Each ore robot costs (?<orebotCost>[0-9\-]+) ore\. Each clay robot costs (?<claybotCost>[0-9\-]+) ore. Each obsidian robot costs (?<obsidianBotCost1>[0-9\-]+) ore and (?<obsidianBotCost2>[0-9\-]+) clay\. Each geode robot costs (?<geodebotCost1>[0-9\-]+) ore and (?<geodebotCost2>[0-9\-]+) obsidian\.");

        //const string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";
        const string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 11 clay. Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 2: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 20 clay. Each geode robot costs 2 ore and 8 obsidian.\r\nBlueprint 3: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 15 clay. Each geode robot costs 4 ore and 16 obsidian.\r\nBlueprint 4: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 15 clay. Each geode robot costs 3 ore and 16 obsidian.\r\nBlueprint 5: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 4 ore and 8 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 6: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 18 clay. Each geode robot costs 3 ore and 8 obsidian.\r\nBlueprint 7: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 20 clay. Each geode robot costs 3 ore and 15 obsidian.\r\nBlueprint 8: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 15 clay. Each geode robot costs 3 ore and 20 obsidian.\r\nBlueprint 9: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 4 ore and 9 obsidian.\r\nBlueprint 10: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 9 clay. Each geode robot costs 3 ore and 15 obsidian.\r\nBlueprint 11: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 9 clay. Each geode robot costs 3 ore and 9 obsidian.\r\nBlueprint 12: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 16 clay. Each geode robot costs 3 ore and 14 obsidian.\r\nBlueprint 13: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 6 clay. Each geode robot costs 2 ore and 10 obsidian.\r\nBlueprint 14: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 3 ore and 8 obsidian.\r\nBlueprint 15: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 17 clay. Each geode robot costs 3 ore and 16 obsidian.\r\nBlueprint 16: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 15 clay. Each geode robot costs 4 ore and 17 obsidian.\r\nBlueprint 17: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 9 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 18: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 8 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 19: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 4 ore and 15 obsidian.\r\nBlueprint 20: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 21: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 15 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 22: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 7 clay. Each geode robot costs 2 ore and 16 obsidian.\r\nBlueprint 23: Each ore robot costs 2 ore. Each clay robot costs 2 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 2 ore and 14 obsidian.\r\nBlueprint 24: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 25: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 11 clay. Each geode robot costs 3 ore and 14 obsidian.\r\nBlueprint 26: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 7 clay. Each geode robot costs 3 ore and 9 obsidian.\r\nBlueprint 27: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 16 clay. Each geode robot costs 2 ore and 9 obsidian.\r\nBlueprint 28: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 19 clay. Each geode robot costs 4 ore and 11 obsidian.\r\nBlueprint 29: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 5 clay. Each geode robot costs 2 ore and 10 obsidian.\r\nBlueprint 30: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 17 obsidian.";

        static int starterTime = 24;
        //static int starterTime = 32;

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

                Resources oreBotCost = new(int.Parse(match.Groups["orebotCost"].Value), 0, 0);
                Resources clayBotcost = new(int.Parse(match.Groups["claybotCost"].Value), 0, 0);
                Resources obsidianBotCost = new(int.Parse(match.Groups["obsidianBotCost1"].Value), int.Parse(match.Groups["obsidianBotCost2"].Value), 0);
                Resources geodeBotCost = new(int.Parse(match.Groups["geodebotCost1"].Value), 0, int.Parse(match.Groups["geodebotCost2"].Value));

                blueprints.Add(blueprintId, new Blueprint(oreBotCost, clayBotcost, obsidianBotCost, geodeBotCost));
            }


            //Test case for the example given for Part 2, with 32 minutes
            /*Gamestate bestGame = new Gamestate(blueprints[1], starterTime);
            GameIterator.PlaybackGame(bestGame, "ore,clay,clay,clay,clay,clay,clay,clay,obsidian,obsidian,obsidian,obsidian,geode,obsidian,geode,geode,geode,geode,geode,geode,geode,geode");
            return;*/

            int qualityNumberSum = 0;
            foreach (KeyValuePair<int, Blueprint> entry in blueprints)
            {
                Gamestate starterGame = new(entry.Value, starterTime);
                GameIterator iterator = new(new HashSet<Gamestate>() { starterGame });
                iterator.StartDepthFirstSearch();
                Console.WriteLine($"Best game for blueprint {entry.Key} with {starterTime} minutes: {iterator.bestGame} with {iterator.bestGame.score} geodes, quality number: {iterator.bestGame.score * entry.Key}");
                qualityNumberSum += iterator.bestGame.score * entry.Key;
            }
            Console.WriteLine($"Sum of quality numbers: {qualityNumberSum}.");

        }

        class Gamestate
        {
            public Blueprint blueprint;
            public string sequence;
            public Resources bank; //We don't need to keep track of geodes per-turn, since nothing uses them
            public Resources bots; //We don't need to keep track of geodebots, since their lifetime gains are deterministic
            public int score; //This represents how many geodes we will have when our time runs out
            public int timeleft;
            public string choice;
            public static string[] choices = new[] { "ore", "clay", "obsidian", "geode" };

            public Gamestate(Blueprint blueprint, string sequence, Resources bots, Resources bank, int score, int timeleft)
            {
                this.blueprint = blueprint;
                this.sequence = sequence;
                this.bots = bots;
                this.bank = bank;
                this.score = score;
                this.timeleft = timeleft;
                choice = "";
            }

            public Gamestate(Gamestate original, string choice)
            {
                this.blueprint = original.blueprint;
                this.sequence = original.sequence + "," + choice;
                this.bots = original.bots;
                this.bank = original.bank;
                this.timeleft = original.timeleft;
                this.score = original.score;
                this.choice = choice;
            }

            public Gamestate(Blueprint blueprint, int timeleft)
            {
                this.blueprint = blueprint;
                this.timeleft = timeleft;
                sequence = "";
                bank = new(0, 0, 0);
                bots = new(1, 0, 0);
                score = 0;
                choice = "";
            }

            public override string ToString()
            {
                return $"{score}${sequence}";
            }

            public void FastForward(bool verbose = false)
            {
                Resources botCost = blueprint.string2cost[choice];
                int tta = TimeToAfford(botCost);
                if (tta > UsableTimeRemaining())
                {
                    PassTime(timeleft, verbose); //Game over!
                    return;
                }
                if (tta > 0)
                {
                    PassTime(tta, verbose);
                }
                PassTime(1, verbose, true);
                DeductBotCost(choice, verbose);                
                AddBot(choice, verbose);
            }

            public void PassTime(int turns, bool verbose, bool suppressStats = false)
            {
                timeleft -= turns;
                bank.ore += bots.ore * turns;
                bank.clay += bots.clay * turns;
                bank.obsidian += bots.obsidian * turns;
                if (verbose)
                {
                    Console.WriteLine($"==MINUTE {starterTime - timeleft}==");
                    if (!suppressStats)
                    {
                        Console.WriteLine($"Bots: {string.Join(",", bots)} | Resources: {string.Join(",", bank)} | Score: {score}");
                    }
                }
            }

            public void DeductBotCost(string newBot, bool verbose)
            {
                Resources cost = blueprint.string2cost[newBot];
                bank.ore -= cost.ore;
                bank.clay -= cost.clay;
                bank.obsidian -= cost.obsidian;
                if (verbose)
                {
                    Console.WriteLine($"Spending {cost} to build {newBot}bot.");
                }
            }

            public void AddBot(string newBot, bool verbose)
            {
                if (newBot == "geode")
                {
                    score += timeleft;
                    if (verbose)
                    {
                        Console.WriteLine($"Adding 1 {newBot}bot. It will make {timeleft} geodes, bringing our score to {score}.");
                        Console.WriteLine($"Bots: {string.Join(",", bots)} | Resources: {string.Join(",", bank)} | Score: {score}");
                    }
                    return;
                }

                switch (newBot)
                {
                    case "ore":
                        bots.ore++; break;
                    case "clay":
                        bots.clay++; break;
                    case "obsidian":
                        bots.obsidian++; break;
                }
                if (verbose)
                {
                    Console.WriteLine($"Adding 1 {newBot}bot...");
                    Console.WriteLine($"Bots: {string.Join(",", bots)} | Resources: {string.Join(",", bank)} | Score: {score}");
                }
            }

            public int TimeToAfford(Resources botCost)
            {
                int tta = 0;
                if (botCost.ore > bank.ore)
                {
                    int deficit = Math.Max(0, botCost.ore - bank.ore);
                    tta = Math.Max(tta, Utils.DivideIntsAndRoundUp(deficit, bots.ore));
                }
                if (botCost.clay > bank.clay)
                {
                    int deficit = Math.Max(0, botCost.clay - bank.clay);
                    tta = Math.Max(tta, Utils.DivideIntsAndRoundUp(deficit, bots.clay));
                }
                if (botCost.obsidian > bank.obsidian)
                {
                    int deficit = Math.Max(0, botCost.obsidian - bank.obsidian);
                    tta = Math.Max(tta, Utils.DivideIntsAndRoundUp(deficit, bots.obsidian));
                }
                return tta;
            }

            public int UsableTimeRemaining()
            {
                return timeleft - 1; //The last turn doesn't really matter, since nothing we can do will affect our total geode count.
            }

            public bool IsFinished()
            {
                return UsableTimeRemaining() <= 0;
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

                if (bots.ore >= blueprint.maxOreCost || bots.ore > blueprint.maxOreCost * 2 || TimeToAfford(blueprint.oreBotCost) > timeleft)
                {
                    myChoices.Remove("ore");
                }
                if (bots.clay >= blueprint.obsidianBotCost.clay || bank.clay > blueprint.obsidianBotCost.clay * 2 || TimeToAfford(blueprint.clayBotCost) > timeleft)
                {
                    myChoices.Remove("clay");
                }
                if (bots.obsidian >= blueprint.geodeBotCost.obsidian || bank.obsidian >= blueprint.geodeBotCost.obsidian * 2 || bots.clay == 0 || TimeToAfford(blueprint.obsidianBotCost) > timeleft)
                {
                    myChoices.Remove("obsidian");
                }
                if (bots.obsidian == 0 || TimeToAfford(blueprint.geodeBotCost) > timeleft)
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
                    game.choice = step;
                    game.FastForward(true);
                }
                while (!game.IsFinished())
                {
                    game.PassTime(1, true);
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
                        if (bestGame == null || bestGame.score < game.score)
                        {
                            bestGame = game;
                            Console.WriteLine(game.sequence);
                        }
                    }
                    else
                    {
                        game.Clone(unfinishedGames);
                    }
                    unfinishedGames.Remove(game);

                }
            }
        }

        class Blueprint
        {
            public Resources oreBotCost;
            public Resources clayBotCost;
            public Resources obsidianBotCost;
            public Resources geodeBotCost;
            public Dictionary<string, Resources> string2cost;
            public int maxOreCost;

            public Blueprint(Resources oreBotCost, Resources clayBotCost, Resources obsidianBotCost, Resources geodeBotCost)
            {
                this.oreBotCost = oreBotCost;
                this.clayBotCost = clayBotCost;
                this.obsidianBotCost = obsidianBotCost;
                this.geodeBotCost = geodeBotCost;

                string2cost = new() { { "ore", oreBotCost }, { "clay", clayBotCost }, { "obsidian", obsidianBotCost }, { "geode", geodeBotCost } };

                int[] oreCosts = { oreBotCost.ore, clayBotCost.ore, obsidianBotCost.ore, geodeBotCost.ore };
                maxOreCost = oreCosts.Max();
            }
        }

        struct Resources
        {
            public int ore;
            public int clay;
            public int obsidian;

            public Resources(int ore, int clay, int obsidian)
            {
                this.ore = ore;
                this.clay = clay;
                this.obsidian = obsidian;
            }

            public override string? ToString()
            {
                return $"{ore} ore, {clay} clay, {obsidian} obsidian";
            }
        }
    }
}
