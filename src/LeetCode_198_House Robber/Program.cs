using System;
using System.Linq;

namespace LeetCode_198_House_Robber
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1, 2, 3, 1, 5, 9 };

            var s = new Solution2();
            Console.WriteLine(s.Rob(nums));
        }

        public class Solution2
        {
            public int Rob(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }

                if (nums.Length == 1)
                {
                    return nums[0];
                }

                var dp = Enumerable.Repeat(0, nums.Length).ToArray();
                dp[0] = nums[0];
                dp[1] = Math.Max(nums[0], nums[1]);

                for (int i = 2; i < nums.Length; i++)
                {
                    dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
                }

                return dp[nums.Length - 1];
            }
        }

        public class Solution
        {
            public int Rob(int[] nums)
            {
                int[] dp = Enumerable.Repeat(0, nums.Length).ToArray();

                var max = int.MinValue;

                for (var i = 0; i < nums.Length; i++)
                {
                    int n3Value = 0;
                    if (i >= 3)
                    {
                        n3Value = dp[i - 3];
                    }
                    int n2Value = 0;
                    if (i >= 2)
                    {
                        n2Value = dp[i - 2];
                    }

                    var valueMax = Math.Max(n3Value + nums[i], n2Value + nums[i]);
                    dp[i] = valueMax;
                    max = Math.Max(max, valueMax);
                }

                return max;
            }
        }
    }
}