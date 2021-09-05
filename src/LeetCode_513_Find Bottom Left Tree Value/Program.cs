using System;
using System.Collections.Generic;

namespace LeetCode_513_Find_Bottom_Left_Tree_Value
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var node = new TreeNode(1);
            var leftNode = new TreeNode(2);
            node.left = leftNode;

            var rightNode = new TreeNode(3, new TreeNode(4));
            node.right = rightNode;

            var s = new Solution();
            Console.WriteLine(s.FindBottomLeftValue(node));
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
            public int FindBottomLeftValue(TreeNode root)
            {
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                var rem = 0;
                while (queue.Count > 0)
                {
                    var queueSize = queue.Count;

                    for (int i = 0; i < queueSize; i++)
                    {
                        var node = queue.Dequeue();

                        if (i == 0)
                        {
                            rem = node.val;
                        }

                        if (node.left != null)
                            queue.Enqueue(node.left);

                        if (node.right != null)
                            queue.Enqueue(node.right);
                    }
                }

                return rem;
            }
        }
    }
}