using System;

namespace Leetcode53_Maximum_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new Solution();
            var result = s.MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            // nums: [-2, 1, -3, 4, -1, 2, 1, -5, 4]
            // f::   [-2, 1, -2, 4,  3, 5, 6,  1, 5]
            var ans = nums[0];
            var sum = nums[0];

            for(var i = 1; i < nums.Length; i++)
            {
                sum = Math.Max(sum + nums[i], nums[i]);
                if (sum > ans)
                {
                    ans = sum;
                }
            }

            return ans;
        }
    }
}
