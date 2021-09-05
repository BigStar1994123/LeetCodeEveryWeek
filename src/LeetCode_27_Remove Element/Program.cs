using System;

namespace LeetCode_27_Remove_Element
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1 };
            var target = 1;

            var s = new Solution();
            Console.WriteLine(s.RemoveElement(nums, target));
        }

        public class Solution
        {
            public int RemoveElement(int[] nums, int val)
            {
                var last = nums.Length - 1;
                var count = last + 1;

                for (int i = 0; i < count; i++)
                {
                    if (nums[i] == val)
                    {
                        nums[i] = nums[last];

                        if (nums[last] == val)
                        {
                            i--;
                        }

                        last--;
                        count--;
                    }
                }

                return count;
            }
        }
    }
}