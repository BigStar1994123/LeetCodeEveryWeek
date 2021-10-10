﻿using System;

namespace LeetCode_714_BestTimeBuySellStock_with_Transaction_Fee
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var prices = new int[] { 1, 3, 2, 8, 4, 9 };
            var fee = 2;

            var s = new Solution2();
            Console.WriteLine(s.MaxProfit(prices, fee));
        }

        public class Solution2
        {
            public int MaxProfit(int[] prices, int fee)
            {
                var profit = 0;
                var minPrice = prices[0];

                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] < minPrice)
                    {
                        minPrice = prices[i];
                    }

                    if (prices[i] >= minPrice && prices[i] - minPrice <= fee)
                    {
                        continue;
                    }

                    if (prices[i] - minPrice > fee)
                    {
                        profit += prices[i] - minPrice - fee;
                        minPrice = prices[i] - fee;
                    }
                }

                return profit;
            }
        }

        public class Solution
        {
            public int MaxProfit(int[] prices, int fee)
            {
                if (prices.Length == 0)
                {
                    return 0;
                }

                var profit = 0;
                var currentProfit = 0;
                var minPrice = prices[0];
                var maxPrice = prices[0];

                for (var i = 1; i < prices.Length; i++)
                {
                    minPrice = Math.Min(minPrice, prices[i]);
                    maxPrice = Math.Max(maxPrice, prices[i]);
                    currentProfit = Math.Max(currentProfit, prices[i] - minPrice - fee);

                    if (maxPrice - prices[i] >= fee)
                    {
                        profit += currentProfit;
                        currentProfit = 0;
                        minPrice = prices[i];
                        maxPrice = prices[i];
                    }
                }

                return profit + currentProfit;
            }
        }
    }
}