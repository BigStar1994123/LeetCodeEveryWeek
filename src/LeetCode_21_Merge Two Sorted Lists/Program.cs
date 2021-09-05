using System;

namespace LeetCode_21_Merge_Two_Sorted_Lists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var listNode1 = new ListNode(1);
            var b = new ListNode(2);
            var c = new ListNode(4);

            listNode1.next = b;
            b.next = c;
            c.next = null;

            var listNode2 = new ListNode(1);

            var d = new ListNode(3);
            var e = new ListNode(4);

            listNode2.next = d;
            d.next = e;
            e.next = null;

            var s = new Solution();

            var node = s.MergeTwoLists(listNode1, listNode2);
            while (true)
            {
                if (node != null)
                {
                    Console.WriteLine(node.val);
                    node = node.next;
                }
            }
        }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var resultNode = new ListNode();
            var pResultNode = resultNode;
            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    pResultNode.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    pResultNode.next = l1;
                    l1 = l1.next;
                }

                pResultNode = pResultNode.next;
            }

            pResultNode.next = l1 ?? l2;

            return resultNode.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}