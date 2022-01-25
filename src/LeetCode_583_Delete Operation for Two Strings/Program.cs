using System;
using System.Linq;

namespace LeetCode_583_Delete_Operation_for_Two_Strings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var w1 = "leetcode";
            var w2 = "etco";

            Console.WriteLine(s.MinDistance(w1, w2));
        }

        public class Solution
        {
            public int MinDistance(string word1, string word2)
            {
                var dp = Enumerable.Range(0, word1.Length + 1).Select(x => Enumerable.Repeat(0, word2.Length + 1).ToArray()).ToArray();
                for (int i = 1; i <= word1.Length; i++)
                {
                    for (int j = 1; j <= word2.Length; j++)
                    {
                        if (word1[i - 1] == word2[j - 1])
                        {
                            dp[i][j] = dp[i - 1][j - 1] + 1;
                        }
                        else
                        {
                            dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                        }
                    }
                }

                return word1.Length + word2.Length - dp[word1.Length][word2.Length] * 2;
            }
        }
    }
}