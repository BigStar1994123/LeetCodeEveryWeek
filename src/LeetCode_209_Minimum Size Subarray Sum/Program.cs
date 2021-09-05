using System;

namespace LeetCode_209_Minimum_Size_Subarray_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 2, 3, 99, 1, 2, 4, 3 };
            var target = 7;

            var s = new Solution();
            Console.WriteLine(s.MinSubArrayLen(target, nums));
        }

        public class Solution
        {
            public int MinSubArrayLen(int target, int[] nums)
            {
                int left = 0;
                var sum = 0;
                var result = int.MaxValue;

                for (int right = 0; right < nums.Length; right++)
                {
                    sum += nums[right];
                    while (sum >= target)
                    {
                        result = Math.Min(result, right - left + 1);
                        sum -= nums[left++];
                    }
                }

                return result == int.MaxValue ? 0 : result;
            }
        }
    }
}