using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LeetCode_297_Serialize_and_Deserialize_Binary_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new TreeNode(1);
            var b = new TreeNode(2);
            var c = new TreeNode(3);

            a.left = b;
            a.right = c;

            var d = new TreeNode(4);
            var e = new TreeNode(5);

            c.left = d;
            c.right = e;

            var case2 = string.Join(",", Enumerable.Range(1, 1023).Select(i => i.ToString()));

            var sw = new Stopwatch();
            sw.Start();
            var s = new Codec();
            var node = s.Deserialize(case2);
            Console.WriteLine(sw.ElapsedTicks);
            var text = s.Serialize(node);
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            var sw_1 = new Stopwatch();
            sw_1.Start();
            var s_1 = new CodecEddie();
            var node_1 = s_1.deserialize(case2);
            Console.WriteLine(sw_1.ElapsedTicks);
            var text_1 = s_1.serialize(node_1);
            sw_1.Stop();
            Console.WriteLine(sw_1.ElapsedTicks);
        }
    }

    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }

        public TreeNode()
        {
        }
    }

    public class CodecEddie
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return string.Empty;
            List<string> nums = new List<string>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            PreOrder(nums, queue);

            return string.Join(",", nums);
        }

        private void PreOrder(List<string> nums, Queue<TreeNode> queue)
        {
            var count = queue.Count;
            bool isContinue = false;
            while (count > 0)
            {
                var node = queue.Dequeue();
                nums.Add(node?.val == null ? "null" : node.val.ToString());
                queue.Enqueue(node?.left);
                queue.Enqueue(node?.right);
                count--;

                if (isContinue || node?.left != null || node?.right != null)
                    isContinue = true;
            }
            if (isContinue)
                PreOrder(nums, queue);
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == string.Empty)
                return null;
            var dataArray = data.Split(',');

            Queue<TreeNode> parent = new Queue<TreeNode>();
            Queue<TreeNode> child = new Queue<TreeNode>();

            for (int i = 0; i < dataArray.Length; i++)
            {
                if (dataArray[i] == "null")
                    child.Enqueue(null);
                else
                    child.Enqueue(new TreeNode(Convert.ToInt32(dataArray[i])));
            }

            var root = child.Dequeue();
            parent.Enqueue(root);
            Deserialize(0, parent, child);
            return root;
        }

        private void Deserialize(int depth, Queue<TreeNode> parent, Queue<TreeNode> child)
        {
            if (child.Count == 0)
                return;
            var count = (int)Math.Pow(2, depth);
            while (count > 0)
            {
                var node = parent.Dequeue();
                var left = child.Dequeue();
                var right = child.Dequeue();
                parent.Enqueue(left);
                parent.Enqueue(right);
                if (node != null)
                {
                    node.left = left;
                    node.right = right;
                }
                count--;
            }
            Deserialize(++depth, parent, child);
        }
    }

    public class Codec
    {
        // Encodes a tree to a single string.
        public string Serialize(TreeNode root)
        {
            if (root == null)
            {
                return string.Empty;
            }

            return PreOrderTraversal(root);
        }

        private string PreOrderTraversal(TreeNode node)
        {
            if (node == null)
            {
                return "null";
            }

            return $"{node.val},{PreOrderTraversal(node.left)},{PreOrderTraversal(node.right)}";
        }

        public enum Status
        {
            NeedGoLeft = 0,
            NeedGoRight = 1
        }

        // Decodes your encoded data to tree.
        public TreeNode Deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            var splitArray = data.Split(",");

            if (splitArray.Length == 0)
            {
                return null;
            }

            var resultNode = new TreeNode(Convert.ToInt32(splitArray[0]));
            var currentNode = resultNode;
            var preNode = new Stack<(TreeNode node, Status status)>();
            preNode.Push((currentNode, Status.NeedGoLeft));

            for (int i = 1; i < splitArray.Length; i++)
            {
                var popSuccess = preNode.TryPop(out var popValue);
                if (!popSuccess)
                {
                    break;
                }

                currentNode = popValue.node;

                var val = splitArray[i];
                if (val != "null")
                {
                    if (popValue.status == Status.NeedGoLeft)
                    {
                        preNode.Push((currentNode, Status.NeedGoRight));
                        currentNode.left = new TreeNode(Convert.ToInt32(val));
                        preNode.Push((currentNode.left, Status.NeedGoLeft));
                    }
                    else if (popValue.status == Status.NeedGoRight)
                    {
                        currentNode.right = new TreeNode(Convert.ToInt32(val));
                        preNode.Push((currentNode.right, Status.NeedGoLeft));
                    }
                }
                else
                {
                    if (popValue.status == Status.NeedGoLeft)
                    {
                        preNode.Push((currentNode, Status.NeedGoRight));
                    }
                    else if (popValue.status == Status.NeedGoRight)
                    {
                    }
                }
            }

            return resultNode;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec ser = new Codec();
    // Codec deser = new Codec();
    // TreeNode ans = deser.deserialize(ser.serialize(root));
}