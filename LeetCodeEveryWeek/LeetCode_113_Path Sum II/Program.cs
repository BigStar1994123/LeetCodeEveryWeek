using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_113_Path_Sum_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var node = new TreeNode(1, new TreeNode(2), null);

            var node = new TreeNode(1);
            var leftNode = new TreeNode(2);
            node.left = leftNode;

            var rightNode = new TreeNode(3, new TreeNode(4), new TreeNode(4));
            node.right = rightNode;

            var target = 8;

            var s = new Solution();
            var result = s.PathSum(node, target);
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
            public IList<IList<int>> PathSum(TreeNode root, int targetSum)
            {
                var result = new List<IList<int>>();

                DFS(root, targetSum, 0, new List<int>(), result);

                return result;
            }

            private void DFS(TreeNode node, int targetSum, int preSum, List<int> nodeHistory, IList<IList<int>> result)
            {
                if (node == null)
                {
                    return;
                }

                nodeHistory.Add(node.val);

                if (node.left == null && node.right == null)
                {
                    if (preSum + node.val == targetSum)
                    {
                        result.Add(nodeHistory.ToList());
                    }
                }
                else
                {
                    var sum = preSum + node.val;

                    DFS(node.left, targetSum, sum, nodeHistory, result);
                    DFS(node.right, targetSum, sum, nodeHistory, result);
                }

                nodeHistory.RemoveAt(nodeHistory.Count - 1);
            }
        }
    }
}