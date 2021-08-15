using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_429_N_ary_Tree_Level_Order_Traversal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var head = new Node(1);
            head.children = new List<Node>() { new Node(3, new List<Node> { new Node(5), new Node(6) }), new Node(2), new Node(4) };

            var s = new Solution();
            var result = s.LevelOrder(head);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item));
            }
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
            public IList<IList<int>> LevelOrder(Node root)
            {
                if (root == null)
                {
                    return new List<IList<int>>();
                }

                var result = new List<IList<int>>();
                var queue = new Queue<Node>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    var data = new List<int>();
                    var queueSize = queue.Count;

                    for (int i = 0; i < queueSize; i++)
                    {
                        var node = queue.Dequeue();
                        data.Add(node.val);

                        foreach (var childNode in node.children ?? new List<Node>())
                        {
                            queue.Enqueue(childNode);
                        }
                    }

                    result.Add(data);
                }

                return result;
            }
        }
    }
}