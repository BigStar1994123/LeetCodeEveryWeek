using System;

namespace LeetCode_79_Word_Search
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var array2D = new char[][]
            {
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
            };

            var word = "SEE";

            Console.WriteLine(s.Exist(array2D, word));
        }
    }

    public class Solution
    {
        private int W;
        private int H;

        public bool Exist(char[][] board, string word)
        {
            if (board.Length == 0)
            {
                return false;
            }

            H = board.Length;
            W = board[0].Length;

            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (Search(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Search(char[][] board, string word, int x, int y, int d)
        {
            if (x < 0 || x == W || y < 0 || y == H || word[d] != board[y][x])
            {
                return false;
            }

            if (d == word.Length - 1)
            {
                return true;
            }

            char cur = board[y][x];
            board[y][x] = '0';
            bool found = Search(board, word, x + 1, y, d + 1) ||
                         Search(board, word, x - 1, y, d + 1) ||
                         Search(board, word, x, y + 1, d + 1) ||
                         Search(board, word, x, y - 1, d + 1);
            board[y][x] = cur;

            return found;
        }
    }
}