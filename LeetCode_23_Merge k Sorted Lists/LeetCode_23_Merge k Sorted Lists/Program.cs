using System;

namespace LeetCode_23_Merge_k_Sorted_Lists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var listNode1 = new ListNode(1, new ListNode(4, new ListNode(5, null)));
            var listNode2 = new ListNode(1, new ListNode(3, new ListNode(4, null)));
            var listNode3 = new ListNode(2, new ListNode(6, null));

            var s = new Solution();
            var node = s.MergeKLists(new ListNode[] { listNode1, listNode2, listNode3 });
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
        public ListNode MergeKLists(ListNode[] lists)
        {
            var resultNode = new ListNode();
            var pResultNode = resultNode;

            while (true)
            {
                var minValueList = GetMinNode(lists);
                if (minValueList == -1)
                {
                    break;
                }

                pResultNode.next = lists[minValueList];
                lists[minValueList] = lists[minValueList].next;

                pResultNode = pResultNode.next;
            }

            return resultNode.next;
        }

        private int GetMinNode(ListNode[] lists)
        {
            var min = int.MaxValue;
            var result = -1;

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                {
                    continue;
                }

                var val = lists[i].val;
                if (val < min)
                {
                    min = val;
                    result = i;
                }
            }

            return result;
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