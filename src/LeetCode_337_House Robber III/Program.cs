﻿using System;

namespace LeetCode_337_House_Robber_III
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var root = new TreeNode(3);
            root.left = new TreeNode(2, null, new TreeNode(3));
            root.right = new TreeNode(3, null, new TreeNode(1));

            Console.WriteLine(s.Rob(root));
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
            public int Rob(TreeNode root)
            {
                var result = GoRob(root);
                return Math.Max(result.NoIncludeRootNodeSumValue, result.IncludeRootNodeValue);
            }

            private (int NoIncludeRootNodeSumValue, int IncludeRootNodeValue) GoRob(TreeNode node)
            {
                if (node == null)
                {
                    return (0, 0);
                }

                var leftNodeValue = GoRob(node.left);
                var rightNodeValue = GoRob(node.right);

                // 使用 root 點
                var includeRootValue = node.val + leftNodeValue.NoIncludeRootNodeSumValue + rightNodeValue.NoIncludeRootNodeSumValue;

                // 不使用 root 點
                var noIncludeRootValue = Math.Max(leftNodeValue.NoIncludeRootNodeSumValue, leftNodeValue.IncludeRootNodeValue) +
                                         Math.Max(rightNodeValue.NoIncludeRootNodeSumValue, rightNodeValue.IncludeRootNodeValue);

                return (noIncludeRootValue, includeRootValue);
            }
        }
    }
}