using System;

namespace LeetCode_53_Maximum_Subarray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution2();
            var nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            Console.WriteLine(s.MaxSubArray(nums));
        }
    }

    public class Solution2
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            var result = nums[0];
            var tempSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                var num = nums[i];
                tempSum += num;

                if (num >= tempSum)
                {
                    tempSum = num;
                }

                result = Math.Max(result, tempSum);
            }

            return result;
        }
    }

    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            var max = nums[0];
            var dpValue = 0;

            foreach (var num in nums)
            {
                dpValue = num > dpValue + num ? num : dpValue + num;
                max = Math.Max(max, dpValue);
            }

            return max;
        }
    }
}