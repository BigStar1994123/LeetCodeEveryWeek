using System;

namespace LeetCode_647_Palindromic_Substrings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var text = "aabaaca";

            var s = new Solution();
            Console.WriteLine(s.CountSubstrings(text));
        }

        public class Solution
        {
            public int CountSubstrings(string s)
            {
                int n = s.Length;

                if (n == 1)
                {
                    return 1;
                }

                var dp = new int[n + 1][];

                for (int i = 0; i < n + 1; i++)
                {
                    dp[i] = new int[n + 1];
                }

                dp[0][0] = 1; // "" is palindromic

                for (int i = 1; i <= n; i++)
                {
                    dp[i][i] = 1;
                }

                var count = n;  // one char string is palindromic

                for (int length = 2; length <= n; length++)
                {
                    for (int start = 0; start + length <= n; start++)
                    {
                        int end = length + start - 1;
                        //                          two chars         || at least three chars
                        if (s[start] == s[end] && ((start + 1 == end) || dp[start + 1][end - 1] == 1))
                        {
                            count++;
                            dp[start][end] = 1;
                        }
                    }
                }

                return count;
            }
        }
    }
}