using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_51_N_Queens
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var n = 8;

            var s = new Solution();
            var result = s.SolveNQueens(n);

            Console.WriteLine(string.Join("\n", result.Select(x => string.Join("|", x))));
        }

        public class Solution
        {
            private IList<IList<string>> _result = new List<IList<string>>();

            public IList<IList<string>> SolveNQueens(int n)
            {
                var chessboard = new char[n][];
                for (int i = 0; i < n; i++)
                {
                    chessboard[i] = new char[n];
                    for (int j = 0; j < n; j++)
                    {
                        chessboard[i][j] = '.';
                    }
                }

                BackTracking(0, chessboard, n);
                return _result;
            }

            private void BackTracking(int row, char[][] chessboard, int n)
            {
                if (row == n)
                {
                    _result.Add(ArrayToList(chessboard));
                    return;
                }

                for (int col = 0; col < n; col++)
                {
                    if (IsValid(row, col, chessboard, n))
                    {
                        chessboard[row][col] = 'Q';
                        BackTracking(row + 1, chessboard, n);
                        chessboard[row][col] = '.';
                    }
                }
            }

            private IList<string> ArrayToList(char[][] chessboard)
            {
                var result = new List<string>();

                foreach (var item in chessboard)
                {
                    var str = new string(item);
                    result.Add(str);
                }

                return result;
            }

            private bool IsValid(int row, int col, char[][] chessboard, int n)
            {
                // Check Columns
                for (int i = 0; i < row; i++)
                {
                    if (chessboard[i][col] == 'Q')
                    {
                        return false;
                    }
                }

                // Check 45度角是否有Q
                for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (chessboard[i][j] == 'Q')
                    {
                        return false;
                    }
                }

                // Check 135度角是否有Q
                for (int i = row - 1, j = col + 1; i >= 0 && j < n; i--, j++)
                {
                    if (chessboard[i][j] == 'Q')
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}