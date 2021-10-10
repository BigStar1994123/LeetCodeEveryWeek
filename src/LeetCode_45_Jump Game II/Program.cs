using System;
using System.Collections.Generic;

namespace LeetCode_45_Jump_Game_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 2, 3, 0, 1, 4 };

            var s = new Solution();
            Console.WriteLine(s.Jump(nums));
        }

        public class Solution
        {
            public int Jump(int[] nums)
            {
                var lastPosition = nums.Length - 1;
                var dict = new Dictionary<int, int>();
                dict.Add(nums.Length - 1, 0);

                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    for (int j = nums[i]; j > 0; j--)
                    {
                        var findPosition = i + j >= lastPosition ? lastPosition : i + j;

                        // 表示可以走到終點
                        if (dict.ContainsKey(findPosition))
                        {
                            if (!dict.ContainsKey(i))
                            {
                                dict.Add(i, dict[findPosition] + 1);
                            }
                            else
                            {
                                var minValue = Math.Min(dict[i], dict[findPosition] + 1);
                                dict[i] = minValue;
                            }
                        }
                    }
                }

                return dict[0];
            }
        }
    }
}