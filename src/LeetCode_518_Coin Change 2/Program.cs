using System;
using System.Linq;

namespace LeetCode_518_Coin_Change_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var coins = new int[] { 1, 2, 5 };
            var amount = 5;

            var s = new Solution();
            Console.WriteLine(s.Change(amount, coins));
        }

        public class Solution
        {
            public int Change(int amount, int[] coins)
            {
                var dp = Enumerable.Repeat(0, amount + 1).ToArray();
                dp[0] = 1;

                for (int i = 0; i < coins.Length; i++)
                {
                    for (int j = coins[i]; j <= amount; j++)
                    {
                        dp[j] += dp[j - coins[i]];
                    }
                }

                return dp[amount];
            }
        }
    }
}