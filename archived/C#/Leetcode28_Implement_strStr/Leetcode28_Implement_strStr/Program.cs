using System;

namespace Leetcode28_Implement_strStr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new Solution();
            Console.WriteLine(s.StrStr("hello", "llo"));

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int StrStr(string haystack, string needle)
        {
            //return haystack.IndexOf(needle);

            var nLength = needle.Length;
            for (var i = 0; i < haystack.Length - nLength + 1; i++)
            {
                if (haystack.Substring(i, nLength) == needle)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
