using System;

namespace Leetcode104_Maximum_Depth_of_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example: [3,9,20,null,null,15,7]
            //  3
            // / \
            //9  20
            //  /  \
            // 15   7
            Console.WriteLine("Hello World!");

            var root = new TreeNode();
            var answer = MaxDepth(root);
            Console.WriteLine(answer);
        }
        private static int MaxDepth(TreeNode root)
        {
            // InOrderTraversal
            if (root == null)
            {
                return 0;
            }

            var leftValue = MaxDepth(root.left);
            // Middle
            var rigthValue = MaxDepth(root.right);
            return leftValue > rigthValue ? leftValue + 1 : rigthValue + 1;
        }
    }



    public class TreeNode
    {
        public TreeNode()
        {

        }

        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
