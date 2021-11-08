using System;
using System.Linq;

namespace LeetCode_494_Target_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1, 1, 1, 1, 1 };
            var target = 3;

            var s = new Solution();
            Console.WriteLine(s.FindTargetSumWays(nums, target));
        }

        public class Solution
        {
            public int FindTargetSumWays(int[] nums, int target)
            {
                var sum = nums.Sum();

                if (Math.Abs(target) > sum)
                {
                    return 0; // 此时没有方案
                }
                if ((target + sum) % 2 == 1)
                {
                    return 0; // 此时没有方案
                }

                int bagSize = (target + sum) / 2;
                var dp = Enumerable.Repeat(0, bagSize + 1).ToArray();
                dp[0] = 1;

                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = bagSize; j >= nums[i]; j--)
                    {
                        dp[j] += dp[j - nums[i]];
                    }
                }

                return dp[bagSize];
            }
        }
    }
}