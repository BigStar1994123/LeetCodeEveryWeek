using System;
using System.Linq;

namespace LeetCode_377_Combination_Sum_IV
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1, 2, 3 };
            var target = 4;

            var s = new Solution();
            Console.WriteLine(s.CombinationSum4(nums, target));
        }

        public class Solution2
        {
            public int CombinationSum4(int[] nums, int target)
            {
                var dp = Enumerable.Repeat(0, target + 1).ToArray();
                dp[0] = 1;
                for (int i = 0; i <= target; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (i >= nums[j])
                        {
                            dp[i] += dp[i - nums[j]];
                        }
                    }
                }

                return dp[target];
            }
        }

        public class Solution
        {
            public int CombinationSum4(int[] nums, int target)
            {
                var dp = Enumerable.Repeat(0, target + 1).ToArray();
                dp[0] = 1;

                for (int i = 0; i <= target; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (i - nums[j] >= 0 && dp[i] < int.MaxValue - dp[i - nums[j]])
                        {
                            dp[i] += dp[i - nums[j]];
                        }
                    }
                }

                return dp[target];
            }
        }
    }
}