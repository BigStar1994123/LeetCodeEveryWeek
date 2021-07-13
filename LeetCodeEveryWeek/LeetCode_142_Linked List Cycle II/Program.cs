using System;
using System.Collections.Generic;

namespace LeetCode_142_Linked_List_Cycle_II
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
            b.next = a;
            //b.next = c;
            //c.next = d;
            //d.next = b;

            var s = new Solution();
            var result = s.DetectCycle(a);
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

        public class Solution
        {
            public ListNode DetectCycle(ListNode head)
            {
                var fastPointer = head;
                var slowPointer = head;
                ListNode meetPointer = null;

                while (fastPointer != null && fastPointer.next != null)
                {
                    fastPointer = fastPointer.next.next;
                    slowPointer = slowPointer.next;

                    if (fastPointer == slowPointer)
                    {
                        meetPointer = slowPointer;
                        break;
                    }
                }

                slowPointer = head;
                while (slowPointer != meetPointer)
                {
                    slowPointer = slowPointer.next;
                    meetPointer = meetPointer.next;
                }

                return slowPointer;
            }
        }
    }
}