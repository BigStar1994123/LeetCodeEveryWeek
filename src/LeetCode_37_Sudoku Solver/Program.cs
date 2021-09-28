using System;
using System.Linq;

namespace LeetCode_37_Sudoku_Solver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var board = new char[9][]
            {
                new char[]{ '5','3','.','.','7','.','.','.','.' },
                new char[]{ '6','.','.','1','9','5','.','.','.' },
                new char[]{ '.','9','8','.','.','.','.','6','.' },
                new char[]{ '8','.','.','.','6','.','.','.','3' },
                new char[]{ '4','.','.','8','.','3','.','.','1' },
                new char[]{ '7','.','.','.','2','.','.','.','6' },
                new char[]{ '.','6','.','.','.','.','2','8','.' },
                new char[]{ '.','.','.','4','1','9','.','.','5' },
                new char[]{ '.','.','.','.','8','.','.','7','9' },
            };

            var s = new Solution();
            s.SolveSudoku(board);
            Console.WriteLine(string.Join("\n", board.Select(x => string.Join("|", x))));
        }

        public class Solution
        {
            public void SolveSudoku(char[][] board)
            {
                BackTracking(board);
            }

            private bool BackTracking(char[][] board)
            {
                for (int i = 0; i < 9; i++) // Row
                {
                    for (int j = 0; j < 9; j++) // Column
                    {
                        if (board[i][j] != '.')
                        {
                            continue;
                        }

                        for (var k = '1'; k <= '9'; k++) // 1~9都找一次
                        {
                            if (IsValid(i, j, k, board))
                            {
                                board[i][j] = k;
                                if (BackTracking(board))
                                {
                                    return true;
                                }
                            }

                            board[i][j] = '.';
                        }

                        return false;
                    }
                }

                return true;
            }

            private bool IsValid(int row, int col, char val, char[][] board)
            {
                // 同行是否重複
                for (int i = 0; i < 9; i++)
                {
                    if (board[row][i] == val)
                    {
                        return false;
                    }
                }

                // 同列是否重複
                for (int j = 0; j < 9; j++)
                {
                    if (board[j][col] == val)
                    {
                        return false;
                    }
                }

                // 9宮格是否重複
                int startRow = (row / 3) * 3;
                int startCol = (col / 3) * 3;
                for (int i = startRow; i < startRow + 3; i++)
                {
                    for (int j = startCol; j < startCol + 3; j++)
                    {
                        if (board[i][j] == val)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }
    }
}