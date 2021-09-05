using System;

namespace LeetCode_48_Rotate_Image
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public void Rotate(int[][] matrix)
        {
            var length = matrix[0].Length;
            var n = length - 1;

            for (var i = 0; i < length / 2; i++)
            {
                for (var j = 0; j < length - (2 * i) - 1; j++)
                {
                    Swap(ref matrix[i][j + i], ref matrix[n - j - i][0 + i]);
                    Swap(ref matrix[n - j - i][0 + i], ref matrix[n - i][n - j - i]);
                    Swap(ref matrix[n - i][n - j - i], ref matrix[j + i][n - i]);
                }
            }
        }

        private void Swap(ref int a, ref int b)
        {
            var x = a;
            a = b;
            b = x;
        }
    }
}