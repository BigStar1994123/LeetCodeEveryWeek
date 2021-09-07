using System;

namespace LeetCode_236_Lowest_Common_Ancestor_of_a_Binary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var root = new TreeNode(3);

            var a = new TreeNode(5);
            var b = new TreeNode(1);
            root.left = a;
            root.right = b;

            var c = new TreeNode(6);
            var d = new TreeNode(2);
            a.left = c;
            a.right = d;

            var e = new TreeNode(0);
            var f = new TreeNode(8);
            b.left = e;
            b.right = f;

            var s = new Solution();
            var result = s.LowestCommonAncestor(root, 5, 1);
        }

        // Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0)
            {
                this.val = val;
            }
        }

        public class Solution
        {
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
            {
                if (root == p || root == q || root == null)
                {
                    return root;
                }

                var left = LowestCommonAncestor(root.left, p, q);
                var right = LowestCommonAncestor(root.right, p, q);

                if (left != null && right != null)
                {
                    return root;
                }

                if (left == null && right != null)
                {
                    return right;
                }
                else if (left != null && right == null)
                {
                    return left;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}