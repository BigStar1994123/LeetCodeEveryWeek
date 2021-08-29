using System;

namespace LeetCode_617_Merge_Two_Binary_Trees
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var aTree = new TreeNode(1, new TreeNode(3, new TreeNode(5)), new TreeNode(2));
            var bTree = new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)));

            var s = new Solution();
            var result = s.MergeTrees(aTree, bTree);
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
            public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
            {
                if (root1 != null && root2 != null)
                {
                    var result = new TreeNode(((root1?.val) ?? 0) + ((root2?.val) ?? 0))
                    {
                        left = MergeTrees(root1.left, root2.left),
                        right = MergeTrees(root1.right, root2.right)
                    };
                    return result;
                }
                else if (root1 != null && root2 == null)
                {
                    return root1;
                }
                else if (root1 == null && root2 != null)
                {
                    return root2;
                }

                return null;
            }
        }
    }
}