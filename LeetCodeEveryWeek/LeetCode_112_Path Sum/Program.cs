using System;

namespace LeetCode_112_Path_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var node = new TreeNode(1, new TreeNode(2), null);

            //var node = new TreeNode(1);
            //var leftNode = new TreeNode(2);
            //node.left = leftNode;

            //var rightNode = new TreeNode(3, new TreeNode(4), null);
            //node.right = rightNode;

            var target = 1;

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
                if (root == null)
                    return false;

                return DFS(root, targetSum, 0);
            }

            private bool DFS(TreeNode node, int targetSum, int preSum)
            {
                if (node == null)
                {
                    return false;
                }

                if (node.left == null && node.right == null)
                {
                    return preSum + node.val == targetSum;
                }

                var sum = preSum + node.val;
                return DFS(node.left, targetSum, sum) || DFS(node.right, targetSum, sum);
            }
        }
    }
}