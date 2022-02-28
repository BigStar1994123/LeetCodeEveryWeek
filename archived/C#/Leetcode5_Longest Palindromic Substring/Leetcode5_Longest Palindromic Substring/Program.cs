using System;

namespace Leetcode5_Longest_Palindromic_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            Console.WriteLine(s.LongestPalindrome("babad"));

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public struct Pos
        {
            public int FirstPos;
            public int LastPos;
        }

        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            var p = new Pos[s.Length];

        }
    }
}
