using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_501_Find_Mode_in_Binary_Search_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(2)));

            var s = new Solution();
            var result = s.FindMode(root);
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
            public int[] FindMode(TreeNode root)
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                var result = new List<int>();

                DFS(root, map);

                var ordered = map.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value).ToList();
                result.Add(ordered[0].Key);

                for (int i = 1; i < ordered.Count; i++)
                {
                    if (ordered[i].Value == ordered[0].Value)
                    {
                        result.Add(ordered[i].Key);
                    }
                    else
                    {
                        break;
                    }
                }

                return result.ToArray();
            }

            private void DFS(TreeNode node, Dictionary<int, int> map)
            {
                if (node == null)
                {
                    return;
                }

                if (!map.ContainsKey(node.val))
                {
                    map[node.val] = 1;
                }
                else
                {
                    map[node.val]++;
                }

                DFS(node.left, map);
                DFS(node.right, map);
                return;
            }
        }
    }
}