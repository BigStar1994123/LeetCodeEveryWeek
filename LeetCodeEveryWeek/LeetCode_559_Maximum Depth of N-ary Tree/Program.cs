using System;
using System.Collections.Generic;

namespace LeetCode_559_Maximum_Depth_of_N_ary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var head = new Node(1, new List<Node> { new Node(3, new List<Node> { new Node(5) }), new Node(2), new Node(4) });

            var s = new Solution();
            Console.WriteLine(s.MaxDepth(head));
        }

        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node()
            {
            }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public class Solution
        {
            public int MaxDepth(Node root)
            {
                if (root == null)
                {
                    return 0;
                }

                var max = 1;
                foreach (var childNode in root.children ?? new List<Node>())
                {
                    max = Math.Max(max, 1 + MaxDepth(childNode));
                }

                return max;
            }
        }
    }
}