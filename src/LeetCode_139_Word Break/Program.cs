using System;
using System.Collections.Generic;

namespace LeetCode_139_Word_Break
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var text = "aaaaaaa";
            var wordDict = new List<string> { "aaa", "aaaa" };

            var s = new Solution();
            Console.WriteLine(s.WordBreak(text, wordDict));
        }

        public class Solution
        {
            private Dictionary<string, bool> map = new Dictionary<string, bool>();

            public bool WordBreak(string s, IList<string> wordDict)
            {
                var set = new HashSet<string>();

                foreach (var word in wordDict)
                {
                    set.Add(word);
                }

                return set.Contains(s) || Find(s, set);

                //foreach (var word in wordDict)
                //{
                //    dp.Add(word, true);
                //}

                //var left = 0;
                //var length = 1;

                //while (left + length <= s.Length)
                //{
                //    var text = s.Substring(left, length);
                //    if (!dp.ContainsKey(text))
                //    {
                //        dp.Add(text, false);
                //        length++;
                //    }
                //    else
                //    {
                //        if (!dp[text])
                //        {
                //            length++;
                //            continue;
                //        }

                //        if (left + length != s.Length)
                //        {
                //            left += length;
                //            length = 1;
                //        }
                //        else
                //        {
                //            return true;
                //        }
                //    }
                //}

                //return false;
            }

            public bool Find(string s, HashSet<string> set)
            {
                if (map.ContainsKey(s))
                {
                    return map[s];
                }

                if (string.IsNullOrEmpty(s) || set.Contains(s))
                {
                    return true;
                }

                for (int i = 1, len = s.Length; i < len; i++)
                {
                    var sub1 = s.Substring(0, i);
                    var sub2 = s[i..];
                    if (set.Contains(sub1) && Find(sub2, set))
                    {
                        // 儲存結果
                        map.Add(s, true);
                        return true;
                    }
                }

                // 儲存結果
                map.Add(s, false);
                return false;
            }
        }
    }
}