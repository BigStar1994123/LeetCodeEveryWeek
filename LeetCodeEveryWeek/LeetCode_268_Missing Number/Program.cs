using System;
using System.Linq;

namespace LeetCode_268_Missing_Number
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var nums = new int[] { 3, 0, 1 };

            Console.WriteLine(s.MissingNumber(nums));
        }

        public class Solution
        {
            public int MissingNumber(int[] nums)
            {
                //var n = nums.Length + 1;

                //var max = ((0 + n - 1) * n) / 2;

                //var numsMax = nums.Sum();

                return (((0 + nums.Length) * (nums.Length + 1)) / 2) - nums.Sum();
            }
        }
    }
}