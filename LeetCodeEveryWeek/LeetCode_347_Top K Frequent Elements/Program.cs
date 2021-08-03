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

            var s = new Solution2();
            Console.WriteLine(string.Join(",", s.TopKFrequent(nums, k)));
        }

        public class Solution2
        {
            public int[] TopKFrequent(int[] nums, int k)
            {
                var numToFreq = new Dictionary<int, int>();
                foreach (var n in nums)
                    numToFreq[n] = numToFreq.GetValueOrDefault(n, 0) + 1;
                //return numToFreq.OrderByDescending(x => x.Value).Take(k).Select(x => x.Key).ToArray();

                var heapDict = new SortedDictionary<int, object>(Comparer<int>.Create((x, y) =>
                {
                    var result = numToFreq[y].CompareTo(numToFreq[x]);
                    return result != 0 ? result : x.CompareTo(y);
                }));

                foreach (var i in numToFreq.Keys)
                {
                    heapDict[i] = null;
                    if (heapDict.Count > k)
                        heapDict.Remove(heapDict.Last().Key);
                }

                return heapDict.Keys.ToArray();
            }
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