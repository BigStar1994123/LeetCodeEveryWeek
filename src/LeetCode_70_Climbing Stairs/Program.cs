using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_70_Climbing_Stairs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution4();

            var n = 5;

            Console.WriteLine(s.ClimbStairs(n));
        }
    }

    public class Solution4
    {
        public int ClimbStairs(int n)
        {
            var dp = new Dictionary<int, int>
            {
                {1, 1},
                {2, 2}
            };

            for (int i = 3; i <= n; i++)
            {
                dp.Add(i, dp[i - 1] + dp[i - 2]);
            }

            return dp[n];
        }
    }

    /// <summary>
    /// 使用背包去解
    /// </summary>
    public class Solution3
    {
        public int ClimbStairs(int n)
        {
            var dp = Enumerable.Repeat(0, n + 1).ToArray();
            dp[0] = 1;

            const int m = 2;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (i - j >= 0)
                    {
                        dp[i] += dp[i - j];
                    }
                }
            }
            return dp[n];
        }
    }

    public class Solution2
    {
        public int ClimbStairs(int n)
        {
            var dp = new Dictionary<int, int>
            {
                { 1, 1 },
                { 2, 2 }
            };

            for (int i = 3; i <= n; i++)
            {
                dp.Add(i, dp[i - 1] + dp[i - 2]);
            }

            return dp[n];
        }
    }

    public class Solution
    {
        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];

            //return ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }
    }
}