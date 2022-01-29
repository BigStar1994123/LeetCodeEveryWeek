using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_496_Next_Greater_Element_I
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var nums1 = new int[] { 1, 3, 4 };
            var nums2 = new int[] { 1, 3, 4, 2 };

            Console.WriteLine(string.Join(",", s.NextGreaterElement(nums1, nums2)));
        }

        public class Solution
        {
            public int[] NextGreaterElement(int[] nums1, int[] nums2)
            {
                var result = Enumerable.Repeat(-1, nums1.Length).ToArray();
                var stack = new Stack<int>();
                var dict = new Dictionary<int, int>();
                for (int i = 0; i < nums1.Length; i++)
                {
                    dict.Add(nums1[i], i);
                }

                stack.Push(0);

                for (int i = 1; i < nums2.Length; i++)
                {
                    if (nums2[i] <= nums2[stack.Peek()])
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        while (stack.Count != 0 && nums2[stack.Peek()] < nums2[i])
                        {
                            if (dict.ContainsKey(nums2[stack.Peek()]))
                            {
                                var index = dict[(nums2[stack.Peek()])];
                                result[index] = nums2[i];
                            }
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