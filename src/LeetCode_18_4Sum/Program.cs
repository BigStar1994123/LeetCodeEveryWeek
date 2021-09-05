using System;
using System.Collections.Generic;

namespace LeetCode_18_4Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var nums = new int[] { 1, 0, -1, 0, -2, 2 };
            var target = 0;

            var result = s.FourSum(nums, target);
        }

        public class Solution
        {
            public IList<IList<int>> FourSum(int[] nums, int target)
            {
                var result = new List<IList<int>>();

                Array.Sort(nums);

                for (int i = 0; i < nums.Length - 3; i++)
                {
                    if (i > 0 && nums[i - 1] == nums[i])
                    {
                        continue;
                    }

                    for (int j = i + 1; j < nums.Length - 2; j++)
                    {
                        if (j > i + 1 && nums[j - 1] == nums[j])
                        {
                            continue;
                        }

                        var left = j + 1;
                        var right = nums.Length - 1;

                        var ij = nums[i] + nums[j];

                        while (left < right)
                        {
                            if (ij + nums[left] + nums[right] == target)
                            {
                                result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                                while (left < right && nums[right] == nums[right - 1])
                                {
                                    right--;
                                }
                                while (left < right && nums[left] == nums[left + 1])
                                {
                                    left++;
                                }

                                left++;
                                right--;
                            }
                            else if (ij + nums[left] + nums[right] < target)
                            {
                                left++;
                            }
                            else if (ij + nums[left] + nums[right] > target)
                            {
                                right--;
                            }
                        }
                    }
                }

                return result;
            }
        }
    }
}