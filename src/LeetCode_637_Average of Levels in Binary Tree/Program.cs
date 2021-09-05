using System;
using System.Collections.Generic;

namespace LeetCode_637_Average_of_Levels_in_Binary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(3);
            var b = new TreeNode(9);
            var c = new TreeNode(20);
            var d = new TreeNode(15);
            var e = new TreeNode(7);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;

            var s = new Solution();
            var list = s.AverageOfLevels(a);
            Console.WriteLine(string.Join(",", list));
        }

        public class Solution
        {
            public IList<double> AverageOfLevels(TreeNode root)
            {
                if (root == null)
                    return new List<double>();

                var result = new List<double>();
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    var queueSize = queue.Count;

                    var sum = 0d;
                    for (int i = 0; i < queueSize; i++)
                    {
                        var node = queue.Dequeue();

                        if (node.left != null)
                            queue.Enqueue(node.left);

                        if (node.right != null)
                            queue.Enqueue(node.right);

                        sum += node.val;
                    }

                    result.Add(sum / queueSize);
                }

                return result;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}