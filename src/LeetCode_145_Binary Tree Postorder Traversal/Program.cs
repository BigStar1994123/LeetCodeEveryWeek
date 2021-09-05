using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode_145_Binary_Tree_Postorder_Traversal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var node = new TreeNode(1, null, new TreeNode(2, new TreeNode(3), null));
            var node = new TreeNode(1, new TreeNode(2), new TreeNode(3));

            var s = new Solution2();
            var result = s.PostorderTraversal(node);
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
            public IList<int> PostorderTraversal(TreeNode root)
            {
                var result = new List<int>();

                Exec(root, result);

                return result;
            }

            private void Exec(TreeNode node, IList<int> result)
            {
                if (node == null)
                {
                    return;
                }

                Exec(node.left, result);
                Exec(node.right, result);
                result.Add(node.val);
            }
        }

        // Try using stack
        public class Solution2
        {
            public IList<int> PostorderTraversal(TreeNode root)
            {
                var result = new List<int>();
                var stack = new Stack<TreeNode>();
                stack.Push(root);

                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    if (node == null)
                        continue;

                    result.Add(node.val);

                    stack.Push(node.left);
                    stack.Push(node.right);
                }

                result.Reverse();
                return result;
            }
        }
    }
}