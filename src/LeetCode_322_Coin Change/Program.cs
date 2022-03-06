using System;
using System.Linq;

namespace LeetCode_322_Coin_Change
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var coins = new int[] { 2 };
            var amount = 3;

            var s = new Solution3();
            Console.WriteLine(s.CoinChange(coins, amount));
        }

        public class Solution3
        {
            public int CoinChange(int[] coins, int amount)
            {
                var dp = Enumerable.Repeat(int.MaxValue, amount + 1).ToArray();
                dp[0] = 0;

                for (int i = 0; i < coins.Length; i++)
                {
                    for (int j = coins[i]; j <= amount; j++)
                    {
                        if (dp[j - coins[i]] != int.MaxValue)
                        {
                            dp[j] = Math.Min(dp[j - coins[i]] + 1, dp[j]);
                        }
                    }
                }

                if (dp[amount] == int.MaxValue)
                {
                    return -1;
                }

                return dp[amount];
            }
        }

        public class Solution2
        {
            public int CoinChange(int[] coins, int amount)
            {
                var dp = Enumerable.Repeat(int.MaxValue, amount + 1).ToArray();
                dp[0] = 0;

                for (int i = 0; i < coins.Length; i++)
                {
                    for (int j = coins[i]; j <= amount; j++)
                    {
                        if (dp[j - coins[i]] != int.MaxValue)
                        {
                            dp[j] = Math.Min(dp[j - coins[i]] + 1, dp[j]);
                        }
                    }
                }

                if (dp[amount] == int.MaxValue)
                {
                    return -1;
                }

                return dp[amount];
            }
        }

        public class Solution
        {
            public int CoinChange(int[] coins, int amount)
            {
                var dp = Enumerable.Repeat(amount + 1, amount + 1).ToArray();
                dp[0] = 0;

                for (int i = 1; i <= amount; i++)
                {
                    for (int j = 0; j < coins.Length; j++)
                    {
                        if (coins[j] <= i)
                        {
                            dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                        }
                    }
                }

                return (dp[amount] > amount) ? -1 : dp[amount];
            }
        }
    }
}