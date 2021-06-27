using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_347_Top_K_Frequent_Elements
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
            var k = 2;

            var s = new Solution();
            Console.WriteLine(string.Join(",", s.TopKFrequent(nums, k)));
        }

        public class Solution
        {
            public int[] TopKFrequent(int[] nums, int k)
            {
                var dic = new Dictionary<int, int>();
                var result = new List<int>();

                foreach (var num in nums)
                {
                    if (dic.ContainsKey(num))
                    {
                        dic[num] += 1;
                    }
                    else
                    {
                        dic.Add(num, 1);
                    }
                }

                var list = dic.OrderByDescending(f => f.Value).Take(k).ToList();

                for (int i = 0; i < k; i++)
                {
                    result.Add(list.ElementAtOrDefault(i).Key);
                }

                return result.ToArray();
            }
        }
    }
}