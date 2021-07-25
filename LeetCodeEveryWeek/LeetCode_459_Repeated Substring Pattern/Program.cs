using System;

namespace LeetCode_459_Repeated_Substring_Pattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var text = "abcabcabdc";

            var s = new Solution();
            Console.WriteLine(s.RepeatedSubstringPattern(text));
        }

        /// <summary>
        /// Use KMP
        /// </summary>
        public class Solution
        {
            public bool RepeatedSubstringPattern(string s)
            {
                if (s.Length == 0)
                {
                    return false;
                }

                var next = GetNext(s);
                var len = s.Length;
                for (int i = 0; i < s.Length; i++)
                {
                    if (next[len - 1] != 0 && len % (len - (next[len - 1])) == 0)
                    {
                        return true;
                    }
                }

                return false;
            }

            private int[] GetNext(string s)
            {
                var next = new int[s.Length];
                next[0] = 0;
                var j = 0;

                for (int i = 1; i < s.Length; i++)
                {
                    while (j > 0 && s[i] != s[j])
                    {
                        j = next[j - 1];
                    }

                    if (s[i] == s[j])
                    {
                        j++;
                    }

                    next[i] = j;
                }

                return next;
            }
        }
    }
}