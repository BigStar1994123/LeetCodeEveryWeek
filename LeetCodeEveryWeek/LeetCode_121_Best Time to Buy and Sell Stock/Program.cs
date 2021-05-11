using System;

namespace LeetCode_121_Best_Time_to_Buy_and_Sell_Stock
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var prices = new int[] { 7, 1, 5, 3, 6, 4 };

            var s = new Solution();
            Console.WriteLine(s.MaxProfit(prices));
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