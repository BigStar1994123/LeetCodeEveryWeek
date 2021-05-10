using System;

namespace LeetCode_100_Same_Tree
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

            var d = new TreeNode(1);
            var e = new TreeNode(2);
            var f = new TreeNode(3);

            e.left = d;
            e.right = f;

            var s = new Solution();
            Console.WriteLine(s.IsSameTree(b, e));
        }
    }

    public class Solution
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null && q != null)
            {
                return false;
            }

            if (p != null && q == null)
            {
                return false;
            }

            if (p.val != q.val)
            {
                return false;
            }

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
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