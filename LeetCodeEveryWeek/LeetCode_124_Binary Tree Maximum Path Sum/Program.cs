using System;

namespace LeetCode_124_Binary_Tree_Maximum_Path_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(3);

            a.left = b;
            a.right = c;

            var s = new Solution();
            Console.WriteLine(s.MaxPathSum(a));
        }
    }

    public class Solution
    {
        public int MaxPathSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var ans = int.MinValue;

            MaxPathSum(root, ref ans);
            return ans;
        }

        private int MaxPathSum(TreeNode root, ref int ans)
        {
            if (root == null)
            {
                return 0;
            }

            var left = Math.Max(0, MaxPathSum(root.left, ref ans));
            var right = Math.Max(0, MaxPathSum(root.right, ref ans));
            var sum = left + right + root.val;
            ans = Math.Max(ans, sum);

            return Math.Max(left, right) + root.val;
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