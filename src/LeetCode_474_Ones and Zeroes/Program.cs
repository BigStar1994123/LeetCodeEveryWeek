using System;
using System.Linq;

namespace LeetCode_474_Ones_and_Zeroes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var strs = new string[] { "10", "0001", "111001", "1", "0" };
            var m = 5;
            var n = 3;

            var s = new Solution();
            Console.WriteLine(s.FindMaxForm(strs, m, n));
        }

        public class Solution
        {
            public int FindMaxForm(string[] strs, int m, int n)
            {
                // 初始化 0
                var dp = new int[m + 1][];
                for (int i = 0; i < dp.Length; i++)
                {
                    dp[i] = Enumerable.Repeat(0, n + 1).ToArray();
                }

                foreach (var str in strs)
                {
                    // 遍歷物品
                    var oneNum = 0;
                    var zeroNum = 0;

                    foreach (var c in str)
                    {
                        if (c == '0')
                        {
                            zeroNum++;
                        }
                        else
                        {
                            oneNum++;
                        }
                    }

                    for (int i = m; i >= zeroNum; i--)
                    {
                        // 遍歷背包容量且從後向前遍歷
                        for (int j = n; j >= oneNum; j--)
                        {
                            dp[i][j] = Math.Max(dp[i][j], dp[i - zeroNum][j - oneNum] + 1);
                        }
                    }
                }

                return dp[m][n];
            }
        }
    }
}