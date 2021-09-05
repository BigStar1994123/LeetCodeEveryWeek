using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode_101_Symmetric_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var head = new TreeNode(1);
            head.left = new TreeNode(2);
            head.right = new TreeNode(3);

            var s = new Solution2();
            Console.WriteLine(s.IsSymmetric(head));
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

        // Recursive 實作
        public class Solution2
        {
            public bool IsSymmetric(TreeNode root)
            {
                if (root == null)
                {
                    return true;
                }

                return Compare(root.left, root.right);
            }

            private bool Compare(TreeNode left, TreeNode right)
            {
                if (left == null && right != null)
                    return false;
                else if (left != null && right == null)
                    return false;
                else if (left == null && right == null)
                    return true;
                else if (left.val != right.val)
                    return false;

                var outside = Compare(left.left, right.right);
                var inside = Compare(left.right, right.left);
                var isSame = outside && inside;
                return isSame;
            }
        }

        // Queue 實作
        public class Solution
        {
            public bool IsSymmetric(TreeNode root)
            {
                if (root == null)
                {
                    return true;
                }

                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    var queueCount = queue.Count;

                    var list = new List<int?>();
                    for (int i = 0; i < queueCount; i++)
                    {
                        var node = queue.Dequeue();
                        if (node != null)
                        {
                            list.Add(node.val);
                            queue.Enqueue(node.left);
                            queue.Enqueue(node.right);
                        }
                        else
                        {
                            list.Add(null);
                        }
                    }

                    for (int i = 0; i < list.Count / 2; i++)
                    {
                        if (list[i] != list[list.Count - 1 - i])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }
    }
}