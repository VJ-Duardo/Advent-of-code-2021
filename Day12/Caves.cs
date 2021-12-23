using aoc.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc.Day12
{
    class Caves
    {
        static void Main()
        {
            Dictionary<string, Node> caveSystem = CreateCaveSystem(Resources.day12_input.Split("\r\n").Select(line => line.Split("-")).ToArray());
            
            int count = 0;
            GetPaths(caveSystem["start"], ref count, new List<Node>(), true);
            Console.WriteLine(count);

            count = 0;
            GetPaths(caveSystem["start"], ref count, new List<Node>(), false);
            Console.WriteLine(count);
        }


        private static Dictionary<string, Node> CreateCaveSystem(string[][] connections)
        {
            Dictionary<string, Node> caveSystem = new();

            foreach(string[] conn in connections)
            {
                Node[] nodes = new Node[2];
                for (int i=0; i < 2; i++)
                {
                    Node thisNode;
                    if (!caveSystem.TryGetValue(conn[i], out thisNode))
                    {
                        thisNode = new Node(conn[i]);
                        caveSystem.Add(conn[i], thisNode);
                    }
                    nodes[i] = thisNode;
                }
                nodes[0].AddConnection(nodes[1]);
                nodes[1].AddConnection(nodes[0]);
            }
            return caveSystem;
        }


        public static void GetPaths(Node curr, ref int count, List<Node> visited, bool doubleSmall)
        {
            visited.Add(curr);
            if (curr.Name == "end")
            {
                count++;
                return;
            }
             
            foreach(Node other in curr.Connections)
            {
                int occ = 0;
                if (other.SmallCave)
                {
                    occ = visited.Count(v => v == other);
                    if ((occ > 0 && doubleSmall) || other.Name == "start")
                    {
                        continue;
                    } 

                }
                GetPaths(other, ref count, new List<Node>(visited), doubleSmall || (other.SmallCave && (occ == 1 && !doubleSmall)));
            }
        }
    }
}
