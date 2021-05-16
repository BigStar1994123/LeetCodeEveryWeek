using System;
using System.Collections.Generic;

namespace LeetCode_128_Longest_Consecutive_Sequence
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { -2, -3, -3, 7, -3, 0, 5, 0, -8, -4, -1, 2 };
            var s = new Solution();

            Console.WriteLine(s.LongestConsecutive(nums));
        }

        public class Solution
        {
            public int LongestConsecutive(int[] nums)
            {
                var dic = new Dictionary<int, int>();
                var result = 0;

                foreach (var num in nums)
                {
                    if (dic.ContainsKey(num))
                    {
                    }
                    else if (!dic.ContainsKey(num - 1) && !dic.ContainsKey(num + 1))
                    {
                        dic.Add(num, 1);

                        result = Math.Max(result, 1);
                    }
                    else if (dic.ContainsKey(num - 1) && dic.ContainsKey(num + 1))
                    {
                        var leftLen = dic[num - 1];
                        var rightLen = dic[num + 1];

                        var len = leftLen + rightLen + 1;

                        dic[num - leftLen] = len;
                        dic[num + rightLen] = len;
                        dic.Add(num, len);

                        result = Math.Max(result, len);
                    }
                    else if (dic.ContainsKey(num - 1))
                    {
                        var len = dic[num - 1];
                        dic[num - len] = len + 1;
                        dic.Add(num, len + 1);
                        result = Math.Max(result, len + 1);
                    }
                    else if (dic.ContainsKey(num + 1))
                    {
                        var len = dic[num + 1];
                        dic[num + len] = len + 1;
                        dic.Add(num, len + 1);
                        result = Math.Max(result, len + 1);
                    }
                }

                return result;
            }
        }
    }
}