using System;

namespace LeetCode_111_Minimum_Depth_of_Binary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(3);
            var b = new TreeNode(9);
            var c = new TreeNode(20);
            var d = new TreeNode(15);
            var e = new TreeNode(7);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;

            var s = new Solution();
            Console.WriteLine(s.MinDepth(a));
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
            public int MinDepth(TreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }

                if (root.left != null && root.right == null)
                {
                    return 1 + MinDepth(root.left);
                }
                else if (root.left == null && root.right != null)
                {
                    return 1 + MinDepth(root.right);
                }

                return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
            }
        }
    }
}