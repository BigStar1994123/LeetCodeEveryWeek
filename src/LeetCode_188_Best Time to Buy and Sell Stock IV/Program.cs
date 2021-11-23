using System;
using System.Linq;

namespace LeetCode_188_Best_Time_to_Buy_and_Sell_Stock_IV
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var prices = new int[] { 3, 2, 6, 5, 0, 3 };
            var k = 2;

            Console.WriteLine(s.MaxProfit(k, prices));
        }

        public class Solution
        {
            public int MaxProfit(int k, int[] prices)
            {
                var dp = Enumerable.Range(0, prices.Length)
                    .Select(x => Enumerable.Repeat(0, (2 * k) + 1).ToArray()).ToArray();

                for (int j = 0; j < (2 * k) + 1; j++)
                {
                    dp[0][j] = j % 2 == 0 ? 0 : -1 * prices[0];
                }

                for (int i = 1; i < prices.Length; i++)
                {
                    for (int j = 0; j < (2 * k) + 1; j++)
                    {
                        if (j == 0)
                        {
                            dp[i][j] = dp[i - 1][j];
                        }
                        else if (j % 2 == 1)
                        {
                            dp[i][j] = Math.Max(dp[i - 1][j - 1] - prices[i], dp[i - 1][j]);
                        }
                        else
                        {
                            dp[i][j] = Math.Max(dp[i - 1][j - 1] + prices[i], dp[i - 1][j]);
                        }
                    }

                    // 請參考 123. Best Time to Buy and Sell Stock III 的做法
                    //// j 為 0，不做任何動作，保持原本數值
                    //dp[i][0] = dp[i - 1][0];
                    //// j 為 1，為第 i 天買入股票、或是沒有操作，沿用前一天買入的狀態，兩個可能的最大值
                    //dp[i][1] = Math.Max(dp[i - 1][0] - prices[i], dp[i - 1][1]);
                    //// j 為 2, 為第 i 天賣出股票、或是沒有操作，沿用前一天賣出的狀態，兩個可能的最大值
                    //dp[i][2] = Math.Max(dp[i - 1][1] + prices[i], dp[i - 1][2]);
                    //// j 為 3，為第 i 天買入第二次股票、或是沒有操作，沿用前一天買入的狀態，兩個可能的最大值
                    //dp[i][3] = Math.Max(dp[i - 1][2] - prices[i], dp[i - 1][3]);
                    //// j 為 3，為第 i 天賣出第二次股票、或是沒有操作，沿用前一天賣出的狀態，兩個可能的最大值
                    //dp[i][4] = Math.Max(dp[i - 1][3] + prices[i], dp[i - 1][4]);
                }

                return dp[^1][^1];
            }
        }
    }
}