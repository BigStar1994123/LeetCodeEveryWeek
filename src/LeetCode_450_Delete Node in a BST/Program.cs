using System;

namespace LeetCode_450_Delete_Node_in_a_BST
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var root = new TreeNode(5, new TreeNode(3, new TreeNode(2), new TreeNode(4)), new TreeNode(6, null, new TreeNode(7)));

            var s = new Solution();
            var result = s.DeleteNode(root, 3);
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
            // https://programmercarl.com/0450.%E5%88%A0%E9%99%A4%E4%BA%8C%E5%8F%89%E6%90%9C%E7%B4%A2%E6%A0%91%E4%B8%AD%E7%9A%84%E8%8A%82%E7%82%B9.html#%E9%80%92%E5%BD%92
            public TreeNode DeleteNode(TreeNode root, int key)
            {
                if (root == null)
                {
                    // 第一種情況，沒找到點直接返回 root
                    return root;
                }

                if (root.val == key)
                {
                    // 第二種情況，左右子樹，直接刪除節點，返回 Null

                    if (root.left == null)
                    {
                        // 第三種情況，左子樹為空，右子樹補位做刪除節點
                        return root.right;
                    }

                    if (root.right == null)
                    {
                        // 第四種情況，左子樹不為空，右子樹不為空，左子樹補位做刪除節點
                        return root.left;
                    }

                    // 第五種情況，左右子樹都不為空，將刪除節點的左子樹，放到刪除節點的右子樹的最左側
                    // 並返回刪除節點的右子樹為新的節點

                    var cur = root.right; // 找右子樹最左的節點
                    while (cur.left != null)
                    {
                        cur = cur.left;
                    }

                    cur.left = root.left; // 把要刪除的節點的左子樹，放在 cur 左子樹的位置
                    var tmp = root; // 紀錄 root 用於刪除
                    root = root.right; // 返回舊 root 的右子樹做為新的 root

                    // delete root 刪除節點釋放內存
                    return root;
                }

                if (root.val > key)
                {
                    root.left = DeleteNode(root.left, key);
                }
                if (root.val < key)
                {
                    root.right = DeleteNode(root.right, key);
                }

                return root;

                //var targetNode = GetNodeByDFS(root, key);

                //if (targetNode == null)
                //{
                //    return root;
                //}

                //while (targetNode.right != null)
                //{
                //    targetNode.val = targetNode.right.val;
                //    targetNode = targetNode.right;

                //    if (targetNode.right == null)
                //    {
                //        targetNode = (TreeNode)null;
                //        break;
                //    }
                //}

                //return root;
            }

            //private TreeNode GetNodeByDFS(TreeNode node, int key)
            //{
            //    if (node == null)
            //    {
            //        return null;
            //    }

            //    if (node.val == key)
            //    {
            //        return node;
            //    }

            //    var leftResult = GetNodeByDFS(node.left, key);
            //    return leftResult ?? GetNodeByDFS(node.right, key);
            //}
        }
    }
}