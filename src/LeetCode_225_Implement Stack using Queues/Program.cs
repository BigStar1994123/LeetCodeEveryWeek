using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_225_Implement_Stack_using_Queues
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MyStack obj = new MyStack();
            obj.Push(1);
            obj.Push(2);
            int param_2 = obj.Pop();
            int param_3 = obj.Top();
            bool param_4 = obj.Empty();
        }

        public class MyStack
        {
            /** Initialize your data structure here. */
            private Queue<int> _queue;

            public MyStack()
            {
                _queue = new Queue<int>();
            }

            /** Push element x onto stack. */

            public void Push(int x)
            {
                _queue.Enqueue(x);

                for (int i = 0; i < _queue.Count - 1; i++)
                {
                    _queue.Enqueue(_queue.Dequeue());
                }
            }

            /** Removes the element on top of the stack and returns that element. */

            public int Pop()
            {
                return _queue.Dequeue();
            }

            /** Get the top element. */

            public int Top()
            {
                return _queue.Peek();
            }

            /** Returns whether the stack is empty. */

            public bool Empty()
            {
                return !_queue.Any();
            }
        }
    }
}