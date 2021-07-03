using System;
using System.Linq;

namespace LeetCode_238_Product_of_Array_Except_Self
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1, 2, 3, 4 };

            var s = new Solution();
            var a = s.ProductExceptSelf(nums);
        }

        public class Solution
        {
            public int[] ProductExceptSelf(int[] nums)
            {
                var fwd = Enumerable.Repeat(1, nums.Length).ToArray();
                var bwd = Enumerable.Repeat(1, nums.Length).ToArray();
                var result = Enumerable.Repeat(1, nums.Length).ToArray();

                for (int i = 1; i < nums.Length; i++)
                {
                    fwd[i] = fwd[i - 1] * nums[i - 1];
                }

                for (int i = nums.Length - 2; i >= 0; i--)
                {
                    bwd[i] = bwd[i + 1] * nums[i + 1];
                }

                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = fwd[i] * bwd[i];
                }

                return result;

                //var nowMultiplication = 1;
                //var result = new List<int>();

                //for (var i = 0; i < nums.Length; i++)
                //{
                //    result.Add(nowMultiplication);
                //    nowMultiplication *= nums[i];

                //    for (int j = 0; j < i; j++)
                //    {
                //        result[j] *= nums[i];
                //    }
                //}

                //return result.ToArray();
            }
        }
    }
}