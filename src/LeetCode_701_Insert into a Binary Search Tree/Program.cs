using System;

namespace LeetCode_701_Insert_into_a_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var root = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7));

            var s = new Solution();
            var result = s.InsertIntoBST(root, 5);
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
            public TreeNode InsertIntoBST(TreeNode root, int val)
            {
                if (root == null)
                {
                    return new TreeNode(val);
                }

                var node = root;
                while (true)
                {
                    if (val < node.val)
                    {
                        if (node.left == null)
                        {
                            node.left = new TreeNode(val);
                            break;
                        }
                        else
                        {
                            node = node.left;
                        }
                    }
                    else if (val > node.val)
                    {
                        if (node.right == null)
                        {
                            node.right = new TreeNode(val);
                            break;
                        }
                        else
                        {
                            node = node.right;
                        }
                    }
                }

                return root;
            }
        }
    }
}