using System;
using System.Linq;

namespace LeetCode_122_Best_Time_to_Buy_and_Sell_Stock_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var prices = new int[] { 1, 2, 3, 4, 5, 6 };

            var s = new Solution3();
            Console.WriteLine(s.MaxProfit(prices));
        }

        public class Solution3
        {
            public int MaxProfit(int[] prices)
            {
                var dp = Enumerable.Repeat(0, prices.Length)
                                   .Select(i => Enumerable.Repeat(0, 2).ToArray()).ToArray();
                dp[0][0] = -1 * prices[0];
                dp[0][1] = 0;

                for (int i = 1; i < prices.Length; i++)
                {
                    dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + (-1 * prices[i]));
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
                    // 未持有
                    if (low == int.MaxValue)
                    {
                        low = prices[i];
                        continue;
                    }

                    // 持有
                    if (low != int.MaxValue)
                    {
                        if (prices[i] > prices[i - 1])
                        {
                            // 最新價格比前一價格貴，不賣出持續持有 (這其實可以不寫)
                            continue;
                        }

                        // 最新價格比前一價格便宜
                        if (prices[i] < prices[i - 1])
                        {
                            // 在前一價格賣出
                            profit += prices[i - 1] - low;
                            // 買進最新價格
                            low = prices[i];
                        }
                        else if (prices[i] < low)
                        {
                            low = prices[i];
                        }
                    }
                }

                if (low != int.MaxValue)
                {
                    profit += prices[prices.Length - 1] - low;
                }

                return profit;
            }
        }

        public class Solution
        {
            private enum Status
            {
                Hold,
                NoHold
            }

            public int MaxProfit(int[] prices)
            {
                if (prices.Length <= 1)
                {
                    return 0;
                }

                var profit = 0;
                var status = Status.NoHold;
                int buyPrice = int.MinValue;
                for (int i = 1; i < prices.Length; i++)
                {
                    if (status == Status.NoHold && prices[i] > prices[i - 1])
                    {
                        // 漲價，買入前一個價位
                        buyPrice = prices[i - 1];
                        status = Status.Hold;
                    }
                    else if (status == Status.Hold && prices[i] < prices[i - 1])
                    {
                        // 跌價，賣出前一個價位
                        profit += prices[i - 1] - buyPrice;
                        status = Status.NoHold;
                    }
                }

                if (status == Status.Hold)
                {
                    profit += prices[prices.Length - 1] - buyPrice;
                }

                return profit;
            }
        }
    }
}