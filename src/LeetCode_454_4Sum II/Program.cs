using System;
using System.Collections.Generic;

namespace LeetCode_454_4Sum_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var nums1 = new int[] { 1, 2 };
            //var nums2 = new int[] { -2, -1 };
            //var nums3 = new int[] { -1, 2 };
            //var nums4 = new int[] { 0, 2 };
            var nums1 = new int[] { -1, -1 };
            var nums2 = new int[] { -1, 1 };
            var nums3 = new int[] { -1, 1 };
            var nums4 = new int[] { 1, -1 };

            var s = new Solution();
            Console.WriteLine(s.FourSumCount(nums1, nums2, nums3, nums4));
        }

        public class Solution
        {
            public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
            {
                var hash = new Dictionary<int, int>();

                foreach (var item1 in nums1)
                {
                    foreach (var item2 in nums2)
                    {
                        var val = item1 + item2;

                        if (hash.ContainsKey(0 - val))
                        {
                            hash[0 - val]++;
                        }
                        else
                        {
                            hash[0 - val] = 1;
                        }
                    }
                }

                var count = 0;

                foreach (var item3 in nums3)
                {
                    foreach (var item4 in nums4)
                    {
                        var val = item3 + item4;

                        if (hash.ContainsKey(val))
                        {
                            count += hash[val];
                        }
                    }
                }

                return count;
            }
        }
    }
}