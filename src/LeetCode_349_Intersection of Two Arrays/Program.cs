using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_349_Intersection_of_Two_Arrays
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var num1 = new int[] { 1, 2, 2, 1 };
            var num2 = new int[] { 2, 2 };

            var s = new Solution();
            var result = s.Intersection(num1, num2);
        }

        public class Solution
        {
            public int[] Intersection(int[] nums1, int[] nums2)
            {
                var hash = new HashSet<int>();
                var resultHash = new HashSet<int>();

                foreach (var num in nums1)
                {
                    hash.Add(num);
                }

                foreach (var num in nums2)
                {
                    if (hash.Contains(num))
                    {
                        resultHash.Add(num);
                    }
                }

                return resultHash.ToArray();
            }
        }
    }
}