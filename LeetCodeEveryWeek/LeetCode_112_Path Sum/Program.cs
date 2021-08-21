using System;

namespace LeetCode_112_Path_Sum
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

            var target = 4;

            var s = new Solution();
            Console.WriteLine(s.HasPathSum(node, target));
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
            public bool HasPathSum(TreeNode root, int targetSum)
            {
                return DFS(root, 0, targetSum);
            }

            private bool DFS(TreeNode node, int targetSum, int preSum)
            {
                if (node == null)
                {
                    return false;
                }

                var sum = preSum + node.val;
                if (sum == targetSum)
                {
                    return true;
                }

                return DFS(node.left, targetSum, sum) || DFS(node.right, targetSum, sum);
            }
        }
    }
}