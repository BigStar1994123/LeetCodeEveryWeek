using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_300_Longest_Increasing_Subsequence
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 0, 1, 0, 3, 2, 3 };
            //var nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 18, 19 };
            //var nums = new int[] { 7, 7, 7, 7, 7, 7, 7 };

            var s = new Solution2();
            Console.WriteLine(s.LengthOfLIS(nums));
        }

        public class Solution2
        {
            public int LengthOfLIS(int[] nums)
            {
                var dp = Enumerable.Repeat(1, nums.Length).ToArray();

                for (int i = 1; i < nums.Length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (nums[i] > nums[j])
                        {
                            dp[i] = Math.Max(dp[i], dp[j] + 1);
                        }
                    }
                }

                var result = 0;
                for (int i = 0; i < dp.Length; i++)
                {
                    result = Math.Max(result, dp[i]);
                }

                return result;
            }
        }

        public class Solution
        {
            public int LengthOfLIS(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }

                var dpList = new List<int>();

                foreach (var num in nums)
                {
                    for (var i = 0; ; i++)
                    {
                        if (i >= dpList.Count)
                        {
                            dpList.Add(num);
                            break;
                        }

                        if (num <= dpList[i])
                        {
                            dpList[i] = num;
                            break;
                        }
                    }
                }

                return dpList.Count;
            }
        }
    }
}