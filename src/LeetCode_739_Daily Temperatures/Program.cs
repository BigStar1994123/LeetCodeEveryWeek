using System;
using System.Collections.Generic;

namespace LeetCode_739_Daily_Temperatures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var te = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };

            Console.WriteLine(string.Join(",", s.DailyTemperatures(te)));
        }

        public class Solution
        {
            public int[] DailyTemperatures(int[] temperatures)
            {
                var stack = new Stack<int>();
                stack.Push(0);
                var result = new int[temperatures.Length];

                for (int i = 1; i < temperatures.Length; i++)
                {
                    if (temperatures[i] <= temperatures[stack.Peek()])
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        while (stack.Count != 0 && temperatures[i] > temperatures[stack.Peek()])
                        {
                            result[stack.Peek()] = i - stack.Peek();
                            stack.Pop();
                        }

                        stack.Push(i);
                    }
                }

                return result;
            }
        }
    }
}