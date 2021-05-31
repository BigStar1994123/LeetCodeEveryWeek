using System;

namespace LeetCode_206_Reverse_Linked_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = null;

            var s = new Solution();
            Console.WriteLine(s.ReverseList(node1));
        }

        public class Solution
        {
            public ListNode ReverseList(ListNode head)
            {
                ListNode newHead = null;
                while (head != null)
                {
                    ListNode next = head.next;
                    head.next = newHead;
                    newHead = head;
                    head = next;
                }
                return newHead;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}