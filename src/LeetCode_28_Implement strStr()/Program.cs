using System;

namespace LeetCode_28_Implement_strStr__
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var haystack = "aaabcaaaaaabc";

            var needle = "aabaaf";

            var s = new Solution3();

            Console.WriteLine(s.StrStr(haystack, needle));
        }

        public class Solution3
        {
            public int StrStr(string haystack, string needle)
            {
                if (needle.Length == 0)
                {
                    return 0;
                }

                var next = GetNext(needle);
                var j = 0;

                for (int i = 0; i < haystack.Length; i++)
                {
                    while (j > 0 && haystack[i] != needle[j])
                    {
                        j = next[j - 1];
                    }

                    if (haystack[i] == needle[j])
                    {
                        j++;
                    }

                    if (j == needle.Length)
                    {
                        return i - needle.Length + 1;
                    }
                }

                return -1;
            }

            /// <summary>
            /// aabaaf: 0 1 0 1 2 0
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            private int[] GetNext(string s)
            {
                var next = new int[s.Length];
                var j = 0;
                next[0] = 0;

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

        /// <summary>
        /// With KMP (前墜表-1)
        /// </summary>
        public class Solution2
        {
            public int StrStr(string haystack, string needle)
            {
                if (needle.Length == 0)
                {
                    return 0;
                }

                int[] next = GetNext(needle);
                int j = -1;
                for (int i = 0; i < haystack.Length; i++)
                {
                    while (j >= 0 && haystack[i] != needle[j + 1])
                    {
                        j = next[j];
                    }
                    if (haystack[i] == needle[j + 1])
                    {
                        j++;
                    }
                    if (j == needle.Length - 1)
                    {
                        return (i - needle.Length + 1);
                    }
                }

                return -1;
            }

            private int[] GetNext(string s)
            {
                var result = new int[s.Length];

                var j = -1;
                result[0] = j;

                for (int i = 1; i < s.Length; i++)
                {
                    while (j >= 0 && s[i] != s[j + 1])
                    {
                        j = result[j];
                    }

                    if (s[i] == s[j + 1])
                    {
                        j++;
                    }

                    result[i] = j;
                }

                return result;
            }
        }

        public class Solution
        {
            public int StrStr(string haystack, string needle)
            {
                if (haystack.Length < needle.Length)
                {
                    return -1;
                }

                if (needle.Length == 0)
                {
                    return 0;
                }

                var firstNeedleChar = needle[0];
                for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
                {
                    if (haystack[i] == firstNeedleChar)
                    {
                        for (int j = 0; j < needle.Length; j++)
                        {
                            if (haystack[i + j] != needle[j])
                            {
                                break;
                            }

                            if (j == needle.Length - 1)
                            {
                                return i;
                            }
                        }
                    }
                }

                return -1;
            }
        }
    }
}