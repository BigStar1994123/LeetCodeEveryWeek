using System;

namespace LeetCode_35_Search_Insert_Position
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1, 3, 5, 6 };
            var target = 2;

            var s = new Solution();
            Console.WriteLine(s.SearchInsert(nums, target));
        }

        public class Solution
        {
            public int SearchInsert(int[] nums, int target)
            {
                var left = 0;
                var right = nums.Length - 1;

                while (left <= right)
                {
                    var mid = (left + right) / 2;

                    if (nums[mid] > target)
                    {
                        right = mid - 1;
                    }
                    else if (nums[mid] < target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }

                return right + 1;
            }
        }
    }
}