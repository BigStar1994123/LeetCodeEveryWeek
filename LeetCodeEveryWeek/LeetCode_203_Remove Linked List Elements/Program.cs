using System;

namespace LeetCode_203_Remove_Linked_List_Elements
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = new ListNode(7, new ListNode(7, new ListNode(7, new ListNode(7))));

            var s = new Solution();
            var result = s.RemoveElements(a, 7);
        }

        // Definition for singly-linked list.
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

        public class Solution
        {
            public ListNode RemoveElements(ListNode head, int val)
            {
                var first = new ListNode(0, head);

                var iter = first;
                var pre = first;

                while (iter != null)
                {
                    if (iter.val == val)
                    {
                        pre.next = iter.next;
                    }
                    else
                    {
                        pre = iter;
                    }

                    iter = iter.next;
                }

                return first.next;
            }
        }
    }
}