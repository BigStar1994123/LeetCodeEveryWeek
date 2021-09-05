using System;
using System.Collections.Generic;

namespace LeetCode_102_Binary_Tree_Level_Order_Traversal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(3);
            var b = new TreeNode(9);
            var c = new TreeNode(20);
            var d = new TreeNode(15);
            var e = new TreeNode(7);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;

            var s = new Solution();
            var list = s.LevelOrder(a);
        }
    }

    public class Solution2
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var data = new List<int>();
                var queueSize = queue.Count;

                for (int i = 0; i < queueSize; i++)
                {
                    var node = queue.Dequeue();
                    if (node == null)
                        continue;
                    data.Add(node.val);
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }

                if (data.Count > 0)
                    result.Add(data);
            }

            return result;
        }
    }

    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            var result = new List<IList<int>>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var resultItem = new List<int>();
                var queueCount = queue.Count;
                for (int i = 0; i < queueCount; i++)
                {
                    var node = queue.Peek();
                    queue.Dequeue();

                    resultItem.Add(node.val);

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                result.Add(resultItem);
            }

            return result;
        }
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
}