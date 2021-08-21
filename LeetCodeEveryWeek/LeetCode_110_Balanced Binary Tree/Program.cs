using System;

namespace LeetCode_110_Balanced_Binary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var node = new TreeNode(3);
            var leftNode = new TreeNode(9);
            node.left = leftNode;

            var rightNode = new TreeNode(20, new TreeNode(15), new TreeNode(7));
            node.right = rightNode;

            var s = new Solution();
            Console.WriteLine(s.IsBalanced(node));
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
            public bool IsBalanced(TreeNode root)
            {
                var result = GetHigh(root);
                return result.balanced;
            }

            private (int high, bool balanced) GetHigh(TreeNode node)
            {
                if (node == null)
                {
                    return (0, true);
                }

                var highLeft = GetHigh(node.left);
                if (!highLeft.balanced)
                    return (0, false);

                var highRight = GetHigh(node.right);
                if (!highRight.balanced)
                    return (0, false);

                if (Math.Abs(highLeft.high - highRight.high) > 1)
                {
                    return (0, false);
                }

                var highMax = Math.Max(highLeft.high, highRight.high);
                return (1 + highMax, true);
            }
        }
    }
}