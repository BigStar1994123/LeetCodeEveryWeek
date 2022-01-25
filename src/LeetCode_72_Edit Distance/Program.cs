using System;
using System.Linq;

namespace LeetCode_72_Edit_Distance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var w1 = "horse";
            var w2 = "ros";

            Console.WriteLine(s.MinDistance(w1, w2));
        }

        public class Solution
        {
            public int MinDistance(string word1, string word2)
            {
                var dp = Enumerable.Range(0, word1.Length + 1).Select(x => Enumerable.Repeat(0, word2.Length + 1).ToArray()).ToArray();
                for (int i = 0; i <= word1.Length; i++)
                {
                    dp[i][0] = i;
                }
                for (int j = 0; j <= word2.Length; j++)
                {
                    dp[0][j] = j;
                }

                for (int i = 1; i <= word1.Length; i++)
                {
                    for (int j = 1; j <= word2.Length; j++)
                    {
                        if (word1[i - 1] == word2[j - 1])
                        {
                            dp[i][j] = dp[i - 1][j - 1];
                        }
                        else
                        {
                            dp[i][j] = new[] { dp[i - 1][j - 1], dp[i - 1][j], dp[i][j - 1] }.Min() + 1;
                        }
                    }
                }

                return dp[word1.Length][word2.Length];
            }
        }
    }
}