using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_54_Spiral_Matrix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var array2D = new int[][]
            {
                //new int[] { 1, 2, 3, 4 },
                //new int[] { 5, 6, 7, 8 },
                //new int[] { 9, 10, 11, 12 }

                new int[] { 1 },
                new int[] { 2 },
                new int[] { 3 },
                new int[] { 4 },
                new int[] { 5 },
                new int[] { 6 },
                new int[] { 7 },
                new int[] { 8 },
                new int[] { 9 }
            };

            var list = s.SpiralOrder(array2D);
            Console.WriteLine(string.Join(",", list.Select(x => x.ToString())));
        }
    }

    public class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var result = new List<int>();

            while (matrix.Length != 0)
            {
                var xLength = matrix[0].Length;
                var yLength = matrix.Length;

                for (int i = 0; i < xLength; i++)
                {
                    result.Add(matrix[0][i]);
                }

                for (int j = 1; j < yLength; j++)
                {
                    result.Add(matrix[j][xLength - 1]);
                }

                if (yLength - 1 != 0)
                {
                    for (int i = xLength - 2; i > 0 - 1; i--)
                    {
                        result.Add(matrix[yLength - 1][i]);
                    }
                }

                if (xLength - 1 != 0)
                {
                    for (int j = yLength - 1 - 1; j > 0; j--)
                    {
                        result.Add(matrix[j][0]);
                    }
                }

                matrix = GetNextMatrix(matrix);
            }

            return result;
        }

        private int[][] GetNextMatrix(int[][] matrix)
        {
            var resultList = new List<IList<int>>();

            var xLength = matrix[0].Length;
            var yLength = matrix.Length;

            for (int j = 1; j < yLength - 1; j++)
            {
                var item = new List<int>();
                for (int i = 1; i < xLength - 1; i++)
                {
                    item.Add(matrix[j][i]);
                }

                if (item.Count > 0)
                {
                    resultList.Add(item);
                }
            }

            return resultList.Select(Enumerable.ToArray).ToArray();
        }
    }
}