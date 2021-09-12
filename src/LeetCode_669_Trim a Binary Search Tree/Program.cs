using System;

namespace LeetCode_669_Trim_a_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var root = new TreeNode(3, new TreeNode(0, new TreeNode(-1), new TreeNode(2, new TreeNode(1))), new TreeNode(4));

            var s = new Solution();
            var result = s.TrimBST(root, 1, 3);
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
            public TreeNode TrimBST(TreeNode root, int low, int high)
            {
                if (root == null)
                {
                    return root;
                }

                if (root.val < low)
                {
                    var right = TrimBST(root.right, low, high);
                    return right;
                }

                if (root.val > high)
                {
                    var left = TrimBST(root.left, low, high);
                    return left;
                }

                root.left = TrimBST(root.left, low, high);
                root.right = TrimBST(root.right, low, high);

                return root;
            }
        }
    }
}