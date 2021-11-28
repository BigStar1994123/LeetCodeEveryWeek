using System;
using System.Linq;

namespace LeetCode_309_Best_Time_to_Buy_and_Sell_Stock_with_Cooldown
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var prices = new int[] { 1, 2, 3, 0, 2 };
            Console.WriteLine(s.MaxProfit(prices));
        }

        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                var dp = Enumerable.Range(0, prices.Length)
                                   .Select(x => Enumerable.Repeat(0, 3).ToArray()).ToArray();
                dp[0][0] = -1 * prices[0];
                dp[0][1] = 0;
                dp[0][2] = 0;

                for (int i = 1; i < prices.Length; i++)
                {
                    dp[i][0] = new[] { dp[i - 1][0], dp[i - 1][2] + -1 * prices[i] }.Max();
                    dp[i][1] = new[] { dp[i - 1][1], dp[i - 1][0] + prices[i], dp[i - 1][2] }.Max();
                    dp[i][2] = new[] { dp[i - 1][2], dp[i - 1][1] }.Max();
                }

                return dp[^1][^2];
            }
        }
    }
}