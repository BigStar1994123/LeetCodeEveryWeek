using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_46_Permutations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1, 2, 3, 4 };

            var s = new Solution();
            var result = s.Permute(nums);
            Console.WriteLine(string.Join("\n", result.Select(x => string.Join(",", x))));
        }

        public class Solution
        {
            private IList<IList<int>> _result = new List<IList<int>>();
            private IList<int> _path = new List<int>();

            public IList<IList<int>> Permute(int[] nums)
            {
                BackTracking(nums);
                return _result;
            }

            private void BackTracking(int[] nums)
            {
                if (nums.Length == 0)
                {
                    _result.Add(_path.ToList());
                    return;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    _path.Add(nums[i]);
                    var nextNums = nums.ToList();
                    nextNums.RemoveAt(i);
                    BackTracking(nextNums.ToArray());
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }
    }
}