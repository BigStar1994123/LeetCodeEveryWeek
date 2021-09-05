using System;

namespace LeetCode_59_Spiral_Matrix_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var num = 10;

            var s = new Solution();
            var array2d = s.GenerateMatrix(num);

            int rowLength = array2d.Length;
            int colLength = array2d[0].Length;

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(array2d[i][j] + "\t");
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public class Solution
        {
            public int[][] GenerateMatrix(int n)
            {
                var result = new int[n][];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = new int[n];
                }

                var max = Convert.ToInt32(Math.Pow(n, 2));
                var num = 1;

                for (int k = 0; k < n / 2; k++)
                {
                    for (int i = k; i < n - 1 - k; i++)
                    {
                        result[k][i] = num++;
                    }

                    for (int i = k; i < n - 1 - k; i++)
                    {
                        result[i][n - 1 - k] = num++;
                    }

                    for (int i = n - 1 - k; i >= 1 + k; i--)
                    {
                        result[n - 1 - k][i] = num++;
                    }

                    for (int i = n - 1 - k; i >= 1 + k; i--)
                    {
                        result[i][k] = num++;
                    }
                }

                if (n % 2 == 1)
                {
                    result[n / 2][n / 2] = max;
                }

                return result;
            }
        }
    }
}