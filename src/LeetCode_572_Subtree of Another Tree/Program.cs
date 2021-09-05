using System;

namespace LeetCode_572_Subtree_of_Another_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var aTree = new TreeNode(3);
            //aTree.left = new TreeNode(4, new TreeNode(1), new TreeNode(2, new TreeNode(1), null));
            //aTree.right = new TreeNode(5);

            //var bTree = new TreeNode(4, new TreeNode(1), new TreeNode(2));

            var aTree = new TreeNode(1, new TreeNode(1), null);
            var bTree = new TreeNode(1);

            var s = new Solution();
            Console.WriteLine(s.IsSubtree(aTree, bTree));
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
            public bool IsSubtree(TreeNode root, TreeNode subRoot)
            {
                if (root == null)
                {
                    return false;
                }

                if (IsSame(root, subRoot))
                {
                    return true;
                }

                return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
            }

            private bool IsSame(TreeNode a, TreeNode b)
            {
                if (a == null && b == null)
                {
                    return true;
                }

                if ((a != null && b == null) || (a == null && b != null) || a.val != b.val)
                {
                    return false;
                }

                return IsSame(a.left, b.left) && IsSame(a.right, b.right);
            }
        }
    }
}