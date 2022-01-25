using System;
using System.Linq;

namespace LeetCode_516_Longest_Palindromic_Subsequence
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var text = "aaaba";

            Console.WriteLine(s.LongestPalindromeSubseq(text));
        }

        public class Solution
        {
            public int LongestPalindromeSubseq(string s)
            {
                var dp = Enumerable.Range(0, s.Length).Select(x => Enumerable.Repeat(0, s.Length).ToArray()).ToArray();
                for (int i = 0; i < s.Length; i++)
                {
                    dp[i][i] = 1;
                }

                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (s[i] == s[j])
                        {
                            dp[i][j] = dp[i - 1][j + 1] + 2;
                        }
                        else
                        {
                            dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j + 1]);
                        }
                    }
                }

                return dp[s.Length - 1][0];
            }
        }
    }
}