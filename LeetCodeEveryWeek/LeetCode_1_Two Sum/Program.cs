using System;
using System.Collections.Generic;

namespace LeetCode_1_Two_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var nums = new List<int> { 2, 7, 11, 15 };
            var target = 9;

            var result = s.TwoSum(nums.ToArray(), target);
            Console.WriteLine(string.Join(",", result));

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    return new int[] { dic[nums[i]], i };
                }

                dic.Add(target - nums[i], i);
            }

            return new int[] { };
        }
    }
}