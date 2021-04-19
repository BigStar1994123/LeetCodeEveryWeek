using System;

namespace LeetCode_33_Search_in_Rotated_Sorted_Array
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var nums = new int[] { 5, 1, 3 };
            var target = 3;

            Console.WriteLine(s.Search(nums, target));
        }
    }

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            var length = nums.Length;
            if (length == 0)
            {
                return -1;
            }

            var flag = false;
            var firstNum = nums[0];

            var index = 0;
            while (index < length)
            {
                var num = nums[index];
                if (target == num)
                {
                    return index;
                }

                if (num < firstNum && target > firstNum)
                {
                    return -1;
                }

                index++;
            }

            return -1;
        }
    }
}