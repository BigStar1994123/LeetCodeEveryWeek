using System;
using System.Text.RegularExpressions;

namespace LeetCode_125_Valid_Palindrome
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var text = "Marge, let's \"[went].\" I await {news} telegram.";
            var text = "0P";
            var s = new Solution();
            Console.WriteLine(s.IsPalindrome(text));
        }

        public class Solution
        {
            public bool IsPalindrome(string s)
            {
                s = Regex.Replace(s, "(?![0-9|A-Z|a-z]).", string.Empty);
                s = s.ToLower().Trim();

                var left = 0;
                var right = s.Length - 1;

                while (left < s.Length / 2)
                {
                    if (s[left] != s[right])
                    {
                        return false;
                    }

                    left++;
                    right--;
                }

                return true;
            }
        }
    }
}