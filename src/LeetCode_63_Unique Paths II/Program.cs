using System;

namespace LeetCode_63_Unique_Paths_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var grid = new int[][]
            {
                //new int[] { 0,0,0 },
                //new int[] { 0,1,0 },
                //new int[] { 0,0,0 }

                new int[] { 1,0 },
                new int[] { 0,0 }
            };

            var s = new Solution();
            Console.WriteLine(s.UniquePathsWithObstacles(grid));
        }

        public class Solution
        {
            public int UniquePathsWithObstacles(int[][] obstacleGrid)
            {
                var m = obstacleGrid.Length;
                var n = obstacleGrid[0].Length;

                var dp = new int[m][];

                var flag = false;
                for (int i = 0; i < dp.Length; i++)
                {
                    dp[i] = new int[n];
                    if (!flag && obstacleGrid[i][0] == 1)
                    {
                        flag = true;
                    }

                    dp[i][0] = flag ? 0 : 1;
                }

                var flag2 = false;
                for (int i = 0; i < dp[0].Length; i++)
                {
                    if (!flag2 && obstacleGrid[0][i] == 1)
                    {
                        flag2 = true;
                    }

                    dp[0][i] = flag2 ? 0 : 1;
                }

                for (int i = 1; i < dp.Length; i++)
                {
                    for (int j = 1; j < dp[0].Length; j++)
                    {
                        dp[i][j] = obstacleGrid[i][j] == 1 ? 0 : dp[i - 1][j] + dp[i][j - 1];
                    }
                }

                return dp[^1][dp[0].Length - 1];
            }
        }
    }
}