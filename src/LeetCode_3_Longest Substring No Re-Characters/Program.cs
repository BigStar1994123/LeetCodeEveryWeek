using System;
using System.Collections.Generic;

namespace LeetCode_3_Longest_Substring_No_Re_Characters
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var text = "abcabcbb";
            //var text = "jbpnbwwd";
            Console.WriteLine(s.LengthOfLongestSubstring(text));
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var set = new HashSet<char>();

            var pointer = 0;
            var maxCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                var targetChar = s[i];

                if (set.Contains(targetChar))
                {
                    while (s[pointer] != targetChar)
                    {
                        set.Remove(s[pointer]);
                        pointer++;
                    }

                    pointer++;
                }
                else
                {
                    set.Add(targetChar);
                }

                var count = i - pointer + 1;
                maxCount = Math.Max(maxCount, count);
            }

            return maxCount;

            //var dic = new Dictionary<char, int>();

            //char? lastChar = null;
            //var pointer = -1;
            //var maxCount = 1;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (dic.ContainsKey(s[i]))
            //    {
            //        pointer = dic[s[i]];

            //        if (s[i] == lastChar)
            //        {
            //            dic.Clear();
            //        }

            //        dic[s[i]] = i;
            //    }
            //    else
            //    {
            //        var count = i - pointer;
            //        maxCount = count > maxCount ? count : maxCount;
            //        dic.Add(s[i], i);
            //    }

            //    lastChar = s[i];
            //}

            //return maxCount;

            //var set = new HashSet<char>();

            //char? lastChar = null;
            //var resultList = new List<int>();
            //var count = 0;
            //foreach (var c in s)
            //{
            //    if (set.Contains(c))
            //    {
            //        if (c == lastChar)
            //        {
            //            set.Clear();
            //            set.Add(c);
            //            resultList.Add(count);
            //            count = 1;
            //            continue;
            //        }

            //        continue;
            //    }

            //    lastChar = c;
            //    set.Add(c);
            //    count++;
            //}

            //resultList.Add(count);

            //return resultList.Max(x => x);
        }
    }
}