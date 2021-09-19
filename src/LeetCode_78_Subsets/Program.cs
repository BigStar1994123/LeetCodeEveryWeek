using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_78_Subsets
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 1, 2, 3 };

            var s = new Solution();
            var result = s.Subsets(nums);

            Console.WriteLine(string.Join("\n", result.Select(x => string.Join("|", x))));
        }

        public class Solution
        {
            private IList<IList<int>> _result = new List<IList<int>>();
            private IList<int> _path = new List<int>();

            public IList<IList<int>> Subsets(int[] nums)
            {
                BackTracking(nums, 0);
                return _result;
            }

            private void BackTracking(int[] nums, int startIndex = 0)
            {
                _result.Add(_path.ToList());

                if (startIndex == nums.Length)
                {
                    return;
                }

                for (int i = startIndex; i < nums.Length; i++)
                {
                    _path.Add(nums[i]);
                    BackTracking(nums, i + 1);
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }
    }
}