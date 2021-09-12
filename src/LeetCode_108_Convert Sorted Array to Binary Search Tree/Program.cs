using System;
using System.Linq;

namespace LeetCode_108_Convert_Sorted_Array_to_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var list = new int[] { -10, -3, 0, 5, 9 };

            var s = new Solution();
            var result = s.SortedArrayToBST(list);
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
            public TreeNode SortedArrayToBST(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return null;
                }

                var mid = nums.Length / 2;
                var node = new TreeNode(nums[mid]);

                node.left = SortedArrayToBST(nums.Take(mid).ToArray());
                node.right = SortedArrayToBST(nums[(mid + 1)..].ToArray());

                return node;
            }
        }
    }
}