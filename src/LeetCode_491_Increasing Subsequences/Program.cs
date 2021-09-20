using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_491_Increasing_Subsequences
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nums = new int[] { 4, 6, 7, 7 };

            var s = new Solution();
            var result = s.FindSubsequences(nums);

            Console.WriteLine(string.Join("\n", result.Select(x => string.Join(",", x))));
        }

        public class Solution
        {
            private IList<IList<int>> _result = new List<IList<int>>();
            private IList<int> _path = new List<int>();

            public IList<IList<int>> FindSubsequences(int[] nums)
            {
                BackTracking(nums, 0, null);
                return _result;
            }

            private void BackTracking(int[] nums, int startIndex, int? preValue)
            {
                if (_path.Count >= 2)
                {
                    _result.Add(_path.ToList());
                }

                var hash = new HashSet<int>();
                for (int i = startIndex; i < nums.Length; i++)
                {
                    if (hash.Contains(nums[i]))
                    {
                        continue;
                    }
                    else
                    {
                        hash.Add(nums[i]);
                    }

                    if (preValue.HasValue && nums[i] < preValue.Value)
                    {
                        continue;
                    }

                    _path.Add(nums[i]);
                    BackTracking(nums, i + 1, nums[i]);
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }
    }
}