using System;
using System.Collections.Generic;

namespace LeetCode_141_Linked_List_Cycle
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var node1 = new ListNode(3);
            var node2 = new ListNode(2);
            var node3 = new ListNode(0);
            var node4 = new ListNode(4);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = null;

            var s = new Solution();
            Console.WriteLine(s.HasCycle(node1));
        }

        public class Solution
        {
            public bool HasCycle(ListNode head)
            {
                var dp = new HashSet<ListNode>();

                while (!dp.Contains(head))
                {
                    if (head == null)
                    {
                        return false;
                    }

                    dp.Add(head);
                    head = head.next;
                }

                return true;
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
}