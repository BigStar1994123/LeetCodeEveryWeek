using System;
using System.Collections.Generic;

namespace LeetCode_144_Binary_Tree_Preorder_Traversal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(1, null, new TreeNode(2, new TreeNode(3), null));

            var s = new Solution();
            var result = s.PreorderTraversal(a);
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

        public class Solution
        {
            public IList<int> PreorderTraversal(TreeNode root)
            {
                var result = new List<int>();

                Exec(root, result);

                return result;
            }

            private void Exec(TreeNode node, List<int> result)
            {
                if (node == null)
                {
                    return;
                }

                result.Add(node.val);
                Exec(node.left, result);
                Exec(node.right, result);
            }
        }
    }
}