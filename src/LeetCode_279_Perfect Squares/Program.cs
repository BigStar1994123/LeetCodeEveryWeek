using System;
using System.Linq;

namespace LeetCode_279_Perfect_Squares
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var n = 16;

            var s = new Solution();
            Console.WriteLine(s.NumSquares(n));
        }

        public class Solution
        {
            public int NumSquares(int n)
            {
                var dp = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
                dp[0] = 0;

                var sq = Math.Sqrt(n);

                for (int i = 1; i <= sq; i++)
                {
                    var squareValue = (int)Math.Pow(i, 2);

                    for (int j = squareValue; j <= n; j++)
                    {
                        if (dp[j - squareValue] != int.MaxValue)
                        {
                            dp[j] = Math.Min(dp[j - squareValue] + 1, dp[j]);
                        }
                    }
                }

                return dp[n];
            }
        }
    }
}