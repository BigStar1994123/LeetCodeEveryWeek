using System;

namespace LeetCode_226_Invert_Binary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(4);
            var b = new TreeNode(2);
            var c = new TreeNode(7);
            a.left = b;
            a.right = c;

            var s = new Solution();
            s.InvertTree(a);
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

        public class Solution2
        {
            public TreeNode InvertTree(TreeNode root)
            {
                if (root == null)
                {
                    return root;
                }

                var temp = InvertTree(root.left);
                root.left = InvertTree(root.right);
                root.right = temp;

                return root;
            }
        }

        public class Solution
        {
            public TreeNode InvertTree(TreeNode root)
            {
                if (root == null)
                {
                    return root;
                }

                var leftNode = InvertTree(root.left);
                var rightNode = InvertTree(root.right);

                var tempNode = leftNode;
                root.left = rightNode;
                root.right = tempNode;

                return root;
            }
        }
    }
}