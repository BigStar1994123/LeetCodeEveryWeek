using System;
using System.Linq;

namespace LeetCode_73_Set_Matrix_Zeroes
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

                new int[] { 3, 5, 5, 6, 9, 1, 4, 5, 0, 5 },
                new int[] { 2, 7, 9, 5, 9, 5, 4, 9, 6, 8},
                new int[] { 6, 0, 7, 8, 1, 0, 1, 6, 8, 1 },
                new int[] { 7, 2, 6, 5, 8, 5, 6, 5, 0, 6 }
            };

            s.SetZeroes(array2D);

            Console.WriteLine(string.Join(",", array2D.SelectMany(s => s).ToArray().Select(s => s)));
        }
    }

    public class Solution
    {
        public void SetZeroes(int[][] matrix)
        {
            bool rowFlag = false, columnFlag = false;

            int m = matrix.Length;
            int n = matrix[0].Length;

            // 判斷第一列是否有0, 如果有, flg設定為true
            for (int i = 0; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    columnFlag = true;
                    break;
                }
            }

            // 判斷第一行是否有0, 如果有, flg設定為true
            for (int j = 0; j < n; j++)
            {
                if (matrix[0][j] == 0)
                {
                    rowFlag = true;
                    break;
                }
            }

            // 從第二行第二列開始遍歷二維陣列, 如果有0, 那麼把該位置對應的行和列的第一個元素設定為0
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            // 從第二行開始, 如果第一個元素為0, 那麼整行設定為0
            for (int i = 1; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 1; j < n; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // 從第二列開始, 如果第一個元素為0, 把整列設定為0
            for (int j = 1; j < n; j++)
            {
                if (matrix[0][j] == 0)
                {
                    for (int i = 1; i < m; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // 如果flgFirstRow為真, 那麼第一行全部設定為0
            if (rowFlag)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            // 如果flgFirstCol為真, 那麼把第一列全部設定為0
            if (columnFlag)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }
    }
}