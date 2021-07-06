using System;
using System.Collections.Generic;

namespace LeetCode_19_Remove_Nth_Node_From_End_of_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new Solution3();
            var a = new ListNode(1);
            var b = new ListNode(2);
            var c = new ListNode(3);
            var d = new ListNode(4);
            var e = new ListNode(5);
            //a.next = null;
            a.next = b;
            //b.next = null;
            b.next = c;
            c.next = d;
            d.next = e;
            e.next = null;

            //var a = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });
            var n = 5;

            a = s.RemoveNthFromEnd(a, n);

            var node = a;
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

    public class Solution3
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var stack = new Stack<ListNode>();

            var iter = head;
            while (iter != null)
            {
                stack.Push(iter);
                iter = iter.next;
            }

            ListNode beforeNode = null;

            var count = 1;
            while (count < n)
            {
                beforeNode = stack.Pop();
                count++;
            }

            var targetNode = stack.Pop();
            stack.TryPop(out var preNode);
            if (preNode == null)
            {
                head = beforeNode;
            }
            else
            {
                preNode.next = beforeNode;
            }

            return head;
        }
    }

    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var length = 0;
            var p = head;
            while (p != null)
            {
                length++;
                p = p.next;
            }

            if (length == 1)
            {
                head = null;
                return head;
            }

            var p2 = head;
            var count = 0;
            ListNode pre = null;
            ListNode post = null;
            while (p2 != null)
            {
                if (count == length - n - 1)
                {
                    pre = p2;
                }

                if (count == length - n + 1)
                {
                    post = p2;
                }

                count++;
                p2 = p2.next;
            }

            if (pre == null)
            {
                return post;
            }

            pre.next = post;

            return head;
        }
    }

    public class Solution2
    {
        public LinkedList<int> RemoveNthFromEnd(LinkedList<int> head, int n)
        {
            var p = head.First;

            var length = head.Count;
            var target = length - n + 1; // 5-2
            var beforeTarget = target - 1;
            var afterTarget = target + 1;

            LinkedListNode<int> beforePointer = null;
            LinkedListNode<int> afterPointer = null;

            var count = 0 + 1;
            while (count != target + 1)
            {
                if (count == beforeTarget)
                {
                    beforePointer = p;
                }

                if (count == afterTarget)
                {
                    afterPointer = p;
                }

                count++;
                p = p.Next;
            }

            beforePointer.List.AddAfter(beforePointer, afterPointer);

            return p.List;
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