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

            var s = new Solution2();
            Console.WriteLine(s.NumTrees(num));
        }

        public class Solution2
        {
            public int NumTrees(int n)
            {
                var dp = new Dictionary<int, int>
                {
                    { 0, 1 },
                    { 1 ,1 },
                    { 2, 2 }
                };

                for (int i = 3; i <= n; i++)
                {
                    var value = 0;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        value += dp[j] * dp[i - 1 - j];
                    }

                    dp.Add(i, value);
                }

                return dp[n];
            }
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