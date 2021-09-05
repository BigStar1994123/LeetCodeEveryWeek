using System;

namespace LeetCode_704_Binary_Search
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { -1, 0, 3, 5, 9, 12 };
            var target = 13;

            var s = new Solution();
            Console.WriteLine(s.Search(nums, target));
        }

        public class Solution
        {
            public int Search(int[] nums, int target)
            {
                var left = 0;
                var right = nums.Length - 1;

                while (left <= right)
                {
                    var mid = (left + right) / 2;
                    var num = nums[mid];

                    if (num == target)
                    {
                        return mid;
                    }
                    else if (num > target)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                return -1;
            }
        }
    }
}