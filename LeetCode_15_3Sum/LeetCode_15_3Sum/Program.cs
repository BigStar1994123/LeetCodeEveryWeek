using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_15_3Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var nums = new int[] { 0, 0, 0, 0 };
            //Console.WriteLine(s.TwoSum(nums, 6));
            Console.WriteLine(s.ThreeSum(nums));
        }
    }

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            var copyNums = nums.ToArray();
            Array.Sort(copyNums);
            int? lastDoNum = null;
            foreach (var num in copyNums)
            {
                copyNums = copyNums.Skip(1).ToArray();

                if (lastDoNum == num)
                {
                    continue;
                }

                var target = 0 - num;
                var twoSumResult = MultiTwoSum(copyNums, target);
                if (twoSumResult != null)
                {
                    foreach (var twoSum in twoSumResult)
                    {
                        result.Add(new List<int> { num, twoSum.Num1, twoSum.Num2 });
                    }
                }

                lastDoNum = num;
            }

            return result;
        }

        private IList<(int Num1, int Num2)> MultiTwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            var result = new List<(int Num1, int Num2)>();
            foreach (var num in nums)
            {
                if (dic.ContainsKey(num))
                {
                    if (result.IndexOf((dic[num], num)) == -1)
                    {
                        result.Add((dic[num], num));
                    }
                }

                if (!dic.ContainsKey(target - num))
                {
                    dic.Add(target - num, num);
                }
            }

            return result;
        }
    }
}