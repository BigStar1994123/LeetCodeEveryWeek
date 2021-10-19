using System;
using System.Collections.Generic;

namespace LeetCode_763_Partition_Labels
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = "ababcbacadefegdehijhklij";

            var sol = new Solution();
            var result = sol.PartitionLabels(s);
            Console.WriteLine(string.Join(",", result));
        }

        public class Solution
        {
            public IList<int> PartitionLabels(string s)
            {
                var hash = new Dictionary<char, int>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (!hash.ContainsKey(s[i]))
                    {
                        hash.Add(s[i], i);
                    }
                    else
                    {
                        hash[s[i]] = i;
                    }
                }

                var result = new List<int>();
                int left = 0, right = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    right = Math.Max(right, hash[s[i]]);
                    if (i == right)
                    {
                        result.Add(right - left + 1);
                        left = i + 1;
                    }
                }

                return result;
            }
        }
    }
}