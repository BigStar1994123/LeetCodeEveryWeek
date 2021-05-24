using System;
using System.Collections.Generic;

namespace LeetCode_143_Reorder_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new ListNode(1);
            var b = new ListNode(2);
            var c = new ListNode(3);
            var d = new ListNode(4);

            a.next = b;
            b.next = c;
            c.next = d;

            var s = new Solution();
            s.ReorderList(a);
        }

        public class Solution
        {
            public void ReorderList(ListNode head)
            {
                var map = new Dictionary<int, ListNode>();

                var i = 0;
                var count = 0;
                while (head != null)
                {
                    map.Add(i, head);
                    head = head.next;
                    i++;
                }

                count = i--;

                var resultHead = new ListNode(0);
                var j = 0;
                var k = count - 1;
                var temp = resultHead;
                while (j < count / 2)
                {
                    temp.next = map[j];
                    map[j].next = map[k];
                    temp = map[k];
                    j++;
                    k--;
                }

                // is Odd
                if (count % 2 != 0)
                {
                    temp.next = map[j];
                    temp = map[j];
                }

                temp.next = null;

                head = resultHead.next;

                // Show values
                while (head != null)
                {
                    Console.WriteLine($"{head.val}");
                    head = head.next;
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
}