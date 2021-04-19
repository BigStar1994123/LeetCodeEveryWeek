using System;
using System.Collections.Generic;

namespace LeetCode_39_Combination_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var candidates = new int[] { 2, 3, 5 };
            var target = 8;

            var list = s.CombinationSum(candidates, target);
        }
    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
        }
    }
}