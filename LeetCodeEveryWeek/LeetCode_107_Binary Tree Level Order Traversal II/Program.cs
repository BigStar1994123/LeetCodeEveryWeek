using System;
using System.Collections.Generic;

namespace LeetCode_107_Binary_Tree_Level_Order_Traversal_II
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
            var list = s.LevelOrderBottom(a);
        }

        // Definition for a binary tree node.
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

        public class Solution
        {
            public IList<IList<int>> LevelOrderBottom(TreeNode root)
            {
                if (root == null)
                    return new List<IList<int>>();

                var result = new List<IList<int>>();
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    var data = new List<int>();
                    var queueSize = queue.Count;
                    for (int i = 0; i < queueSize; i++)
                    {
                        var node = queue.Dequeue();
                        data.Add(node.val);

                        if (node.left != null)
                            queue.Enqueue(node.left);
                        if (node.right != null)
                            queue.Enqueue(node.right);
                    }

                    result.Add(data);
                }

                result.Reverse();
                return result;
            }
        }
    }
}