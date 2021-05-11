using System;

namespace LeetCode_105_Construct_B_Tree_Preorder_and_Inorder
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

            var preorder = new int[] { 3, 9, 20, 15, 7 };
            var inorder = new int[] { 9, 3, 15, 20, 7 };

            var s = new Solution();
            var node = s.BuildTree(preorder, inorder);
        }
    }

    public class Solution
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var n = preorder.Length;

            if (n != inorder.Length)
            {
                return null;
            }

            if (n == 0)
            {
                return null;
            }

            if (n == 1)
            {
                return new TreeNode(preorder[0]);
            }

            var node = new TreeNode(preorder[0]);
            var position = 0;

            for (int i = 0; i < inorder.Length; i++)
            {
                if (node.val == inorder[i])
                {
                    position = i;
                    break;
                }
            }

            node.left = BuildTree(CopyOfRange(preorder, 1, position + 1), CopyOfRange(inorder, 0, position));
            node.right = BuildTree(CopyOfRange(preorder, position + 1, n), CopyOfRange(inorder, position + 1, n));
            return node;
        }

        private int[] CopyOfRange(int[] src, int start, int end)
        {
            int len = end - start;
            int[] dest = new int[len];
            Array.Copy(src, start, dest, 0, len);
            return dest;
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