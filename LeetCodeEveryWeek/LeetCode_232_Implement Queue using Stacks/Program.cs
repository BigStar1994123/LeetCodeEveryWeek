using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_232_Implement_Queue_using_Stacks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MyQueue obj = new MyQueue();
            obj.Push(1);
            obj.Push(2);
            int param_2 = obj.Pop();
            int param_3 = obj.Peek();
            bool param_4 = obj.Empty();
        }

        public class MyQueue
        {
            /** Initialize your data structure here. */
            private Stack<int> _inputStack;
            private Stack<int> _outputStack;

            public MyQueue()
            {
                _inputStack = new Stack<int>();
                _outputStack = new Stack<int>();
            }

            /** Push element x to the back of queue. */

            public void Push(int x)
            {
                _inputStack.Push(x);
            }

            /** Removes the element from in front of queue and returns that element. */

            public int Pop()
            {
                Peek();
                return _outputStack.Pop();
            }

            /** Get the front element. */

            public int Peek()
            {
                if (!_outputStack.Any())
                {
                    while (_inputStack.Any())
                        _outputStack.Push(_inputStack.Pop());
                }

                return _outputStack.Peek();
            }

            /** Returns whether the queue is empty. */

            public bool Empty()
            {
                return !_inputStack.Any() && !_outputStack.Any();
            }
        }
    }
}