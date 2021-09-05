using System;
using System.Linq;

namespace LeetCode_654_Maximum_Binary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 3, 2, 1, 6, 0, 5 };

            var s = new Solution();
            var result = s.ConstructMaximumBinaryTree(nums);
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
            public TreeNode ConstructMaximumBinaryTree(int[] nums)
            {
                return Build(nums, new TreeNode());
            }

            private TreeNode Build(int[] nums, TreeNode node)
            {
                if (nums.Length == 0)
                {
                    return null;
                }

                var maxValue = nums.Max();
                var maxIndex = Array.IndexOf(nums, maxValue);

                node.val = maxValue;
                node.left = Build(nums.Take(maxIndex).ToArray(), new TreeNode());
                node.right = Build(nums[(maxIndex + 1)..].ToArray(), new TreeNode());

                return node;
            }
        }
    }
}