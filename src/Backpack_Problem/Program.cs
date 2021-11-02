using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Backpack_Problem
{
    /// <summary>
    /// 有N件物品和一个最多能被重量为W 的背包。
    /// 第i件物品的重量是weight[i]，
    /// 得到的价值是value[i] 。
    /// 每件物品只能用一次，
    /// 求解将哪些物品装入背包里物品价值总和最大。
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var backpackCapacity = 15;

            //var itemsWeight = new int[] { 1, 1, 2, 4, 12 };
            //var itemsValue = new int[] { 1, 2, 2, 10, 4 };

            var backpackCapacity = 4;

            var itemsWeight = new int[] { 1, 3, 4 };
            var itemsValue = new int[] { 15, 20, 30 };

            var s = new Solution();
            s.TakeMaxValueItemsIntoBackpack(itemsWeight, itemsValue, backpackCapacity);
        }

        public class Solution
        {
            public void TakeMaxValueItemsIntoBackpack(int[] itemsWeight, int[] itemsValue, int backpackCapacity)
            {
                var dp = new int[itemsWeight.Length][];

                for (int i = 0; i < itemsWeight.Length; i++)
                {
                    dp[i] = Enumerable.Repeat(0, backpackCapacity + 1).ToArray();
                }

                Print(dp);

                for (int j = itemsWeight[0]; j < backpackCapacity + 1; j++)
                {
                    dp[0][j] = itemsValue[0];
                }

                Print(dp);

                // Exec
                for (int i = 1; i < itemsWeight.Length; i++) // 遍歷物品
                {
                    for (int j = 0; j < backpackCapacity + 1; j++) // 遍歷背包容量
                    {
                        if (j < itemsWeight[i])
                        {
                            // 表示裝不下
                            dp[i][j] = dp[i - 1][j];
                        }
                        else
                        {
                            // 如果裝得下，則選最優解去裝
                            dp[i][j] = Math.Max(dp[i - 1][j], dp[i - 1][j - itemsWeight[i]] + itemsValue[i]);
                        }
                    }
                }

                Print(dp);
            }

            private void Print(int[][] dp)
            {
                for (int i = 0; i < dp.Length; i++)
                {
                    for (int j = 0; j < dp[0].Length; j++)
                    {
                        Console.Write(dp[i][j] + " ");
                    }
                    Console.Write("\n");
                }
                Console.Write("---------------------\n\n");
            }
        }
    }
}