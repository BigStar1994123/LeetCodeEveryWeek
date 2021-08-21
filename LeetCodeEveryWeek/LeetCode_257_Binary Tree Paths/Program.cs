using System;
using System.Collections.Generic;

namespace LeetCode_257_Binary_Tree_Paths
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(1);
            var leftNode = new TreeNode(2, null, new TreeNode(5));
            a.left = leftNode;

            var rightNode = new TreeNode(3);
            a.right = rightNode;

            var s = new Solution();
            var result = s.BinaryTreePaths(a);
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
            public IList<string> BinaryTreePaths(TreeNode root)
            {
                var result = new List<string>();

                Go(root, result, new List<int>());

                return result;
            }

            private void Go(TreeNode node, IList<string> result, IList<int> nodeHistory)
            {
                if (node == null)
                {
                    return;
                }

                nodeHistory.Add(node.val);

                if (node.left == null && node.right == null)
                {
                    result.Add(string.Join("->", nodeHistory));
                    nodeHistory.RemoveAt(nodeHistory.Count - 1);
                    return;
                }

                Go(node.left, result, nodeHistory);
                Go(node.right, result, nodeHistory);

                nodeHistory.RemoveAt(nodeHistory.Count - 1);
            }
        }
    }
}