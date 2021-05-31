using System;
using System.Linq;

namespace LeetCode_200_Number_of_Islands
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var array2D = new char[][]
            {
                new char[] { '1','1','1','1','0' },
                new char[] { '1','1','0','1','0' },
                new char[] { '1','1','0','0','0' },
                new char[] { '0','0','0','0','0' },
            };

            var s = new Solution();
            Console.WriteLine(s.NumIslands(array2D));
        }

        public class Solution
        {
            private bool[][] dp;
            private readonly static int[] dx = new int[] { 1, 0, -1, 0 };
            private readonly static int[] dy = new int[] { 0, 1, 0, -1 };
            private int rowLength, colLength;

            public int NumIslands(char[][] grid)
            {
                if (grid.Length == 0)
                {
                    return 0;
                }

                var ans = 0;

                rowLength = grid.Length;
                colLength = grid[0].Length;

                dp = new bool[rowLength][];
                for (var i = 0; i < dp.Length; i++)
                {
                    dp[i] = Enumerable.Repeat(false, colLength).ToArray();
                }

                for (var i = 0; i < rowLength; i++)
                {
                    for (var j = 0; j < colLength; j++)
                    {
                        if (grid[i][j] == '1' && !dp[i][j])
                        {
                            DFS(i, j, grid);
                            ans++;
                        }
                    }
                }

                return ans;
            }

            private void DFS(int r, int c, char[][] grid)
            {
                dp[r][c] = true;
                for (int d = 0; d < 4; ++d)
                {
                    int ny = r + dy[d];
                    int nx = c + dx[d];
                    if (ny >= 0 && ny < rowLength && nx >= 0 && nx < colLength && grid[ny][nx] == '1' && !dp[ny][nx])
                    {
                        DFS(ny, nx, grid);
                    }
                }
            }
        }
    }
}