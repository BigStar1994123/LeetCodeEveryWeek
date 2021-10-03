using System;
using System.Linq;

namespace LeetCode_1005_Maximize_Sum_Of_Array_After_K_Negations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var nums = new int[] { 2, -3, -1, 5, -4 };
            //var k = 2;

            //var nums = new int[] { 3, -1, 0, 2 };
            //var k = 3;

            //var nums = new int[] { 1, 3, 2, 6, 7, 9 };
            //var k = 6;

            //var nums = new int[] { -8, 3, -5, -3, -5, -2 };
            //var k = 6;

            var nums = new int[] { -4, -2, -3 };
            var k = 4;

            var s = new Solution();
            Console.WriteLine(s.LargestSumAfterKNegations(nums, k));
        }

        public class Solution
        {
            public int LargestSumAfterKNegations(int[] nums, int k)
            {
                Array.Sort(nums);

                var index = 0;
                var count = 0;
                for (; index < nums.Length && count < k; index++)
                {
                    if (nums[index] >= 0)
                    {
                        break;
                    }

                    nums[index] = -1 * nums[index];
                    count++;
                }

                if (count == k)
                {
                    return nums.Sum();
                }

                var targetIndexRepeat = index == 0 ? 0 :
                    index == nums.Length ? index - 1 :
                    Math.Abs(nums[index - 1]) <= Math.Abs(nums[index]) ? index - 1 : index;

                if ((k - index) % 2 == 1)
                {
                    return nums.Sum() - (2 * nums[targetIndexRepeat]);
                }
                else
                {
                    return nums.Sum();
                }
            }
        }
    }
}