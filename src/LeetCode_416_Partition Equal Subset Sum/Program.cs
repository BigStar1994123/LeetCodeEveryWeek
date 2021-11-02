using System;
using System.Linq;

namespace LeetCode_416_Partition_Equal_Subset_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 2, 5, 11 };

            var s = new Solution();
            Console.WriteLine(s.CanPartition(nums));
        }

        public class Solution
        {
            public bool CanPartition(int[] nums)
            {
                var sum = nums.Sum();
                var dp = Enumerable.Repeat(0, 10001).ToArray();

                if (sum % 2 == 1)
                {
                    return false;
                }

                var target = sum / 2;

                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = target; j >= nums[i]; j--)
                    {
                        dp[j] = Math.Max(dp[j], dp[j - nums[i]] + nums[i]);
                    }
                }

                return dp[target] == target;
            }
        }
    }
}