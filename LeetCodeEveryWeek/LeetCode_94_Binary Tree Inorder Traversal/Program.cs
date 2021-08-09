using System;
using System.Collections.Generic;

namespace LeetCode_94_Binary_Tree_Inorder_Traversal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var node = new TreeNode(1, new TreeNode(2), new TreeNode(3));

            var s = new Solution();
            var result = s.InorderTraversal(node);
            Console.WriteLine(string.Join(",", result));
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
            public IList<int> InorderTraversal(TreeNode root)
            {
                var result = new List<int>();
                var stack = new Stack<TreeNode>();
                var pointer = root;

                while (pointer != null || stack.Count > 0)
                {
                    if (pointer != null)
                    {
                        stack.Push(pointer);
                        pointer = pointer.left;
                    }
                    else
                    {
                        var node = stack.Pop();
                        result.Add(node.val);
                        pointer = node.right;
                    }
                }

                return result;
            }
        }
    }
}