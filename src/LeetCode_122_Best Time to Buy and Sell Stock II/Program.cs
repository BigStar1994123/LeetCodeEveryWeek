using System;

namespace LeetCode_122_Best_Time_to_Buy_and_Sell_Stock_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var prices = new int[] { 1, 2, 3, 4, 5, 6 };

            var s = new Solution();
            Console.WriteLine(s.MaxProfit(prices));
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