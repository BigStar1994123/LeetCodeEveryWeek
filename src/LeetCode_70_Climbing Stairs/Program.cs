using System;
using System.Collections.Generic;

namespace LeetCode_70_Climbing_Stairs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution2();

            var n = 45;

            Console.WriteLine(s.ClimbStairs(n));
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