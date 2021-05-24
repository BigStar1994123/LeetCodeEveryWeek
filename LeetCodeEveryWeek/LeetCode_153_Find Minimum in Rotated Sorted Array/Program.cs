using System;

namespace LeetCode_153_Find_Minimum_in_Rotated_Sorted_Array
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 3, 4, 5, 1, 2 };

            var s = new Solution();
            Console.WriteLine(s.FindMin(nums));
        }

        public class Solution
        {
            public int FindMin(int[] nums)
            {
                // O(LogN)
                return FindMin(nums, 0, nums.Length - 1);

                // O(N)
                //var compareNum = nums[0];

                //for (int i = 1; i < nums.Length; i++)
                //{
                //    if (nums[i] < compareNum)
                //    {
                //        return nums[i];
                //    }

                //    compareNum = nums[i];
                //}

                //return nums[0];
            }

            public int FindMin(int[] nums, int l, int r)
            {
                // Only 1 or 2 elements
                if (l + 1 >= r)
                {
                    return Math.Min(nums[l], nums[r]);
                }

                // 表示為 sorted
                if (nums[l] < nums[r])
                {
                    return nums[l];
                }

                var mid = l + ((r - l) / 2);

                return Math.Min(FindMin(nums, l, mid - 1), FindMin(nums, mid, r));
            }
        }
    }
}