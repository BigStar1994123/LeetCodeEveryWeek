using System;
using System.Collections.Generic;

namespace LeetCode_242_Valid_Anagram
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var a = "ab";
            var b = "a";

            Console.WriteLine(s.IsAnagram(a, b));
        }

        public class Solution
        {
            public bool IsAnagram(string s, string t)
            {
                if (s.Length != t.Length)
                {
                    return false;
                }

                var sDic = new Dictionary<char, int>();
                var tDic = new Dictionary<char, int>();

                foreach (var sChar in s)
                {
                    if (sDic.ContainsKey(sChar))
                    {
                        sDic[sChar]++;
                    }
                    else
                    {
                        sDic.Add(sChar, 1);
                    }
                }

                foreach (var tChar in t)
                {
                    if (tDic.ContainsKey(tChar))
                    {
                        tDic[tChar]++;
                    }
                    else
                    {
                        tDic.Add(tChar, 1);
                    }
                }

                foreach (var tDicItem in tDic)
                {
                    if (!sDic.ContainsKey(tDicItem.Key) || sDic[tDicItem.Key] != tDicItem.Value)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}