using System;
using System.Collections.Generic;

namespace LeetCode_509_Fibonacci_Number
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var num = 6;

            var s = new Solution();
            Console.WriteLine(s.Fib(num));
        }

        public class Solution
        {
            public int Fib(int n)
            {
                var dp = new Dictionary<int, int>
                {
                    { 0, 0 },
                    { 1, 1 }
                };

                for (int i = 2; i <= n; i++)
                {
                    dp.Add(i, dp[i - 1] + dp[i - 2]);
                }

                return dp[n];
            }
        }
    }
}