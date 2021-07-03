using System;
using System.Collections.Generic;

namespace LeetCode_230_Kth_Smallest_Element_in_a_BST
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var a = new TreeNode(3);
            //var b = new TreeNode(1);
            //var c = new TreeNode(4);
            //a.left = b;
            //a.right = c;

            //var d = new TreeNode(2);
            //b.left = null;
            //b.right = d;

            var a = new TreeNode(1);
            var b = new TreeNode(2);
            a.right = b;

            var s = new Solution();
            Console.WriteLine(s.KthSmallest(a, 2));
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
            private int count = 0;

            public int KthSmallest(TreeNode root, int k)
            {
                return Go(root, k).ResultValue;
            }

            public (bool IsGetVal, int ResultValue) Go(TreeNode node, int k)
            {
                var stack = new Stack<TreeNode>();

                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }

                while (stack.TryPop(out var popNode))
                {
                    count++;
                    if (count == k)
                    {
                        return (true, popNode.val);
                    }

                    var result = Go(popNode.right, k);
                    if (result.IsGetVal)
                    {
                        return (true, result.ResultValue);
                    }
                }

                return (false, 0);
            }
        }
    }
}