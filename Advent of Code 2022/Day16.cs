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

        static Regex parsingRegex = new Regex(@"Valve (?<valveId>\w+) has flow rate=(?<flowRate>[0-9\-]+)\; \w+ \w+ to \w+ (?<tunnels>.+)");

        static Dictionary<string, Node> valves = new();
        static List<Connection> tunnels = new();

        public static void Run()
        {
            string input = "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB\r\nValve BB has flow rate=13; tunnels lead to valves CC, AA\r\nValve CC has flow rate=2; tunnels lead to valves DD, BB\r\nValve DD has flow rate=20; tunnels lead to valves CC, AA, EE\r\nValve EE has flow rate=3; tunnels lead to valves FF, DD\r\nValve FF has flow rate=0; tunnels lead to valves EE, GG\r\nValve GG has flow rate=0; tunnels lead to valves FF, HH\r\nValve HH has flow rate=22; tunnel leads to valve GG\r\nValve II has flow rate=0; tunnels lead to valves AA, JJ\r\nValve JJ has flow rate=21; tunnel leads to valve II";
            //string input = "Valve OQ has flow rate=17; tunnels lead to valves NB, AK, KL\r\nValve HP has flow rate=0; tunnels lead to valves ZX, KQ\r\nValve GO has flow rate=0; tunnels lead to valves HR, GW\r\nValve PD has flow rate=9; tunnels lead to valves XN, EV, QE, MW\r\nValve NQ has flow rate=0; tunnels lead to valves HX, ZX\r\nValve DW has flow rate=0; tunnels lead to valves IR, WE\r\nValve TN has flow rate=24; tunnels lead to valves KL, EI\r\nValve JJ has flow rate=0; tunnels lead to valves EV, HR\r\nValve KH has flow rate=0; tunnels lead to valves ZQ, AA\r\nValve PH has flow rate=0; tunnels lead to valves FN, QE\r\nValve FD has flow rate=0; tunnels lead to valves SM, HX\r\nValve SM has flow rate=7; tunnels lead to valves WW, RZ, FD, HO, KQ\r\nValve PU has flow rate=0; tunnels lead to valves VL, IR\r\nValve OM has flow rate=0; tunnels lead to valves CM, AA\r\nValve KX has flow rate=20; tunnel leads to valve PC\r\nValve IR has flow rate=3; tunnels lead to valves PU, CM, WW, DW, AF\r\nValve XG has flow rate=0; tunnels lead to valves RX, OF\r\nValve QE has flow rate=0; tunnels lead to valves PH, PD\r\nValve GW has flow rate=0; tunnels lead to valves JQ, GO\r\nValve HO has flow rate=0; tunnels lead to valves SM, TY\r\nValve WU has flow rate=0; tunnels lead to valves SG, RZ\r\nValve MS has flow rate=0; tunnels lead to valves UE, OF\r\nValve JS has flow rate=0; tunnels lead to valves DO, ZX\r\nValve YQ has flow rate=0; tunnels lead to valves BC, SG\r\nValve EJ has flow rate=0; tunnels lead to valves AA, LR\r\nValve EI has flow rate=0; tunnels lead to valves BV, TN\r\nValve NC has flow rate=0; tunnels lead to valves TS, BC\r\nValve AF has flow rate=0; tunnels lead to valves IR, HX\r\nValve OX has flow rate=0; tunnels lead to valves HR, BV\r\nValve BF has flow rate=0; tunnels lead to valves JQ, SY\r\nValve CA has flow rate=0; tunnels lead to valves YD, HX\r\nValve KQ has flow rate=0; tunnels lead to valves HP, SM\r\nValve NB has flow rate=0; tunnels lead to valves OQ, OF\r\nValve SY has flow rate=0; tunnels lead to valves BF, BV\r\nValve AA has flow rate=0; tunnels lead to valves KH, EJ, OM, TY, DO\r\nValve BC has flow rate=11; tunnels lead to valves WE, RX, YQ, LR, NC\r\nValve HR has flow rate=14; tunnels lead to valves OX, GO, JJ\r\nValve WE has flow rate=0; tunnels lead to valves DW, BC\r\nValve MW has flow rate=0; tunnels lead to valves JQ, PD\r\nValve DO has flow rate=0; tunnels lead to valves JS, AA\r\nValve PC has flow rate=0; tunnels lead to valves AK, KX\r\nValve YD has flow rate=0; tunnels lead to valves CA, OF\r\nValve RX has flow rate=0; tunnels lead to valves XG, BC\r\nValve CM has flow rate=0; tunnels lead to valves IR, OM\r\nValve HX has flow rate=6; tunnels lead to valves ZQ, NQ, AF, FD, CA\r\nValve ZQ has flow rate=0; tunnels lead to valves KH, HX\r\nValve BV has flow rate=21; tunnels lead to valves SY, OX, EI\r\nValve AK has flow rate=0; tunnels lead to valves PC, OQ\r\nValve UE has flow rate=0; tunnels lead to valves MS, JQ\r\nValve LR has flow rate=0; tunnels lead to valves BC, EJ\r\nValve JQ has flow rate=8; tunnels lead to valves MW, UE, BF, GW\r\nValve VL has flow rate=0; tunnels lead to valves PU, ZX\r\nValve EV has flow rate=0; tunnels lead to valves JJ, PD\r\nValve TS has flow rate=0; tunnels lead to valves NC, ZX\r\nValve RZ has flow rate=0; tunnels lead to valves SM, WU\r\nValve OF has flow rate=13; tunnels lead to valves XG, YD, NB, MS, XN\r\nValve WW has flow rate=0; tunnels lead to valves SM, IR\r\nValve TY has flow rate=0; tunnels lead to valves HO, AA\r\nValve XN has flow rate=0; tunnels lead to valves OF, PD\r\nValve SG has flow rate=15; tunnels lead to valves WU, YQ\r\nValve FN has flow rate=25; tunnel leads to valve PH\r\nValve KL has flow rate=0; tunnels lead to valves TN, OQ\r\nValve ZX has flow rate=5; tunnels lead to valves JS, HP, VL, NQ, TS";

            List<string> inputByLine = input.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList(); //String.Split() only takes 1 char as delimiter. This is how you split by a string according to StackOverflow.
            Dictionary<string, string[]> tempConnections = new();
            foreach (string line in inputByLine)
            {
                Match match = parsingRegex.Match(line);
                if (match.Success)
                {
                    string valveId = match.Groups["valveId"].Value;
                    int flowRate = int.Parse(match.Groups["flowRate"].Value);
                    string[] tunnels = match.Groups["tunnels"].Value.Split(new[] { ", " }, StringSplitOptions.None);
                    valves.Add(valveId, new Node(valveId, flowRate));
                    tempConnections.Add(valveId, tunnels);
                }
                else
                {
                    Debug.Fail($"Could not parse {line}!");
                }
            }
            foreach (KeyValuePair<string, string[]> entry in tempConnections)
            {
                // do something with entry.Value or entry.Key
                Node valve = valves[entry.Key];
                foreach (string tunnel in entry.Value)
                {
                    Node to = valves[tunnel];
                    if (to.connections.ContainsKey(valve))
                    {
                        continue;
                    }
                    tunnels.Add(new Connection(valve, to, 1)); 
                }
            }

            Console.WriteLine($"Loaded {valves.Count} valves with a total of {tunnels.Count} connections.");
 


            int connectionsSimplified = 0;
            bool finished = false;
            while (finished == false)
            {
                finished = true;
                for (int i = 0; i < valves.Values.Count; i++)
                {
                    Node valve = valves.Values.ToList()[i];
                    if(valve.value > 0)
                    {
                        continue;
                    }
                    bool success = valve.Simplify();
                    if (success)
                    {
                        connectionsSimplified++;
                        finished = false;
                    }
                }
            }
            Console.WriteLine($"Simplified {connectionsSimplified} connections. {valves.Count} nodes remaining.");

            //For each sequence of things we could do, we have a few choices: Open the valve if available, or move to another room.
            //Since the order of each room is always deterministic, we can represent each choice as a number,
            //where 9 means opening a valve and N<9 means moving to the room N in our available choices.
            Node currentRoom = valves["AA"];
            for (int i = 0; i < currentRoom.connections.Count; i++)
            {

            }
        }

        class Node
        {
            public string id;
            public int value;
            public Dictionary<Node, Connection> connections = new();
            public bool open;

            public Node(string id, int value)
            {
                this.id = id;
                this.value = value;
            }

            public bool Simplify()
            {
                if (connections.Count < 2)
                {
                    Delete();
                    return true;
                }
                else
                {
                    Node myReplacement = connections.Keys.First();
                    List<Node> affectedNodes = connections.Keys.Skip(1).ToList();
                    List<Connection> connectionsMade = new();
                    foreach(Node node in affectedNodes)
                    {
                        Connection connectionA = connections[myReplacement];
                        Connection connectionB = connections[node];
                        int costSum = connectionA.cost + connectionB.cost;
                        Connection newConnection = new Connection(myReplacement, node, costSum);
                        tunnels.Add(newConnection);
                        connectionsMade.Add(newConnection);
                    }
                    Console.WriteLine($"Simplifying {this} with {connectionsMade.Count} new connection{(connectionsMade.Count > 1 ? 's' : null)}: {String.Join(", ", connectionsMade)}");
                    Delete();
                    return true; //I haven't put enough thought into this to know how it would work.
                }
            }

            public void Delete()
            {
                valves.Remove(id); //Goodbye cruel world!
                foreach(Connection c in connections.Values)
                {
                    c.Delete();
                }
            }

            public override string ToString()
            {
                List<string> connectionsString = new();
                foreach (Node node in connections.Keys)
                {
                    connectionsString.Add($"{node.id}{connections[node].cost}");
                }
                return $"{id} {value} [{String.Join(", ", connectionsString)}]";
            }
        }

        class Connection
        {
            public Node nodeA;
            public Node nodeB;
            public int cost;

            public void Delete()
            {
                nodeA.connections.Remove(nodeB);
                nodeB.connections.Remove(nodeA);
                tunnels.Remove(this);
            }

            public Connection(Node nodeA, Node nodeB, int cost)
            {
                this.nodeA = nodeA;
                this.nodeB = nodeB;
                this.cost = cost;

                nodeA.connections[nodeB] = this;
                nodeB.connections[nodeA] = this;
            }

            public override string ToString()
            {
                return $"{nodeA.id} -> {nodeB.id} ({cost})";
            }
        }
    }
}
