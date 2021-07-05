using System;

namespace LeetCode_707_Design_Linked_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var myLinkedList = new MyLinkedList();

            myLinkedList.AddAtHead(4);
            myLinkedList.Get(1);

            //myLinkedList.AddAtIndex(0, 10);
            //myLinkedList.AddAtIndex(0, 20);
            //myLinkedList.AddAtIndex(1, 30);
            //Console.WriteLine(myLinkedList.Get(0));

            //myLinkedList.AddAtHead(1);
            //myLinkedList.AddAtTail(3);
            //myLinkedList.AddAtIndex(1, 2);    // linked list becomes 1->2->3
            //Console.WriteLine(myLinkedList.Get(1));              // return 2
            //myLinkedList.DeleteAtIndex(0);    // now the linked list is 1->3
            //Console.WriteLine(myLinkedList.Get(0));              // return 3
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

        public class MyLinkedList
        {
            /** Initialize your data structure here. */

            private ListNode _head;

            public MyLinkedList()
            {
                _head = null;
            }

            /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */

            public int Get(int index)
            {
                var iter = _head;

                var count = 0;

                while (count < index)
                {
                    iter = iter.next;
                    count++;
                }

                if (iter == null)
                {
                    return -1;
                }

                return iter.val;
            }

            /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */

            public void AddAtHead(int val)
            {
                var newHeadNode = new ListNode(val, _head);
                _head = newHeadNode;
            }

            /** Append a node of value val to the last element of the linked list. */

            public void AddAtTail(int val)
            {
                if (_head == null)
                {
                    var newNode = new ListNode(val, null);
                    _head = newNode;
                    return;
                }

                var iter = _head;
                while (iter.next != null)
                {
                    iter = iter.next;
                }

                var tailNode = iter;

                var newTailNode = new ListNode(val, null);
                tailNode.next = newTailNode;
            }

            /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */

            public void AddAtIndex(int index, int val)
            {
                var newNode = new ListNode(val, null);

                if (index == 0)
                {
                    newNode.next = _head;
                    _head = newNode;
                    return;
                }

                var iter = _head;

                var count = 0;

                while (count < index - 1)
                {
                    iter = iter.next;
                    count++;
                }

                newNode.next = iter.next;
                iter.next = newNode;
            }

            /** Delete the index-th node in the linked list, if the index is valid. */

            public void DeleteAtIndex(int index)
            {
                if (index == 0)
                {
                    _head = _head.next;
                    return;
                }

                var iter = _head;

                var count = 0;

                while (count < index - 1)
                {
                    iter = iter.next;
                    count++;
                }

                var nextNode = iter.next;
                if (nextNode == null)
                {
                    iter.next = null;
                }
                else
                {
                    var nextTwoNode = nextNode.next;
                    iter.next = nextTwoNode;
                }
            }
        }
    }
}