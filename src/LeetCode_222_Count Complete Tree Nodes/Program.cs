using System;

namespace LeetCode_222_Count_Complete_Tree_Nodes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var head = new TreeNode(1,
                new TreeNode(5,
     new TreeNode(4), new TreeNode(2)), new TreeNode(7, new TreeNode(6)));

            var s = new Solution2();
            Console.WriteLine(s.CountNodes(head));
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
            public int CountNodes(TreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }

                return 1 + CountNodes(root.left) + CountNodes(root.right);
            }
        }

        /// <summary>
        /// Eddie's Version
        /// </summary>
        public class Solution2
        {
            public int CountNodes(TreeNode root)
            {
                if (root == null)
                    return 0;
                var depth = GetDepth(root);
                var lo = (int)Math.Pow(2, depth - 1);
                var hi = (int)Math.Pow(2, depth) - 1;

                while (hi != lo)
                {
                    var val = (lo + hi) / 2 + 1;
                    var node = GetNodeByVal(root, val);
                    if (node == null)
                        hi = val - 1;
                    else
                        lo = val;
                }
                return hi;
            }

            public int GetDepth(TreeNode root)
            {
                if (root == null)
                    return 0;
                return 1 + GetDepth(root.left);
            }

            public TreeNode GetNodeByVal(TreeNode root, int val)
            {
                var binaryString = Convert.ToString(val, 2);
                TreeNode result = root;
                for (int i = 1; i < binaryString.Length; i++)
                {
                    if (binaryString[i] == '0')
                        result = result.left;
                    else
                        result = result.right;
                }
                return result;
            }
        }
    }
}