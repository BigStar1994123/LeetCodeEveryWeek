using System;
using System.Collections.Generic;

namespace LeetCode_417_Pacific_Atlantic_Water_Flow
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var heights = new int[][] { };

            var s = new Solution();
            var list = s.PacificAtlantic(heights);
        }

        public class Solution
        {
            public IList<IList<int>> PacificAtlantic(int[][] matrix)
            {
                var row = matrix.Length;

                var result = new List<IList<int>>();
                if (row == 0) return result;

                var col = matrix[0].Length;

                var pacific = new bool[row, col];
                var atlantic = new bool[row, col];

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            DFS(matrix, int.MinValue, i, j, pacific);
                        }

                        if (i == row - 1 || j == col - 1)
                        {
                            DFS(matrix, int.MinValue, i, j, atlantic);
                        }
                    }
                }

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (pacific[i, j] && atlantic[i, j])
                        {
                            result.Add(new List<int>() { i, j });
                        }
                    }
                }

                return result;
            }

            private void DFS(int[][] matrix, int pre, int x, int y, bool[,] isVisited)
            {
                var row = matrix.Length;
                var col = matrix[0].Length;

                if (x >= row || x < 0 || y >= col || y < 0) return;
                if (isVisited[x, y]) return;

                if (pre > matrix[x][y]) return;

                isVisited[x, y] = true;

                var directions = new (int, int)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
                foreach (var direction in directions)
                {
                    var nextX = x + direction.Item1;
                    var nextY = y + direction.Item2;

                    DFS(matrix, matrix[x][y], nextX, nextY, isVisited);
                }
            }
        }
    }
}