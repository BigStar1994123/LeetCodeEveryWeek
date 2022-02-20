using System;
using System.Linq;

namespace LeetCode_62_Unique_Paths
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution3();

            var m = 3;
            var n = 7;

            Console.WriteLine(s.UniquePaths(m, n));
        }
    }

    public class Solution3
    {
        public int UniquePaths(int m, int n)
        {
            var dp = Enumerable.Range(0, m).Select(x => Enumerable.Repeat(1, n).ToArray()).ToArray();

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[m - 1][n - 1];
        }
    }

    public class Solution2
    {
        public int UniquePaths(int m, int n)
        {
            int[][] dp = new int[m][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[n];
                dp[i][0] = 1;
            }

            for (int i = 0; i < dp[0].Length; i++)
            {
                dp[0][i] = 1;
            }

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[0].Length; j++)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[^1][dp[0].Length - 1];
        }
    }

    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            // 1: Wrire by DP
            int[,] map = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                map[i, 0] = 1;
            }

            for (int j = 0; j < n; j++)
            {
                map[0, j] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    map[i, j] = map[i - 1, j] + map[i, j - 1];
                }
            }

            return map[m - 1, n - 1];

            // 2: Write by Combination
        }
    }
}