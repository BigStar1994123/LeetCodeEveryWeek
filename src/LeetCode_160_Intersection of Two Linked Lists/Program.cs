using System;
using System.Collections.Generic;

namespace LeetCode_160_Intersection_of_Two_Linked_Lists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new ListNode(4);
            var b = new ListNode(1);
            a.next = b;

            var c = new ListNode(8);
            b.next = c;

            var d = new ListNode(5);
            var e = new ListNode(6);
            var f = new ListNode(1);
            d.next = e;
            e.next = f;
            f.next = c;

            c.next = new ListNode(4);

            var s = new Solution();
            var result = s.GetIntersectionNode(a, d);
        }

        public class Solution
        {
            public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
            {
                var dp = new HashSet<ListNode>();

                while (headA != null)
                {
                    dp.Add(headA);
                    headA = headA.next;
                }

                while (headB != null)
                {
                    if (dp.Contains(headB))
                    {
                        return headB;
                    }

                    headB = headB.next;
                }

                return null;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }
        }
    }
}