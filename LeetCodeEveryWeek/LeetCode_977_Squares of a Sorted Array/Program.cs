using System;
using System.Linq;

namespace LeetCode_977_Squares_of_a_Sorted_Array
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { -4, -1, 0, 3, 10 };

            var s = new Solution();
            nums = s.SortedSquares(nums);
            nums.ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("[{0}]", string.Join(", ", nums));
            Console.WriteLine($"{string.Join(", ", nums)}");
            Array.ForEach(nums, Console.WriteLine);
        }

        public class Solution
        {
            public int[] SortedSquares(int[] nums)
            {
                // 雙指針法
                var result = Enumerable.Repeat<int>(0, nums.Length).ToArray();
                var lastPoint = nums.Length - 1;

                var left = 0;
                var right = nums.Length - 1;

                while (left <= right)
                {
                    var leftPow = Math.Pow(nums[left], 2);
                    var rightPow = Math.Pow(nums[right], 2);
                    if (leftPow > rightPow)
                    {
                        result[lastPoint] = Convert.ToInt32(leftPow);
                        left++;
                    }
                    else
                    {
                        result[lastPoint] = Convert.ToInt32(rightPow);
                        right--;
                    }

                    lastPoint--;
                }

                return result;
            }
        }
    }
}