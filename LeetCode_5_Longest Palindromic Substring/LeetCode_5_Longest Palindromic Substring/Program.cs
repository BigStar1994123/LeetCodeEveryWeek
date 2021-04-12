using System;

namespace LeetCode_5_Longest_Palindromic_Substring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var text = "abab";
            Console.WriteLine(s.LongestPalindrome(text));
        }
    }

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length == 1)
            {
                return s;
            }

            var maxLength = 0;
            var startPosition = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var currentLength = Math.Max(GetLens(s, i, i), GetLens(s, i, i + 1));
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    startPosition = i - (currentLength - 1) / 2;
                }
            }

            return s.Substring(startPosition, maxLength);
        }

        private int GetLens(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }
    }
}