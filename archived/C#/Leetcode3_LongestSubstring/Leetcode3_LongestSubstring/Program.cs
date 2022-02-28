using System;
using System.Collections.Generic;

namespace Leetcode3_LongestSubstring
{
    // https://leetcode.com/problems/longest-substring-without-repeating-characters/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            Console.WriteLine(s.LengthOfLongestSubstring("abcabcbb"));
            Console.Read();
        }

        public class Solution
        {
            public int LengthOfLongestSubstring(string s)
            {
                if (s.Length == 0)
                {
                    return 0;
                }

                var charDic = new Dictionary<char, int>();
                var counter = 0;
                var winCounter = 0;
                for (var i = 0; i < s.Length; i++)
                {
                    var thisChar = s[i];
                    if (!charDic.ContainsKey(thisChar))
                    {
                        counter += 1;
                        charDic.Add(thisChar, i);
                    }
                    else // charDic.ContainsKey(s[i])
                    {
                        if (counter > winCounter)
                        {
                            winCounter = counter;
                        }
                        counter = 0;
                        i = charDic[thisChar];
                        charDic.Clear();
                    }
                }

                return Math.Max(winCounter, counter);
            }
        }        
    }
}
