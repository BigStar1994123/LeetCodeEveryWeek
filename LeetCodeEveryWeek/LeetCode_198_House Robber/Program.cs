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

            var s = new Solution();
            Console.WriteLine(s.Rob(nums));
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