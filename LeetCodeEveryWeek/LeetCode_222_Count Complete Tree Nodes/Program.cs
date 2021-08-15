using System;

namespace LeetCode_222_Count_Complete_Tree_Nodes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var head = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6)));

            var s = new Solution();
            Console.WriteLine(s.CountNodes(head));
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
            public int CountNodes(TreeNode root)
            {
            }
        }
    }
}