using System;
using System.Collections.Generic;

namespace LeetCode_76_Minimum_Window_Substring
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var ss = "ADBANC";
            var t = "BAC";

            Console.WriteLine(s.MinWindow(ss, t));
        }
    }

    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            string result = "";

            var letterCnt = new Dictionary<char, int>();

            var left = 0;
            var cnt = 0;
            var minLen = int.MaxValue;

            foreach (var c in t)
            {
                if (!letterCnt.ContainsKey(c))
                {
                    letterCnt.Add(c, 1);
                }
                else
                {
                    letterCnt[c] += 1;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (letterCnt.ContainsKey(s[i]) && --letterCnt[s[i]] >= 0)
                {
                    ++cnt;
                }

                while (cnt == t.Length)
                {
                    if (minLen > i - left + 1)
                    {
                        minLen = i - left + 1;
                        result = s.Substring(left, minLen);
                    }

                    if (letterCnt.ContainsKey(s[left]) && ++letterCnt[s[left]] > 0)
                    {
                        --cnt;
                    }

                    ++left;
                }
            }

            return result;
        }
    }
}