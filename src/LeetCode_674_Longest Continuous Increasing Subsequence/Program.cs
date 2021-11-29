using System;

namespace LeetCode_674_Longest_Continuous_Increasing_Subsequence
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var nums = new int[] { 1, 3, 5, 4, 7 };

            Console.WriteLine(s.FindLengthOfLCIS(nums));
        }

        public class Solution
        {
            public int FindLengthOfLCIS(int[] nums)
            {
                var result = 1;
                var length = 1;

                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] > nums[i - 1])
                    {
                        length++;
                        result = Math.Max(result, length);
                    }
                    else
                    {
                        length = 1;
                    }
                }

                return result;
            }
        }
    }
}