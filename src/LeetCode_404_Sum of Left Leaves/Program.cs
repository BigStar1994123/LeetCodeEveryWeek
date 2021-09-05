using System;

namespace LeetCode_404_Sum_of_Left_Leaves
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(3);
            var leftNode = new TreeNode(9);
            a.left = leftNode;

            var rightNode = new TreeNode(20, new TreeNode(15), new TreeNode(7));
            a.right = rightNode;

            var s = new Solution();
            Console.WriteLine(s.SumOfLeftLeaves(a));
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
            public int SumOfLeftLeaves(TreeNode root)
            {
                if (root.left == null && root.right == null)
                {
                    return 0;
                }

                var sum = 0;
                DFS(root, ref sum, true);

                return sum;
            }

            private void DFS(TreeNode node, ref int sum, bool isLeft = false)
            {
                if (node == null)
                {
                    return;
                }

                if (node.left == null && node.right == null && isLeft)
                {
                    sum += node.val;
                    return;
                }

                DFS(node.left, ref sum, true);
                DFS(node.right, ref sum, false);
            }
        }
    }
}