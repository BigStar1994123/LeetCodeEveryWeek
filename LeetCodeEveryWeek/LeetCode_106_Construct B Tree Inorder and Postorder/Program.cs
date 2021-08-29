using System;
using System.Linq;

namespace LeetCode_106_Construct_B_Tree_Inorder_and_Postorder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var inorder = new int[] { 9, 3, 15, 20, 7 };
            //var postorder = new int[] { 9, 15, 7, 20, 3 };
            var inorder = new int[] { 1, 2 };
            var postorder = new int[] { 2, 1 };

            var s = new Solution();
            var result = s.BuildTree(inorder, postorder);
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
            public TreeNode BuildTree(int[] inorder, int[] postorder)
            {
                return Build(inorder, postorder, new TreeNode());
            }

            private TreeNode Build(int[] inorder, int[] postorder, TreeNode node)
            {
                if (inorder.Length == 0)
                {
                    return null;
                }
                else if (inorder.Length == 1)
                {
                    node.val = inorder[0];
                    return node;
                }

                var postorderLastValue = postorder[^1];
                var inorderIndex = Array.IndexOf(inorder, postorderLastValue);

                node.val = postorderLastValue;
                node.left = Build(inorder[0..inorderIndex].ToArray(), postorder[0..inorderIndex].ToArray(), new TreeNode());
                node.right = Build(inorder[(inorderIndex + 1)..].ToArray(), postorder[inorderIndex..^1].ToArray(), new TreeNode());

                return node;
            }
        }
    }
}