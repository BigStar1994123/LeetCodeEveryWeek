using System;

namespace LeetCode_700_Search_in_a_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var node = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7));
            var val = 2;

            var s = new Solution();
            var result = s.SearchBST(node, val);
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
            public TreeNode SearchBST(TreeNode root, int val)
            {
                if (root == null || root.val == val)
                {
                    return root;
                }

                var leftResult = SearchBST(root.left, val);
                var rightResult = SearchBST(root.right, val);

                return leftResult ?? rightResult;
            }
        }
    }
}