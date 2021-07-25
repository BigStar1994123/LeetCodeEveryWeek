using System;

namespace _28._Implement_strStr__
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var haystack = "abcde";

            var needle = "cd";

            var s = new Solution();

            Console.WriteLine(haystack, needle);
        }

        public class Solution
        {
            public int StrStr(string haystack, string needle)
            {
                if (needle.Length == 0)
                {
                    return 0;
                }

                var firstNeedleChar = needle[0];
                for (int i = 0; i < haystack.Length; i++)
                {
                    if (haystack[i] == firstNeedleChar)
                    {
                        var check = true;
                        for (int j = 1; j < needle.Length; j++)
                        {
                            if (haystack[i] != needle[j])
                            {
                                check = false;
                                break;
                            }
                        }

                        if (check) return i;
                    }
                }

                return -1;
            }
        }
    }
}