using System;

namespace LeetCode_98_Validate_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(3);

            b.left = a;
            b.right = c;

            var s = new Solution();
            Console.WriteLine(s.IsValidBST(b));
        }
    }

    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            return Inorder(root, null, null);
        }

        public bool Inorder(TreeNode root, int? minValue, int? maxValue)
        {
            if (root == null)
            {
                return true;
            }

            if ((minValue != null && root.val <= minValue)
               || (maxValue != null && root.val >= maxValue))
            {
                return false;
            }

            return Inorder(root.left, minValue, root.val) && Inorder(root.right, root.val, maxValue);
        }
    }

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
}