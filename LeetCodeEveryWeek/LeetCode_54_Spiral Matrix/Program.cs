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
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 }
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

            var xLength = matrix[0].Length;
            var yLength = matrix.Length;

            for (int i = 0; i < xLength; i++)
            {
                result.Add(matrix[0][i]);
            }

            for (int j = 1; j < yLength - 1; j++)
            {
                result.Add(matrix[j][xLength - 1]);
            }

            for (int i = xLength - 1; i > 0 - 1; i--)
            {
                result.Add(matrix[yLength - 1][i]);
            }

            for (int j = yLength - 1 - 1; j > 0; j--)
            {
                result.Add(matrix[j][0]);
            }

            return result;
        }
    }
}