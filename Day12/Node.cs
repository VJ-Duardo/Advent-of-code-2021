using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc.Day12
{
    class Node
    {
        private string name;
        private bool smallCave;
        private List<Node> connections;

        public Node(string name)
        {
            this.Name = name;
            this.Connections = new();

            this.SmallCave = name.Any(Char.IsLower);
        }

        public bool SmallCave { get => smallCave; set => smallCave = value; }
        public string Name { get => name; set => name = value; }
        internal List<Node> Connections { get => connections; set => connections = value; }

        public void AddConnection(Node n)
        {
            this.Connections.Add(n);
        }
    }
}
