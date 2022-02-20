using System;
using System.Linq;

namespace LeetCode_63_Unique_Paths_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var grid = new int[][]
            {
                //new int[] { 0,1,0 },
                //new int[] { 0,1,0 },
                //new int[] { 0,0,0 },
                //new int[] { 0,0,0 }

                new int[] { 1,0 },
                new int[] { 0,0 }
            };

            var s = new Solution2();
            Console.WriteLine(s.UniquePathsWithObstacles(grid));
        }

        public class Solution2
        {
            public int UniquePathsWithObstacles(int[][] obstacleGrid)
            {
                int x = obstacleGrid.Length;
                int y = obstacleGrid[0].Length;

                var dp = Enumerable.Range(0, obstacleGrid.Length).Select(x => Enumerable.Repeat(0, obstacleGrid[0].Length).ToArray()).ToArray();

                dp[0][0] = obstacleGrid[0][0] == 1 ? 0 : 1;

                for (int i = 1; i < x; i++)
                {
                    dp[i][0] = obstacleGrid[i][0] == 0 ? dp[i - 1][0] : 0;
                }

                for (int j = 1; j < y; j++)
                {
                    dp[0][j] = obstacleGrid[0][j] == 0 ? dp[0][j - 1] : 0;
                }

                for (int i = 1; i < x; i++)
                {
                    for (int j = 1; j < y; j++)
                    {
                        if (obstacleGrid[i][j] == 1)
                        {
                            dp[i][j] = 0;
                        }
                        else
                        {
                            dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                        }
                    }
                }

                return dp[x - 1][y - 1];
            }
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