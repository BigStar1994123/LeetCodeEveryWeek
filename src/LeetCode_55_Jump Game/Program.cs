using System;
using System.Linq;

namespace LeetCode_55_Jump_Game
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution2();
            var nums = new int[] { 2, 1, 1, 0, 4 };

            Console.WriteLine(s.CanJump(nums));
        }
    }

    public class Solution2
    {
        public bool CanJump(int[] nums)
        {
            var lastPosition = 0;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= lastPosition)
                {
                    lastPosition = i;
                }
            }

            return lastPosition == 0;
        }
    }

    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            var finalPosition = nums.Length - 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= finalPosition)
                {
                    finalPosition = i;
                }
            }

            return finalPosition == 0;
        }
    }
}