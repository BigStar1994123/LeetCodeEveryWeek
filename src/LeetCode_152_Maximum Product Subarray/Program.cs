using System;

namespace LeetCode_152_Maximum_Product_Subarray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 2, 3, -2, 4 };

            var s = new Solution();
            Console.WriteLine(s.MaxProduct(nums));
        }

        public class Solution
        {
            public int MaxProduct(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }

                var maxProduct = nums[0];
                var curMax = nums[0];
                var curMin = nums[1];

                for (int i = 1; i < nums.Length; i++)
                {
                    var nextMax = curMax * nums[i];
                    var nextMin = curMin * nums[i];

                    curMax = Math.Max(nums[i], Math.Max(nextMax, nextMin));
                    curMin = Math.Min(nums[i], Math.Min(nextMax, nextMin));
                    maxProduct = Math.Max(maxProduct, curMax);
                }

                return maxProduct;

                //var max = nums[0];
                //var tempValue = 1;
                //var tempNegitiveValue = 1;

                //foreach (var num in nums)
                //{
                //    if (num > 0)
                //    {
                //        tempValue *= num;
                //        max = Math.Max(max, tempValue);
                //    }
                //    else if (num < 0)
                //    {
                //        if (tempNegitiveValue < 0)
                //        {
                //            tempValue = tempValue * num * tempNegitiveValue;
                //            tempNegitiveValue = 1;
                //            max = Math.Max(max, tempValue);
                //        }
                //        else
                //        {
                //            tempNegitiveValue = tempValue * num;
                //            tempValue = 1;
                //            max = Math.Max(max, tempNegitiveValue);
                //        }
                //    }
                //    else if (num == 0)
                //    {
                //        max = Math.Max(max, 0);
                //        tempValue = 1;
                //        tempNegitiveValue = 1;
                //    }
                //}

                //return max;
            }
        }
    }
}