using System;

namespace LeetCode_104_Maximum_Depth_of_Binary_Tree
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

            var s = new Solution2();
            Console.WriteLine(s.MaxDepth(a));
        }
    }

    public class Solution2
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var max = 0;
            Next(root, 0, ref max);

            return max;
        }

        private void Next(TreeNode node, int curHigh, ref int maxHigh)
        {
            if (node == null)
                return;

            curHigh += 1;
            maxHigh = Math.Max(maxHigh, curHigh);

            Next(node.left, curHigh, ref maxHigh);
            Next(node.right, curHigh, ref maxHigh);
        }
    }

    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            return root == null ? 0 : (1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right)));
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