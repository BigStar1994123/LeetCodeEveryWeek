using System;

namespace LeetCode_62_Unique_Paths
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var m = 3;
            var n = 2;

            Console.WriteLine(s.UniquePaths(m, n));
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