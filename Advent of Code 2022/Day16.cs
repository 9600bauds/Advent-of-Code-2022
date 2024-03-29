﻿using Advent_of_Code_2022.libs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2022
{
    internal class Day16
    {
        //https://adventofcode.com/2022/day/16

        static Regex parsingRegex = new Regex(@"Valve (?<valveId>\w+) has flow rate=(?<flowRate>[0-9\-]+)\; \w+ \w+ to \w+ (?<tunnels>.+)");

        public static int startingTime = 30;
        public static int elephantTrainingDelay = 4;
        public static string startingValve = "AA";

        public static Node stopNode = new("STOP", 0);

        //public static string input = "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB\r\nValve BB has flow rate=13; tunnels lead to valves CC, AA\r\nValve CC has flow rate=2; tunnels lead to valves DD, BB\r\nValve DD has flow rate=20; tunnels lead to valves CC, AA, EE\r\nValve EE has flow rate=3; tunnels lead to valves FF, DD\r\nValve FF has flow rate=0; tunnels lead to valves EE, GG\r\nValve GG has flow rate=0; tunnels lead to valves FF, HH\r\nValve HH has flow rate=22; tunnel leads to valve GG\r\nValve II has flow rate=0; tunnels lead to valves AA, JJ\r\nValve JJ has flow rate=21; tunnel leads to valve II";
        public static string input = "Valve OQ has flow rate=17; tunnels lead to valves NB, AK, KL\r\nValve HP has flow rate=0; tunnels lead to valves ZX, KQ\r\nValve GO has flow rate=0; tunnels lead to valves HR, GW\r\nValve PD has flow rate=9; tunnels lead to valves XN, EV, QE, MW\r\nValve NQ has flow rate=0; tunnels lead to valves HX, ZX\r\nValve DW has flow rate=0; tunnels lead to valves IR, WE\r\nValve TN has flow rate=24; tunnels lead to valves KL, EI\r\nValve JJ has flow rate=0; tunnels lead to valves EV, HR\r\nValve KH has flow rate=0; tunnels lead to valves ZQ, AA\r\nValve PH has flow rate=0; tunnels lead to valves FN, QE\r\nValve FD has flow rate=0; tunnels lead to valves SM, HX\r\nValve SM has flow rate=7; tunnels lead to valves WW, RZ, FD, HO, KQ\r\nValve PU has flow rate=0; tunnels lead to valves VL, IR\r\nValve OM has flow rate=0; tunnels lead to valves CM, AA\r\nValve KX has flow rate=20; tunnel leads to valve PC\r\nValve IR has flow rate=3; tunnels lead to valves PU, CM, WW, DW, AF\r\nValve XG has flow rate=0; tunnels lead to valves RX, OF\r\nValve QE has flow rate=0; tunnels lead to valves PH, PD\r\nValve GW has flow rate=0; tunnels lead to valves JQ, GO\r\nValve HO has flow rate=0; tunnels lead to valves SM, TY\r\nValve WU has flow rate=0; tunnels lead to valves SG, RZ\r\nValve MS has flow rate=0; tunnels lead to valves UE, OF\r\nValve JS has flow rate=0; tunnels lead to valves DO, ZX\r\nValve YQ has flow rate=0; tunnels lead to valves BC, SG\r\nValve EJ has flow rate=0; tunnels lead to valves AA, LR\r\nValve EI has flow rate=0; tunnels lead to valves BV, TN\r\nValve NC has flow rate=0; tunnels lead to valves TS, BC\r\nValve AF has flow rate=0; tunnels lead to valves IR, HX\r\nValve OX has flow rate=0; tunnels lead to valves HR, BV\r\nValve BF has flow rate=0; tunnels lead to valves JQ, SY\r\nValve CA has flow rate=0; tunnels lead to valves YD, HX\r\nValve KQ has flow rate=0; tunnels lead to valves HP, SM\r\nValve NB has flow rate=0; tunnels lead to valves OQ, OF\r\nValve SY has flow rate=0; tunnels lead to valves BF, BV\r\nValve AA has flow rate=0; tunnels lead to valves KH, EJ, OM, TY, DO\r\nValve BC has flow rate=11; tunnels lead to valves WE, RX, YQ, LR, NC\r\nValve HR has flow rate=14; tunnels lead to valves OX, GO, JJ\r\nValve WE has flow rate=0; tunnels lead to valves DW, BC\r\nValve MW has flow rate=0; tunnels lead to valves JQ, PD\r\nValve DO has flow rate=0; tunnels lead to valves JS, AA\r\nValve PC has flow rate=0; tunnels lead to valves AK, KX\r\nValve YD has flow rate=0; tunnels lead to valves CA, OF\r\nValve RX has flow rate=0; tunnels lead to valves XG, BC\r\nValve CM has flow rate=0; tunnels lead to valves IR, OM\r\nValve HX has flow rate=6; tunnels lead to valves ZQ, NQ, AF, FD, CA\r\nValve ZQ has flow rate=0; tunnels lead to valves KH, HX\r\nValve BV has flow rate=21; tunnels lead to valves SY, OX, EI\r\nValve AK has flow rate=0; tunnels lead to valves PC, OQ\r\nValve UE has flow rate=0; tunnels lead to valves MS, JQ\r\nValve LR has flow rate=0; tunnels lead to valves BC, EJ\r\nValve JQ has flow rate=8; tunnels lead to valves MW, UE, BF, GW\r\nValve VL has flow rate=0; tunnels lead to valves PU, ZX\r\nValve EV has flow rate=0; tunnels lead to valves JJ, PD\r\nValve TS has flow rate=0; tunnels lead to valves NC, ZX\r\nValve RZ has flow rate=0; tunnels lead to valves SM, WU\r\nValve OF has flow rate=13; tunnels lead to valves XG, YD, NB, MS, XN\r\nValve WW has flow rate=0; tunnels lead to valves SM, IR\r\nValve TY has flow rate=0; tunnels lead to valves HO, AA\r\nValve XN has flow rate=0; tunnels lead to valves OF, PD\r\nValve SG has flow rate=15; tunnels lead to valves WU, YQ\r\nValve FN has flow rate=25; tunnel leads to valve PH\r\nValve KL has flow rate=0; tunnels lead to valves TN, OQ\r\nValve ZX has flow rate=5; tunnels lead to valves JS, HP, VL, NQ, TS";

        public static void Run()
        {
            Dictionary<string, Node> valves = ProcessInput(input, true);

            HashSet<Node> allChoices = valves.Values.ToHashSet();
            Node starterValve = valves[startingValve];
            allChoices.Remove(starterValve);

            //Hasty verification routine with the example input
            /*Gamestate testGame = new Gamestate(0, allChoices.ToHashSet(), "");
            Player starterPlayer = new Player(starterValve, startingTime, testGame);
            HashSet<Node> sequence = new(){ valves["DD"], valves["BB"], valves["JJ"], valves["HH"], valves["EE"], valves["CC"] }; //DD,BB,JJ,HH,EE,CC
            foreach (Node node in sequence)
            {
                starterPlayer.TakeTurn(node, true);
            }*/

            Stopwatch timer = Stopwatch.StartNew();
            timer.Start();

            int maxPlayersBeforeWeRunOutOfTime = startingTime / elephantTrainingDelay;
            for (int playerCount = 1; playerCount < maxPlayersBeforeWeRunOutOfTime; playerCount++)
            {
                Gamestate freeform = new(0, allChoices.ToList(), "");
                for (int i = 1; i <= playerCount - 1; i++)
                {
                    int elephantTime = startingTime - (elephantTrainingDelay * i);
                    freeform.players.Add(new Player(starterValve, elephantTime, freeform));
                }
                int time = startingTime - (elephantTrainingDelay * (playerCount - 1));
                freeform.players.Add(new Player(starterValve, time, freeform)); //The human!

                GamestateIterator iteratorFreeform = new(freeform, Gamestate.comparer);
                iteratorFreeform.Start();
                Task.WaitAll(iteratorFreeform.tasks);
                Console.WriteLine($"\r\n1 player, {playerCount - 1} elephants: {iteratorFreeform.bestGame.score}! {iteratorFreeform.bestGame.sequence}");

                if (playerCount > 1 && playerCount < maxPlayersBeforeWeRunOutOfTime - 1)
                {
                    timer.Stop();
                    Console.WriteLine($"Would you like to calculate the score for {playerCount} elephants, just for fun? Assume that you have to teach each elephant sequentially.\r\nPress Y to accept, or anything else to abort.");
                    if (Console.ReadKey(true).Key != ConsoleKey.Y)
                    {
                        break;
                    }
                    timer.Start();
                    Console.WriteLine($"Calculating... (might take up to a couple minutes with the real input)");
                }
            }
            Console.WriteLine($"\r\nFinished in {timer.ElapsedMilliseconds}ms!");
        }

        public static Dictionary<string, Node> ProcessInput(string input, bool verbose = false)
        {
            Dictionary<string, Node> valves = new();
            List<Connection> tunnels = new();

            string[] inputByLine = Utils.SplitLines(input);
            Dictionary<string, string[]> tempConnections = new();
            foreach (string line in inputByLine)
            {
                Match match = parsingRegex.Match(line);
                if (match.Success)
                {
                    string valveId = match.Groups["valveId"].Value;
                    int flowRate = int.Parse(match.Groups["flowRate"].Value);

                    string[] tunnelsArray = Utils.SplitCommaSpace(match.Groups["tunnels"].Value);
                    valves.Add(valveId, new Node(valveId, flowRate));
                    tempConnections.Add(valveId, tunnelsArray);
                }
                else
                {
                    Debug.Fail($"Could not parse {line}!");
                }
            }
            foreach (KeyValuePair<string, string[]> entry in tempConnections)
            {
                string id = entry.Key.Substring(0, 2);
                Node valve = valves[id];
                foreach (string tunnel in entry.Value)
                {
                    int cost = 1;
                    if (tunnel.Length > 2)
                    {
                        cost = int.Parse(tunnel.Substring(2));
                    }
                    string to = tunnel.Substring(0, 2);
                    Node destination = valves[to];

                    if (destination.connections.ContainsKey(valve))
                    {
                        continue;
                    }
                    tunnels.Add(new Connection(valve, destination, cost));
                }
            }

            if (verbose) Console.WriteLine($"Loaded {valves.Count} valves with a total of {tunnels.Count} connections.");

            int connectionsSimplified = 0;
            bool finished = false;
            while (finished == false)
            {
                finished = true;
                for (int i = 0; i < valves.Values.Count; i++)
                {
                    Node valve = valves.Values.ToList()[i];
                    if (valve.flowRate > 0 || valve.id == startingValve)
                    {
                        continue;
                    }
                    if (valve.Simplify(valves, tunnels))
                    {
                        connectionsSimplified++;
                        finished = false;
                    }
                }
            }
            if (verbose) Console.WriteLine($"Simplified {connectionsSimplified} connections. {valves.Count} nodes remaining.");

            foreach (Node valve in valves.Values)
            {
                valve.BreadthFirstSearch(valve, 0);
            }
            if (verbose) Console.WriteLine($"Calculated depths.");

            if (verbose)
            {
                List<string> newLines = new();
                foreach (Node valve in valves.Values)
                {
                    List<string> connectionStrings = new();
                    foreach (KeyValuePair<Node, int> entry in valve.distanceToNode)
                    {
                        connectionStrings.Add($"{entry.Key.id}{entry.Value}");
                    }
                    newLines.Add($"Valve {valve.id} has flow rate={valve.flowRate}; tunnels lead to valves {string.Join(", ", connectionStrings)}");
                }
                Console.WriteLine($"Optimized input:");
                Console.WriteLine(string.Join("\r\n", newLines));
                Console.WriteLine($" --- ");
            }

            return valves;
        }


        public class GamestateIterator
        {
            public Task[] tasks;

            public Gamestate bestGame;

            public GamestateIterator(Gamestate starterGame, Comparer<Gamestate> comparer, bool verbose = false)
            {
                bestGame = starterGame;

                List<Node> choices = starterGame.GetChoices();
                tasks = new Task[choices.Count];
                for (int i = 0; i < choices.Count; i++)
                {
                    Node choice = choices[i];
                    Gamestate fork = new(starterGame, choice);
                    SortedSet<Gamestate> pending = new(comparer) { fork };

                    tasks[i] = new Task(() => GameTreeSearch(pending, this, verbose));
                }
            }

            public void Start()
            {
                foreach (Task task in tasks)
                {
                    task.Start();
                }
            }

            public static void GameTreeSearch(SortedSet<Gamestate> pending, GamestateIterator parent, bool verbose = false)
            {
                while (pending.Count > 0)
                {
                    Gamestate? game = pending.Min;
                    if (game == null) { break; }

                    pending.Remove(game);

                    game.TakeTurn();

                    if (parent.bestGame.score > 0)
                    {
                        if (!game.CanBeat(parent.bestGame))
                        {
                            continue;
                        }
                    }

                    game.AddChildren(pending);

                    if (game.IsFinished())
                    {
                        if (parent.bestGame == null || parent.bestGame.score < game.score)
                        {
                            parent.bestGame = game;
                            if (verbose) Console.WriteLine($"New high score!! {parent.bestGame.score} - {parent.bestGame}");
                        }
                    }
                }
            }

            public override string? ToString()
            {
                return $"{bestGame.score} - {bestGame}";
            }
        }

        public class Player
        {
            public Node currNode;
            public int initialTime;
            public int timeLeft;
            public Gamestate game;

            public Player(Node currNode, int timeLeft, Gamestate game)
            {
                this.currNode = currNode;
                this.initialTime = timeLeft;
                this.timeLeft = timeLeft;
                this.game = game;
            }

            public void TakeTurn(Node node, bool verbose = false)
            {
                game.sequence += $"{node.id},";
                if (node == stopNode)
                {
                    if (verbose)
                    {
                        Console.WriteLine($"I took the whammy. I am dead. Goodbye.");
                    }
                    game.sequence += " / ";
                    game.players.Remove(this);
                    return;
                }
                timeLeft -= node.GetCost(currNode);
                game.score += node.GetScore(timeLeft);
                currNode = node;
                game.nodesLeft.Remove(node);

                if (verbose)
                    Console.WriteLine($"I am now at {node.id}. The minute is {startingTime - timeLeft}, just got {node.GetScore(timeLeft)} score ({node.flowRate}*{timeLeft})!");
            }

            public bool CanAfford(Node node)
            {
                return node.GetCost(currNode) <= timeLeft;
            }
            public override string? ToString()
            {
                return $"{timeLeft}m left - @{currNode.id}";
            }
        }

        public class Gamestate
        {
            public int score = 0;
            public List<Node> nodesLeft;
            public List<Player> players;
            public string sequence;
            public Node? choice;

            public static Comparer<Gamestate> comparer = Comparer<Gamestate>.Create((a, b) => { return Gamestate.CompareGames(a, b); });

            public Gamestate(int score, List<Node> nodesLeft, string sequence)
            {
                this.score = score;
                this.nodesLeft = nodesLeft;
                this.sequence = sequence;
                players = new();
            }

            public Gamestate(Gamestate original, Node? choice = null)
            {
                this.score = original.score;
                this.players = original.players.ToList(); //make sure we are cloning it, not making a reference
                this.nodesLeft = original.nodesLeft.ToList(); //make sure we are cloning it, not making a reference
                this.sequence = original.sequence;
                if (choice != null)
                {
                    this.choice = choice;
                }
                else
                {
                    this.choice = original.choice;
                }
            }

            public void TakeTurn()
            {
                if (choice == null)
                {
                    throw new Exception("Tried to take our turn without a choice!");
                }
                Player oldPlayer = players[0];
                Player newPlayer = new(oldPlayer.currNode, oldPlayer.timeLeft, this); //cloning this player before we do any mutations to it, since other games might reference it
                players[0] = newPlayer;
                newPlayer.TakeTurn(choice);
            }

            public List<Node> GetChoices()
            {
                while (players.Count > 0)
                {
                    Player player = players.First();
                    List<Node> playerChoices = GetChoicesForPlayer(player);
                    if (playerChoices.Count == 0)
                    {
                        players.Remove(player);
                        continue;
                    }
                    return playerChoices;
                }
                return new();
            }

            public void AddChildren(SortedSet<Gamestate> unfinishedGames)
            {
                foreach (Node choice in GetChoices())
                {
                    Gamestate newGame = new Gamestate(this);
                    newGame.choice = choice;
                    unfinishedGames.Add(newGame);
                }
            }

            /// <summary>
            /// Get the valid choices for a player. This means all unvisited nodes, except the ones that are too far away for our player to be able to use.
            /// Note that the cost for a node is the distance + 1, since it takes 1 turn to open a valve.
            /// </summary>
            /// <param name="player">The player to check.</param>
            /// <returns>A List of Nodes representing the nodes that the player can make use of.</returns>
            public List<Node> GetChoicesForPlayer(Player player)
            {
                List<Node> choices = new();
                foreach (Node node in nodesLeft)
                {
                    if (player.CanAfford(node))
                    {
                        choices.Add(node);
                    }
                }
                if (players.Count > 1 && player.timeLeft < player.initialTime)
                {
                    choices.Add(stopNode); //When we have more than 1 player, we let the first players stop prematurely.
                }
                return choices;
            }

            public bool IsFinished()
            {
                return players.Count == 0;
            }

            /// <summary>
            /// Naive heuristic to rule out non-viable games.
            /// Assume that each player could split themselves into an infinite number of copies, and all remaining valves were immediately opened by their nearest copy.
            /// If even this wildly unrealistic scenario can't beat the best game, then we have literally no chance.
            /// This is, of course, overly optimistic. But it's also (relatively) cheap to compute, requiring no recursion, and it helps us filter out tens of thousands of dead ends.
            /// </summary>
            public bool CanBeat(Gamestate bestgame)
            {
                int utopicScore = score;
                foreach (Node node in nodesLeft)
                {
                    int maxScore = 0;
                    foreach (Player player in players)
                    {
                        int cost = node.GetCost(player.currNode);
                        int time = player.timeLeft - cost;
                        int currPlayerScore = node.GetScore(time);
                        maxScore = Math.Max(maxScore, currPlayerScore);
                    }
                    utopicScore += maxScore;
                    if (utopicScore > bestgame.score)
                    {
                        return true;
                    }
                }
                return utopicScore > bestgame.score;
            }

            public static int CompareGames(Gamestate a, Gamestate b)
            {
                // Apparently removing an item from a sortedset makes it compare with itself? idk
                if (Object.ReferenceEquals(a, b))
                {
                    return 0;
                }

                if (a.score > b.score) return -1; //Better score is better
                if (a.score < b.score) return 1;

                int timeA = a.TimeRemaining();
                int timeB = b.TimeRemaining();
                if (timeA < timeB) return -1; //Older games are better
                if (timeB > timeA) return 1;

                return -1; //Otherwise, they are different but equally good
            }

            public int TimeRemaining()
            {
                int output = 0;
                foreach (Player player in players)
                {
                    output += player.timeLeft;
                }
                return output;
            }

            public override string ToString()
            {
                string output = string.Join(",", sequence);
                if (!IsFinished() && choice != null)
                {
                    output += $" -> {choice.id}";
                }
                return output;
            }
        }

        public class Node
        {
            public string id;
            public int flowRate;
            public Dictionary<Node, Connection> connections = new();
            public Dictionary<Node, int> distanceToNode = new();

            public Node(string id, int flowRate)
            {
                this.id = id;
                this.flowRate = flowRate;
            }

            public int GetScore(int timeLeft)
            {
                return flowRate * (timeLeft);
            }

            public int GetCost(Node node)
            {
                return distanceToNode[node] + 1; //+1 for the time it would take to open it!
            }

            public bool Simplify(Dictionary<string, Node> valves, List<Connection> tunnels)
            {
                if (connections.Count < 2)
                {
                    Delete(valves, tunnels);
                    return true;
                }
                else if (connections.Count == 2)
                {
                    List<Connection> connectionsMade = new();
                    for (int i = 0; i < connections.Keys.Count; i++)
                    {
                        Node myReplacement = connections.Keys.ToArray()[i];
                        List<Node> affectedNodes = connections.Keys.Skip(i + 1).ToList();
                        foreach (Node node in affectedNodes)
                        {
                            Connection connectionA = connections[myReplacement];
                            Connection connectionB = connections[node];
                            int costSum = connectionA.cost + connectionB.cost;
                            Connection newConnection = new Connection(myReplacement, node, costSum);
                            tunnels.Add(newConnection);
                            connectionsMade.Add(newConnection);
                        }
                    }
                    //Console.WriteLine($"Simplifying {this} with {connectionsMade.Count} new connection{(connectionsMade.Count > 1 ? 's' : null)}: {string.Join(", ", connectionsMade)}");
                    Delete(valves, tunnels);
                    /*foreach (Connection c in tunnels)
                    {
                        Console.WriteLine($"{c.nodeA.id} {c.nodeB.id} {c.cost}");
                    }*/
                    return true;
                }
                else
                {
                    return false; //I wasn't able to get this working satisfactorily, and in the end, realized that I didn't need it to begin with.
                }
            }

            //Recursive function used to find how far away the other nodes are.
            public void BreadthFirstSearch(Node requester, int depth)
            {
                List<Connection> newDiscoveries = new();
                foreach (KeyValuePair<Node, Connection> entry in connections)
                {
                    if (!requester.distanceToNode.ContainsKey(entry.Key))
                    {
                        requester.distanceToNode.Add(entry.Key, depth + entry.Value.cost);
                        newDiscoveries.Add(entry.Value);
                    }
                }
                foreach (Connection c in newDiscoveries)
                {
                    c.GetPartner(this).BreadthFirstSearch(requester, depth + c.cost);
                }
            }

            public void Delete(Dictionary<string, Node> valves, List<Connection> tunnels)
            {
                valves.Remove(id); //Goodbye cruel world!
                foreach (Connection c in connections.Values)
                {
                    c.Delete(tunnels);
                }
            }

            public override string ToString()
            {
                List<string> connectionsString = new();
                foreach (Node node in connections.Keys)
                {
                    connectionsString.Add($"{node.id}{connections[node].cost}");
                }
                return $"{id} {flowRate} [{string.Join(", ", connectionsString)}]";
            }
        }

        public class Connection
        {
            public Node nodeA;
            public Node nodeB;
            public int cost;

            public Connection(Node nodeA, Node nodeB, int cost)
            {
                this.nodeA = nodeA;
                this.nodeB = nodeB;
                this.cost = cost;

                nodeA.connections[nodeB] = this;
                nodeB.connections[nodeA] = this;
            }
            public void Delete(List<Connection> tunnels)
            {
                nodeA.connections.Remove(nodeB);
                nodeB.connections.Remove(nodeA);
                tunnels.Remove(this);
            }
            public Node GetPartner(Node node)
            {
                if (node == nodeA)
                {
                    return nodeB;
                }
                else if (node == nodeB)
                {
                    return nodeA;
                }
                else
                {
                    throw new ArgumentException(node.ToString());
                }
            }
            public override string ToString()
            {
                return $"{nodeA.id} -> {nodeB.id} ({cost})";
            }
        }
    }
}
