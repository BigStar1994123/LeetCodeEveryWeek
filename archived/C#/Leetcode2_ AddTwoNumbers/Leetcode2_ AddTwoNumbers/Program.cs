using System;

namespace Leetcode2__AddTwoNumbers
{


    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var l1_1 = new ListNode(2);
            var l1_2 = new ListNode(4);
            var l1_3 = new ListNode(3);
            l1_1.next = l1_2;
            l1_2.next = l1_3;

            var l2_1 = new ListNode(5);
            var l2_2 = new ListNode(6);
            var l2_3 = new ListNode(4);
            l2_1.next = l2_2;
            l2_2.next = l2_3;

            s.AddTwoNumbers(l1_1, l2_1);
            Console.Read();
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var headNode = new ListNode(-1);
            var pr = headNode;
            var p1 = l1;
            var p2 = l2;
            var carried = 0;

            while (p1 != null && p2 != null)
            {
                var calcVal = p1.val + p2.val + carried;
                carried = calcVal / 10;
                var nextNode = new ListNode(calcVal % 10);
                pr.next = nextNode;

                pr = nextNode;
                p1 = p1.next;
                p2 = p2.next;
            }

            pr.next = p1 ?? p2;
            
            while(carried != 0)
            {
                if (pr.next != null)
                {
                    pr = pr.next;
                    pr.val += carried;
                    carried = pr.val / 10;
                    pr.val %= 10;
                }
                else
                {
                    pr.next = new ListNode(carried);
                    break;
                }
            }

            var c = headNode.next;
            while (c != null)
            {
                Console.Write(c.val + ",");
                c = c.next;
            }


            return headNode.next;
        }
    }

}
