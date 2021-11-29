using System;
using System.Linq;

namespace LeetCode_718_Maximum_Length_of_Repeated_Subarray
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums1 = new int[] { 1, 2, 3, 2, 1 };
            var nums2 = new int[] { 3, 2, 1, 4, 7 };

            var s = new Solution();
            Console.WriteLine(s.FindLength(nums1, nums2));
        }

        public class Solution
        {
            public int FindLength(int[] nums1, int[] nums2)
            {
                var result = 0;
                var dp = Enumerable.Range(0, nums1.Length + 1).Select(x => Enumerable.Repeat(0, nums2.Length + 1).ToArray()).ToArray();

                for (int i = 1; i < nums1.Length + 1; i++)
                {
                    for (int j = 1; j < nums2.Length + 1; j++)
                    {
                        if (nums1[i - 1] == nums2[j - 1])
                        {
                            dp[i][j] = dp[i - 1][j - 1] + 1;
                        }

                        result = Math.Max(result, dp[i][j]);
                    }
                }

                return result;
            }
        }
    }
}