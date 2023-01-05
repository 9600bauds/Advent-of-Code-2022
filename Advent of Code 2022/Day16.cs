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
            (Dictionary<string, Node> valves, List<Connection> tunnels) = ProcessInput(input, true);

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

            Console.WriteLine($"=== GAME ONE ===");
            Console.WriteLine($"=== One player, no elephants ===");
            Gamestate starterGame = new Gamestate(0, allChoices.ToList(), "");
            starterGame.players.Add(new Player(starterValve, startingTime, starterGame));

            GamestateIterator iterator = new(starterGame, Gamestate.comparer);
            iterator.DepthFirstSearch();

            Console.WriteLine($"=== GAME TWO ===");
            Console.WriteLine($"=== One player, one elephant ===");

            Gamestate gameTwo = new Gamestate(0, allChoices.ToList(), "");
            gameTwo.players.Add(new Player(starterValve, startingTime - elephantTrainingDelay, gameTwo));
            gameTwo.players.Add(new Player(starterValve, startingTime - elephantTrainingDelay, gameTwo));

            GamestateIterator iteratorTwo = new(gameTwo, Gamestate.comparer);
            iteratorTwo.DepthFirstSearch();
        }

        public static (Dictionary<string, Node>, List<Connection>) ProcessInput(string input, bool verbose = false)
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
            }

            return (valves, tunnels);
        }

        public class GamestateIterator
        {
            public SortedSet<Gamestate> unfinishedGames;
            public Gamestate bestGame;

            public GamestateIterator(Gamestate starterGame, Comparer<Gamestate> comparer)
            {
                unfinishedGames = new(comparer);
                starterGame.AddChildren(unfinishedGames);
                bestGame = starterGame;
            }

            public void DepthFirstSearch()
            {
                while (unfinishedGames.Count > 0)
                {
                    Gamestate? game = unfinishedGames.Min; //For some reason this is 50x faster than unfinishedGames.First() even though the result is basically the same?
                    if (game == null) { break; }

                    unfinishedGames.Remove(game);

                    game.TakeTurn();

                    if (bestGame.score > 0)
                    {
                        if (!game.CanBeat(bestGame))
                        {
                            continue;
                        }
                    }

                    if (game.IsFinished())
                    {
                        if (bestGame == null || bestGame.score < game.score)
                        {
                            bestGame = game;
                            Console.WriteLine($"New high score!! {bestGame.score} - {bestGame}");
                        }
                    }
                    else
                    {
                        game.AddChildren(unfinishedGames);
                    }
                }
            }

        }

        public class Player
        {
            public Node currNode;
            public int timeLeft;
            public Gamestate game;

            public Player(Node currNode, int timeLeft, Gamestate game)
            {
                this.currNode = currNode;
                this.timeLeft = timeLeft;
                this.game = game;
            }

            public Player(Player original)
            {
                this.currNode = original.currNode;
                this.timeLeft = original.timeLeft;
                this.game = original.game;
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
                    GameOver();
                    return;
                }
                timeLeft -= node.GetCost(currNode);
                game.score += node.GetScore(timeLeft);
                currNode = node;
                game.nodesLeft.Remove(node);

                if (verbose)
                    Console.WriteLine($"I am now at {node.id}. The minute is {startingTime - timeLeft}, just got {node.GetScore(timeLeft)} score ({node.flowRate}*{timeLeft})");

                if(timeLeft == 0 || game.GetChoicesForPlayer(this).Count == 0)
                {
                    GameOver();
                }
            }

            public void GameOver()
            {
                game.players.Remove(this);
                game.sequence += " / ";
            }

            public bool CanAfford(Node node)
            {
                return node.GetCost(currNode) <= timeLeft;
            }
        }

        public class Gamestate
        {
            public int score = 0;
            public List<Node> nodesLeft = new();
            public List<Player> players = new();
            public string sequence = "";
            public Node? choice;
            public static Comparer<Gamestate> comparer = Comparer<Gamestate>.Create((a, b) => { return Gamestate.CompareGames(a, b); });

            public Gamestate(int score, List<Node> nodesLeft, string sequence)
            {
                this.score = score;
                this.nodesLeft = nodesLeft;
                this.sequence = sequence;
            }

            public Gamestate(Gamestate original)
            {
                this.score = original.score;
                this.players = original.players.ToList(); //make sure we are cloning it, not making a reference
                this.nodesLeft = original.nodesLeft.ToList(); //make sure we are cloning it, not making a reference
                this.sequence = original.sequence;
            }

            public void TakeTurn()
            {
                if(choice == null)
                {
                    throw new Exception("Tried to take our turn without a choice!");
                }
                Player oldPlayer = players[0];
                Player newPlayer = new(oldPlayer.currNode, oldPlayer.timeLeft, this); //cloning this player before we do any mutations to it, since other games might reference it
                players[0] = newPlayer; 
                newPlayer.TakeTurn(choice);
            }

            public void AddChildren(SortedSet<Gamestate> unfinishedGames)
            {
                Player player = players.First();
                List<Node> choices = GetChoicesForPlayer(player);
                foreach (Node choice in choices)
                {
                    Gamestate newGame = new Gamestate(this);
                    newGame.choice = choice;
                    unfinishedGames.Add(newGame);
                }
            }

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
                if (players.Count > 1 && choices.Count > 0)
                {
                    choices.Add(stopNode); //When we have more than 1 player, we let the first players stop prematurely.
                }
                return choices;
            }

            public bool IsFinished()
            {
                return players.Count == 0;
            }

            public bool CanBeat(Gamestate bestgame)
            {
                return true;
            }

            public int TimeRemaining()
            {
                int output = 0;
                foreach(Player player in players)
                {
                    output += player.timeLeft;
                }
                return output;
            }

            public int NaiveMaxScore()
            {
                int time = TimeRemaining();
                int output = 0;
                foreach(Node node in nodesLeft)
                {
                    output += node.GetScore(time);
                }
                return output;
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

            public override string ToString()
            {
                return $"{string.Join(",", sequence)}";
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
                else if(node == nodeB)
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
