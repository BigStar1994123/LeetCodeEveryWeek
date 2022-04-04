using System;
using System.Linq;

namespace LeetCode_121_Best_Time_to_Buy_and_Sell_Stock
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var prices = new int[] { 7, 1, 5, 3, 6, 4 };

            var s = new Solution3();
            Console.WriteLine(s.MaxProfit(prices));
        }
    }

    public class Solution4
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
            {
                return 0;
            }

            var minPrice = prices[0];
            var profit = 0;

            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                    continue;
                }

                var p = prices[i] - minPrice;
                profit = Math.Max(profit, p);
            }

            return profit;
        }
    }

    public class Solution3
    {
        public int MaxProfit(int[] prices)
        {
            var dp = Enumerable.Range(0, prices.Length).Select(i => Enumerable.Repeat(0, 2).ToArray()).ToArray();
            dp[0][0] = -1 * prices[0];
            dp[0][1] = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                // 如果第i天持有股票即dp[i][0]， 那么可以由两个状态推出来
                // 第 i-1 天就持有股票，那么就保持现状，所得现金就是昨天持有股票的所得现金 即：dp[i - 1][0]
                // 第i天买入股票，所得现金就是买入今天的股票后所得现金即：-prices[i]
                dp[i][0] = Math.Max(dp[i - 1][0], -1 * prices[i]);

                // 如果第i天不持有股票即dp[i][1]， 也可以由两个状态推出来
                // 第 i-1 天就不持有股票，那么就保持现状，所得现金就是昨天不持有股票的所得现金 即：dp[i - 1][1]
                // 第 i 天卖出股票，所得现金就是按照今天股票佳价格卖出后所得现金即：prices[i] + dp[i - 1][0]
                dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] + prices[i]);
            }

            return dp[prices.Length - 1][1];
        }
    }

    public class Solution2
    {
        public int MaxProfit(int[] prices)
        {
            var profit = 0;
            var low = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < low)
                {
                    low = prices[i];
                }

                profit = Math.Max(prices[i] - low, profit);
            }

            return profit;
        }
    }

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            var min = int.MaxValue;

            var profit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }

                var nowProfit = prices[i] - min;
                if (nowProfit > profit)
                {
                    profit = nowProfit;
                }
            }

            return profit;
        }
    }
}