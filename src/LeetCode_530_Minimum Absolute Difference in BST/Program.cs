using System;

namespace LeetCode_530_Minimum_Absolute_Difference_in_BST
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // [236,104,701,null,227,null,911]

            //var node = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(6));
            var node = new TreeNode(236, new TreeNode(104, null, new TreeNode(227)), new TreeNode(701, null, new TreeNode(911)));

            var s = new Solution();
            Console.WriteLine(s.GetMinimumDifference(node));
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
            private TreeNode preNode;
            private int result = int.MaxValue;

            public int GetMinimumDifference(TreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }

                Traversal(root);
                return result;
            }

            private void Traversal(TreeNode node)
            {
                if (node == null)
                {
                    return;
                }

                // Left
                Traversal(node.left);

                // Mid
                if (preNode != null)
                {
                    result = Math.Min(result, node.val - preNode.val);
                }

                preNode = node;

                // Right
                Traversal(node.right);
            }
        }
    }
}