using System;

namespace LeetCode_98_Validate_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var node = new TreeNode(5, new TreeNode(4), new TreeNode(6, new TreeNode(3), new TreeNode(7)));
            //var node = new TreeNode(3, new TreeNode(1, new TreeNode(0), new TreeNode(2)), new TreeNode(5, new TreeNode(4), new TreeNode(6)));
            var node = new TreeNode(-2147483648, null, new TreeNode(2147483647));

            //var a = new TreeNode(2);
            //var b = new TreeNode(2);
            //var c = new TreeNode(2);

            //b.left = a;
            //b.right = c;

            //var node = new TreeNode(0, new TreeNode(-1));

            var s = new Solution2();
            Console.WriteLine(s.IsValidBST(node));
        }
    }

    public class Solution2
    {
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            if (root.left != null && root.right == null)
            {
                return CheckValid(root.left, null, root.val);
            }

            if (root.left == null && root.right != null)
            {
                return CheckValid(root.right, root.val, null);
            }

            return CheckValid(root.left, null, root.val) && CheckValid(root.right, root.val, null);
        }

        private bool CheckValid(TreeNode node, int? minVal, int? maxVal)
        {
            if (node == null)
            {
                return true;
            }

            if ((maxVal != null && node.val >= maxVal) ||
                (minVal != null && node.val <= minVal))
            {
                return false;
            }

            return CheckValid(node.left, minVal, node.val) && CheckValid(node.right, node.val, maxVal);
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