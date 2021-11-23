using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_123_Best_Time_to_Buy_and_Sell_Stock_III
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution2();

            //var prices = new int[] { 3, 3, 5, 0, 0, 3, 1, 4 };
            //var prices = new int[] { 1, 2, 3, 4, 5, 6 };
            //var prices = new int[] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0 };
            var prices = new int[] { 3, 2, 6, 5, 0, 3 };

            Console.WriteLine(s.MaxProfit(prices));
        }

        // Use DP
        public class Solution2
        {
            public int MaxProfit(int[] prices)
            {
                var dp = Enumerable.Range(0, prices.Length)
                                   .Select(x => Enumerable.Repeat(0, 5).ToArray()).ToArray();

                // j 為 0，表示沒做任何動作，初始化為 0
                dp[0][0] = 0;
                // j 為 1，表示第一次做買入，初始化為 -1 * price[0]
                dp[0][1] = (-1) * prices[0];
                // j 為 2，表示第一次做賣出，直接賣出所以初始化為 0
                dp[0][2] = 0;
                // j 為 3，表示第二次買入，依賴於第一次賣出的狀態再買入，初始化為 -1 * price[0]
                dp[0][3] = (-1) * prices[0];
                // j 為 4，同 j 等於 2
                dp[0][4] = 0;

                for (int i = 1; i < prices.Length; i++)
                {
                    // j 為 0，不做任何動作，保持原本數值
                    dp[i][0] = dp[i - 1][0];
                    // j 為 1，為第 i 天買入股票、或是沒有操作，沿用前一天買入的狀態，兩個可能的最大值
                    dp[i][1] = Math.Max(dp[i - 1][0] - prices[i], dp[i - 1][1]);
                    // j 為 2, 為第 i 天賣出股票、或是沒有操作，沿用前一天賣出的狀態，兩個可能的最大值
                    dp[i][2] = Math.Max(dp[i - 1][1] + prices[i], dp[i - 1][2]);
                    // j 為 3，為第 i 天買入第二次股票、或是沒有操作，沿用前一天買入的狀態，兩個可能的最大值
                    dp[i][3] = Math.Max(dp[i - 1][2] - prices[i], dp[i - 1][3]);
                    // j 為 3，為第 i 天賣出第二次股票、或是沒有操作，沿用前一天賣出的狀態，兩個可能的最大值
                    dp[i][4] = Math.Max(dp[i - 1][3] + prices[i], dp[i - 1][4]);
                }

                return dp[^1][^1];
            }
        }

        // 錯誤想法 When [1,2,4,2,5,7,2,4,9,0] Get Error
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                var profits = new List<int>();
                int? low = null;

                for (int i = 0; i < prices.Length; i++)
                {
                    if (low == null)
                    {
                        low = prices[i];
                        continue;
                    }

                    // 目前價格比前一價格低或持平
                    if (prices[i] <= prices[i - 1])
                    {
                        // 如果持有股票，則賣出前一價格，然後買進目前價位
                        profits.Add(prices[i - 1] - low.Value);
                        low = prices[i];
                    }
                }

                if (low != null)
                {
                    profits.Add(prices[prices.Length - 1] - low.Value);
                }

                return profits.OrderByDescending(x => x).Take(2).Sum();
            }
        }
    }
}