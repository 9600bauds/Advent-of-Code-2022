using Advent_of_Code_2022.libs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day19
    {
        static Regex parsingRegex = new Regex(@"Blueprint (?<blueprintId>[0-9\-]+): Each ore robot costs (?<orebotCost>[0-9\-]+) ore\. Each clay robot costs (?<claybotCost>[0-9\-]+) ore. Each obsidian robot costs (?<obsidianBotCost1>[0-9\-]+) ore and (?<obsidianBotCost2>[0-9\-]+) clay\. Each geode robot costs (?<geodebotCost1>[0-9\-]+) ore and (?<geodebotCost2>[0-9\-]+) obsidian\.");

        //const string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";
        const string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 11 clay. Each geode robot costs 2 ore and 7 obsidian.\r\nBlueprint 2: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 20 clay. Each geode robot costs 2 ore and 8 obsidian.\r\nBlueprint 3: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 15 clay. Each geode robot costs 4 ore and 16 obsidian.\r\nBlueprint 4: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 15 clay. Each geode robot costs 3 ore and 16 obsidian.\r\nBlueprint 5: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 4 ore and 8 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 6: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 18 clay. Each geode robot costs 3 ore and 8 obsidian.\r\nBlueprint 7: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 20 clay. Each geode robot costs 3 ore and 15 obsidian.\r\nBlueprint 8: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 15 clay. Each geode robot costs 3 ore and 20 obsidian.\r\nBlueprint 9: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 4 ore and 9 obsidian.\r\nBlueprint 10: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 9 clay. Each geode robot costs 3 ore and 15 obsidian.\r\nBlueprint 11: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 9 clay. Each geode robot costs 3 ore and 9 obsidian.\r\nBlueprint 12: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 16 clay. Each geode robot costs 3 ore and 14 obsidian.\r\nBlueprint 13: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 6 clay. Each geode robot costs 2 ore and 10 obsidian.\r\nBlueprint 14: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 3 ore and 8 obsidian.\r\nBlueprint 15: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 17 clay. Each geode robot costs 3 ore and 16 obsidian.\r\nBlueprint 16: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 15 clay. Each geode robot costs 4 ore and 17 obsidian.\r\nBlueprint 17: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 9 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 18: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 8 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 19: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 4 ore and 15 obsidian.\r\nBlueprint 20: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 21: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 15 clay. Each geode robot costs 3 ore and 7 obsidian.\r\nBlueprint 22: Each ore robot costs 4 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 7 clay. Each geode robot costs 2 ore and 16 obsidian.\r\nBlueprint 23: Each ore robot costs 2 ore. Each clay robot costs 2 ore. Each obsidian robot costs 2 ore and 7 clay. Each geode robot costs 2 ore and 14 obsidian.\r\nBlueprint 24: Each ore robot costs 3 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 19 clay. Each geode robot costs 3 ore and 19 obsidian.\r\nBlueprint 25: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 11 clay. Each geode robot costs 3 ore and 14 obsidian.\r\nBlueprint 26: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 7 clay. Each geode robot costs 3 ore and 9 obsidian.\r\nBlueprint 27: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 2 ore and 16 clay. Each geode robot costs 2 ore and 9 obsidian.\r\nBlueprint 28: Each ore robot costs 3 ore. Each clay robot costs 4 ore. Each obsidian robot costs 4 ore and 19 clay. Each geode robot costs 4 ore and 11 obsidian.\r\nBlueprint 29: Each ore robot costs 4 ore. Each clay robot costs 3 ore. Each obsidian robot costs 2 ore and 5 clay. Each geode robot costs 2 ore and 10 obsidian.\r\nBlueprint 30: Each ore robot costs 2 ore. Each clay robot costs 4 ore. Each obsidian robot costs 3 ore and 20 clay. Each geode robot costs 2 ore and 17 obsidian.";

        const int starterTimePart1 = 24;
        const int starterTimePart2 = 32;

        static int starterTime = starterTimePart1;

        public static void Run()
        {
            Dictionary<int, Blueprint> blueprints = ParseInput(input);

            //Test case for the example given for Part 2, with 32 minutes (make sure you're using the example input)
            /*Gamestate bestGame = new Gamestate(blueprints[1], starterTime);
            GameIterator.PlaybackGame(bestGame, "ore,clay,clay,clay,clay,clay,clay,clay,obsidian,obsidian,obsidian,obsidian,geode,obsidian,geode,geode,geode,geode,geode,geode,geode,geode");
            return;*/

            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine($" == PART 1: {blueprints.Count} blueprints, {starterTime} minutes per ==");
            stopwatch.Start();
            CalculateAnswer(blueprints);
            Console.WriteLine($"Calculated Part 1 in {stopwatch.ElapsedMilliseconds} ms.");

            Console.WriteLine($"\r\nPress any key for part 2...\r\n");
            Console.ReadKey();

            Dictionary<int, Blueprint> blueprintsShort = blueprints.Where(kvp => kvp.Key < 4).ToDictionary(kvp => kvp.Key, kvp => kvp.Value); //Using the power of linq!!!
            starterTime = starterTimePart2;
            Console.WriteLine($" == PART 2: {blueprintsShort.Count} blueprints, {starterTime} minutes per ==");
            stopwatch.Restart();
            CalculateAnswer(blueprintsShort);
            Console.WriteLine($"Calculated Part 2 in {stopwatch.ElapsedMilliseconds} ms.");
        }

        /// <summary>
        /// Creates a starter game, creates a gamestateIterator, and searches through all possible sequences to find the optimal game for each blueprint in the given set.
        /// </summary>
        /// <param name="blueprints">Set of blueprints to test.</param>
        public static void CalculateAnswer(Dictionary<int, Blueprint> blueprints)
        {
            int qualityNumberSum = 0;
            long geodeMultiplication = 1;
            foreach (KeyValuePair<int, Blueprint> entry in blueprints)
            {
                Gamestate starterGame = new(entry.Value, starterTime);
                GameIterator iterator = new(starterGame, Gamestate.comparer);
                iterator.DepthFirstSearch();
                Console.WriteLine($"Best game for blueprint {entry.Key} with {starterTime} minutes: {iterator.bestGame} with {iterator.bestGame.score} geodes, quality number: {iterator.bestGame.score * entry.Key}");
                qualityNumberSum += iterator.bestGame.score * entry.Key;
                geodeMultiplication *= iterator.bestGame.score;
            }
            Console.WriteLine($"Sum of quality numbers: {qualityNumberSum}.");
            Console.WriteLine($"Multiplication of highest geode count: {geodeMultiplication}.");
        }

        public static Dictionary<int, Blueprint> ParseInput(string input)
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
            return blueprints;
        }

        /// <summary>
        /// Represents a gamestate. We use this to simulate a game accordingly.
        /// </summary>
        public class Gamestate
        {
            /// <summary>
            /// Which blueprint are we using?
            /// </summary>
            public Blueprint blueprint;
            /// <summary>
            /// How many of each resource we have banked. We don't keep track of geodes per-turn, since nothing uses them - the "score" var does that.
            /// </summary>
            public Resources bank;
            /// <summary>
            /// How many of each bot we own. We don't keep track of geodebots, since their gains are deterministic - we just calculate how many geodes they would give us
            /// in their lifetime and add that to our "score".
            /// </summary>
            public Resources bots;
            /// <summary>
            /// Represents how many geodes we will have when our time runs out.
            /// </summary>
            public int score;
            public int timeleft;
            /// <summary>
            /// The robot that we want to build next.
            /// We don't actually simulate all possibilities each turn, we pick 1 bot that we'd like to build and do nothing until we can build that bot.
            /// Essentially, we don't simulate "what can we do each minute" but rather "what sequences of bots we could build"
            /// </summary>
            public string choice;
            /// <summary>
            /// string to keep track of which sequence of bots we chose to build so far, not actually necessary to calculate the answer but nice to know. e.g. "ore,ore,clay,obsidian".
            /// </summary>
            public string sequence;
            /// <summary>
            /// Comparer that we use to determine whether a game is better than another game.
            /// </summary>
            public static Comparer<Gamestate> comparer = Comparer<Gamestate>.Create((a, b) => { return Gamestate.CompareGames(a, b); });

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

            /// <summary>
            /// Skip time ahead until we can afford the bot we chose to build, or until the game is over.
            /// </summary>
            /// <param name="verbose">If true, writes a lot of info. If false, works silently.</param>
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

            /// <summary>
            /// Simulates the passage of time, decreasing our time left by this amount and increasing our resources correspondingly to our bot passive income.
            /// </summary>
            /// <param name="turns">How many minutes to simulate</param>
            /// <param name="verbose">If true, writes a lot of info. If false, works silently.</param>
            /// <param name="suppressStats">Even if verbose is true, shut up about our stats.</param>
            public void PassTime(int turns, bool verbose = false, bool suppressStats = false)
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

            /// <summary>
            /// Removes from our resources the cost that it would take to build this bot.
            /// </summary>
            /// <param name="newBot">string representing the bot desired. e.g. "ore", "clay", etc</param>
            /// <param name="verbose">If true, writes a lot of info. If false, works silently.</param>
            public void DeductBotCost(string newBot, bool verbose = false)
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

            /// <summary>
            /// Add 1 of this bot to our bot count. If the bot is a geodebot, it instead increases our score by the amount that said geodebot would generate in its lifetime.
            /// </summary>
            /// <param name="newBot">string representing the bot we want. e.g. "ore", "clay", etc</param>
            /// <param name="verbose">If true, writes a lot of info. If false, works silently.</param>
            public void AddBot(string newBot, bool verbose = false)
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

            /// <summary>
            /// How long would we have to wait to be able to afford this type of bot, according to our resources banked and our passive income?
            /// </summary>
            /// <param name="botCost">Resource cost of the bot we want to build.</param>
            /// <returns>Turns we would have to wait. Can be 0, meaning we can afford it right now.</returns>
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

            public bool CanAfford(Resources botCost)
            {
                return bank.ore >= botCost.ore && bank.clay >= botCost.clay && bank.obsidian >= botCost.obsidian;
            }

            /// <summary>
            /// Since we can't really do anything to affect our score in the last minute, it's not really "usable" and we don't simulate it.
            /// </summary>
            /// <returns>Amount of minutes we have left, excluding the last turn. So, timeleft - 1.</returns>
            public int UsableTimeRemaining()
            {
                return timeleft - 1; //The last turn doesn't really matter, since nothing we can do will affect our total geode count.
            }

            /// <summary>
            /// Have we reached the end?
            /// </summary>
            /// <returns>False if we still have time to try other things, True if we're done here.</returns>
            public bool IsFinished()
            {
                return UsableTimeRemaining() <= 0;
            }

            /// <summary>
            /// We stand at a crossroads. For each choice that's viable for us, create a clone of ourselves that wants to follow that choice. Add them to the set.
            /// </summary>
            /// <param name="unfinishedGames">The set where our clones will end up.</param>
            public void AddChildren(SortedSet<Gamestate> unfinishedGames)
            {
                List<string> myChoices = GetViableChoices();
                foreach (string newChoice in myChoices)
                {
                    Gamestate child = new(this, newChoice);
                    unfinishedGames.Add(child);
                }
            }

            /// <summary>
            /// Compare this game to the best game discovered so far. Uses a couple different heuristics to determine whether this game has even a remote chance to beat the best game's score.
            /// </summary>
            /// <param name="bestGame">Game to compare ourselves against</param>
            /// <returns>True if this game DEFINITELY has no chance to ever beat bestGame, False if there might be a possibility to beat it still, but we're not sure.</returns>
            public bool IsDeadEnd(Gamestate bestGame)
            {
                //Assume that we were somehow able to build 1 geodebot per turn for the rest of the game, even if this is wildly unrealistic.
                //If we STILL can't beat the best game, then we have literally no chance.
                int usableTime = UsableTimeRemaining();
                int maxScorePossible = score + Utils.GaussSummation(usableTime);
                if(maxScorePossible <= bestGame.score)
                {
                    return true;
                }
                //Round 2! Let's actually create a mirror gamestate, our slightly-less-unrealistic utopia.
                //In this utopia, we'll try to build a geodebot every single turn. And if we can't, we get an obsidianbot and an orebot for FREE!
                //We'll actually simulate this utopia to see if it beats the best game.
                //Simulating this isn't cheap, but it rules out so many dead ends that it cuts down total run time by around 50%.
                Gamestate utopia = new Gamestate(this.blueprint, "", this.bots, this.bank, this.score, this.timeleft);
                utopia.PassTime(1); //we check this as soon as our action finishes, so, hold that utopia for 1 turn
                while (!utopia.IsFinished())
                {
                    if (utopia.CanAfford(blueprint.geodeBotCost))
                    {
                        utopia.DeductBotCost("geode");
                        utopia.AddBot("geode");
                    }
                    else
                    {
                        utopia.AddBot("obsidian");
                        utopia.AddBot("ore");
                    }
                    utopia.PassTime(1);
                }
                if(utopia.score <= bestGame.score)
                {
                    return true;
                }

                return false;
            }

            /// <summary>
            /// Choices of bots that are viable for this gamestate to want to build next, according to a few criteria.
            /// Will ignore bots if we don't have their prequisites (e.g. no obsidianbots until we have clay), if we already have too much of that resource banked,
            /// or if it would take too long for us to be able to afford that bot.
            /// </summary>
            /// <returns>A List of strings representing the choices that are viable for us. May return an empty list. Example: { "ore","clay","obsidian" }.</returns>
            public List<string> GetViableChoices()
            {
                List<string> myChoices = new();

                if (bots.ore < blueprint.maxOreCost && bots.ore <= blueprint.maxOreCost * 1.5 && TimeToAfford(blueprint.oreBotCost) <= timeleft)
                {
                    myChoices.Add("ore");
                }
                if (bots.clay < blueprint.obsidianBotCost.clay && bank.clay <= blueprint.obsidianBotCost.clay * 1.5 && TimeToAfford(blueprint.clayBotCost) <= timeleft)
                {
                    myChoices.Add("clay");
                }
                if (bots.obsidian < blueprint.geodeBotCost.obsidian && bank.obsidian <= blueprint.geodeBotCost.obsidian * 1.5 && bots.clay != 0 && TimeToAfford(blueprint.obsidianBotCost) <= timeleft)
                {
                    myChoices.Add("obsidian");
                }
                if (bots.obsidian != 0 && TimeToAfford(blueprint.geodeBotCost) <= timeleft)
                {
                    myChoices.Add("geode");
                }

                return myChoices;
            }


            /// <summary>
            /// Compares 2 games to find out which one is better.
            /// If both games are equally viable, we'll just say A is better than B.
            /// This will result in a nondeterministic order, which is OK for our purposes, but would be improper for an IComparable, which is why we're doing it like this, so we can use a custom Comparer instead.
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns>0 if the games are identical, 1 if B is better than A, -1 if A is better than B OR the games are different but equally viable.</returns>
            public static int CompareGames(Gamestate a, Gamestate b)
            {
                // Apparently removing an item from a sortedset makes it compare with itself? idk
                if (Object.ReferenceEquals(a, b))
                {
                    return 0;
                }

                if (a.score > b.score) return -1; //Better score is better
                if (a.score < b.score) return 1;

                if (a.timeleft < b.timeleft) return -1; //Older games are better
                if (a.timeleft > b.timeleft) return 1;

                return -1; //Otherwise, they are different but equally good
            }
        }

        /// <summary>
        /// Class used to help in depth first search. Holds a list of games and then searches through them to find the best sequence to follow them on.
        /// </summary>
        public class GameIterator
        {
            /// <summary>
            /// Set that holds the gamestates discovered so far. Makes use of a Comparer to sort it, the iterator will always continue searching the "best" game.
            /// </summary>
            public SortedSet<Gamestate> unfinishedGames;
            /// <summary>
            /// Game with the highest score we've found so far.
            /// </summary>
            public Gamestate bestGame;

            public GameIterator(Gamestate starterGame, Comparer<Gamestate> comparer)
            {
                unfinishedGames = new(comparer);
                starterGame.AddChildren(unfinishedGames);
                bestGame = starterGame;
            }

            /// <summary>
            /// Plays back a given sequence of steps, providing a verbose step-by-step description of it. Used to verify the program works correctly by comparing it to the example given.
            /// </summary>
            /// <param name="game">A game to start from. Usually a "blank" game that's just started, but could be any other game.</param>
            /// <param name="steps">Sequence of steps to take. Example: ore,ore,clay,obsidian,geode</param>
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

            /// <summary>
            /// Searches through all possible gamestates to find the optimal one.
            /// Requires you to have loaded a "starter" game (or games) in unfinishedGames.
            /// Finishes when all viable possibilities have been explored. Uses some culling to rule out less-optimal sequences.
            /// </summary>
            public void DepthFirstSearch()
            {
                while (unfinishedGames.Count > 0)
                {
                    Gamestate? game = unfinishedGames.Min; //For some reason this is 50x faster than unfinishedGames.First() even though the result is basically the same?
                    if(game == null) { break; }

                    unfinishedGames.Remove(game);

                    game.FastForward();

                    if (bestGame.score > 0)
                    {
                        if (game.IsDeadEnd(bestGame))
                        {
                            continue;
                        }
                    }

                    if (game.IsFinished())
                    {
                        if (bestGame == null || bestGame.score < game.score)
                        {
                            bestGame = game;
                            //Console.WriteLine(game.sequence);
                        }
                    }
                    else
                    {
                        game.AddChildren(unfinishedGames);
                    }
                }
            }
        }

        /// <summary>
        /// Structure that represents a blueprint, as given in the input data. Holds info on how much each bot costs to make.
        /// </summary>
        public class Blueprint
        {
            public Resources oreBotCost;
            public Resources clayBotCost;
            public Resources obsidianBotCost;
            public Resources geodeBotCost;
            public Dictionary<string, Resources> string2cost;
            /// <summary>
            /// Max ore cost from all bots in our blueprint. Since ore is the only resource that's required for all bots, knowing the max amount ever needed helps in a couple places.
            /// </summary>
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

        /// <summary>
        /// Structure representing an amount of ore, clay, and obsidian.
        /// Used for our bank (how many of each resource we hold), for blueprints (how many of each resource each bot costs) and for our bot count (how many bots of each resource we own).
        /// Note that we don't track geodes. Since nothing costs geodes, this program abstracts them into "score" in the Gamestate class.
        /// </summary>
        public struct Resources
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
