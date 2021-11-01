using System;
using System.Collections.Generic;

namespace LeetCode_96_Unique_Binary_Search_Trees
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var num = 4;

            var s = new Solution();
            Console.WriteLine(s.NumTrees(num));
        }

        public class Solution
        {
            public int NumTrees(int n)
            {
                var dp = new Dictionary<int, int>()
                {
                    { 0, 1 },
                    { 1, 1 }
                };

                for (int i = 2; i <= n; i++)
                {
                    var value = 0;
                    var subNodeCounts = i - 1;
                    for (int j = 0; j < i; j++)
                    {
                        value += dp[j] * dp[subNodeCounts - j];
                    }

                    dp.Add(i, value);
                }

                return dp[n];
            }
        }
    }
}