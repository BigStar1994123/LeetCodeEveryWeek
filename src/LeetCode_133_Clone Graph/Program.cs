using System;
using System.Collections.Generic;

namespace LeetCode_133_Clone_Graph
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Solution
        {
            public Node CloneGraph(Node node)
            {
                if (node == null)
                {
                    return null;
                }

                var map = new Dictionary<Node, Node>();
                return DFS(node, map);
            }

            public Node DFS(Node node, Dictionary<Node, Node> map)
            {
                if (map.ContainsKey(node))
                {
                    return map[node];
                }

                map.Add(node, new Node(node.val));
                var clone = map[node];

                foreach (var neighborNode in node.neighbors)
                {
                    clone.neighbors.Add(DFS(neighborNode, map));
                }

                return clone;
            }
        }

        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
    }
}