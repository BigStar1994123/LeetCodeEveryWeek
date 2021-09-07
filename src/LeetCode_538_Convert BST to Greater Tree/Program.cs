using System;

namespace LeetCode_538_Convert_BST_to_Greater_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var root = new TreeNode(4, new TreeNode(1), new TreeNode(6));

            var s = new Solution();
            var result = s.ConvertBST(root);
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
            private int preValue;

            public TreeNode ConvertBST(TreeNode root)
            {
                preValue = 0;
                Traversal(root);
                return root;
            }

            private void Traversal(TreeNode node)
            {
                if (node == null)
                {
                    return;
                }

                Traversal(node.right); // 右

                // 中
                node.val += preValue;
                preValue = node.val;

                // 左
                Traversal(node.left);
            }
        }
    }
}