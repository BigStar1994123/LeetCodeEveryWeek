using System;

namespace LeetCode_968_Binary_Tree_Cameras
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var node = new TreeNode(0, new TreeNode(0, new TreeNode(0), new TreeNode(0)), null);

            var s = new Solution();
            Console.WriteLine(s.MinCameraCover(node));
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
            // Node val: 0:無覆蓋 1:有攝影機 2:有覆蓋
            private int _result = 0;

            public int MinCameraCover(TreeNode root)
            {
                _result = 0;

                // 對 root 進行判斷，如果為未覆蓋則需+1
                if (Traversal(root) == 0)
                {
                    _result++;
                }

                return _result;
            }

            private int Traversal(TreeNode node)
            {
                // 空節點，表示該節點有覆蓋
                if (node == null)
                {
                    return 2;
                }

                var left = Traversal(node.left);
                var right = Traversal(node.right);

                // 左右節點都有覆蓋，則本節點無覆蓋
                if (left == 2 && right == 2)
                {
                    return 0;
                }

                // left == 0 && right == 0 左右节点无覆盖
                // left == 1 && right == 0 左节点有摄像头，右节点无覆盖
                // left == 0 && right == 1 左节点有无覆盖，右节点摄像头
                // left == 0 && right == 2 左节点无覆盖，右节点覆盖
                // left == 2 && right == 0 左节点覆盖，右节点无覆盖
                if (left == 0 || right == 0)
                {
                    _result++;
                    return 1;
                }

                // left == 1 && right == 2 左节点有摄像头，右节点有覆盖
                // left == 2 && right == 1 左节点有覆盖，右节点有摄像头
                // left == 1 && right == 1 左右节点都有摄像头
                if (left == 1 || right == 1)
                {
                    return 2;
                }

                // 正常情況下邏輯不會走到 -1 這裡
                return -1;
            }
        }
    }
}