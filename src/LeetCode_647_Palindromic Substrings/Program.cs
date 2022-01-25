using System;
using System.Linq;

namespace LeetCode_647_Palindromic_Substrings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var text = "aaaaaa";

            var s = new Solution();
            var s2 = new Solution2();
            Console.WriteLine(s.CountSubstrings(text));
            Console.WriteLine(s2.CountSubstrings(text));
        }

        public class Solution2
        {
            public int CountSubstrings(string s)
            {
                var dp = Enumerable.Range(0, s.Length).Select(x => Enumerable.Repeat(false, s.Length).ToArray()).ToArray();
                var result = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (s[i] == s[j])
                        {
                            if (i - j <= 1)
                            {
                                result++;
                                dp[i][j] = true;
                            }
                            else if (dp[i - 1][j + 1])
                            {
                                result++;
                                dp[i][j] = true;
                            }
                        }
                    }
                }

                return result;
            }
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