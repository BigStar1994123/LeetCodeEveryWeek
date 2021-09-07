using System;

namespace LeetCode_235_Lowest_Common_Ancestor_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(6);
            var b = new TreeNode(2);
            var c = new TreeNode(8);
            a.left = b;
            a.right = c;

            //var d = new TreeNode(2);
            //b.left = null;
            //b.right = d;

            var s = new Solution();
            var r = s.LowestCommonAncestor(a, b, c);
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

        public class Solution2
        {
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
            {
                if (root == null)
                {
                    return root;
                }

                if (root.val > p.val && root.val > q.val)
                {
                    var left = LowestCommonAncestor(root.left, p, q);
                    if (left != null)
                    {
                        return left;
                    }
                }

                if (root.val < p.val && root.val < q.val)
                {
                    var right = LowestCommonAncestor(root.right, p, q);
                    if (right != null)
                    {
                        return right;
                    }
                }

                return root;
            }
        }

        public class Solution
        {
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
            {
                // 如果從root開始判斷的話，就可以分成幾種情況：
                // 1.root的値和p或q的值相等 => 直接回傳root(p或q就是L)
                // 2.root的値在p和q的值的範圍之內 => 直接回傳root
                // (即p.val < L.val < q.val或p.val > L.val > q.val)
                // 3.p和q的値都小於root的值 => 往下找root.left的狀況遞迴
                // 4.p和q的値都大於root的值 => 往下找root.right的狀況遞迴

                if (root.val == p.val || root.val == q.val)
                {
                    return root;
                }

                if (root.val < p.val && root.val > q.val)
                {
                    return root;
                }
                else if (root.val > p.val && root.val < q.val)
                {
                    return root;
                }
                else if (root.val > p.val && root.val > q.val)
                {
                    return LowestCommonAncestor(root.left, p, q);
                }
                else
                {
                    return LowestCommonAncestor(root.right, p, q);
                }
            }
        }
    }
}