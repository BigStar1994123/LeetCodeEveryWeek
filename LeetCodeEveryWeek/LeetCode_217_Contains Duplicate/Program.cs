using System;
using System.Collections.Generic;

namespace LeetCode_217_Contains_Duplicate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1, 23, 3, 4, 5 };

            var s = new Solution();
            Console.WriteLine(s.ContainsDuplicate(nums));
        }

        public class Solution
        {
            public bool ContainsDuplicate(int[] nums)
            {
                var hash = new HashSet<int>();

                foreach (var num in nums)
                {
                    if (hash.Contains(num))
                    {
                        return true;
                    }

                    hash.Add(num);
                }

                return false;
            }
        }
    }
}