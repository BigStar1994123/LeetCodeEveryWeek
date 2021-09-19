using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_40_Combination_Sum_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var candidates = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            //var candidates = new int[] { 1, 1, 2, 4 };
            var target = 8;

            var s = new Solution();
            var result = s.CombinationSum2(candidates, target);
        }

        public class Solution
        {
            private IList<IList<int>> _result = new List<IList<int>>();
            private IList<int> _path = new List<int>();

            public IList<IList<int>> CombinationSum2(int[] candidates, int target)
            {
                Array.Sort(candidates);
                BackTracking(candidates, target, 0, 0);
                _result.Distinct();
                return _result;
            }

            private void BackTracking(int[] candidates, int target, int startIndex, int sum)
            {
                if (sum == target)
                {
                    _result.Add(_path.ToList());
                    return;
                }

                if (sum > target)
                {
                    return;
                }

                var hash = new HashSet<int>();
                for (int i = startIndex; i < candidates.Length; i++)
                {
                    if (hash.Contains(candidates[i]))
                    {
                        continue;
                    }
                    else
                    {
                        hash.Add(candidates[i]);
                    }

                    _path.Add(candidates[i]);
                    BackTracking(candidates, target, i + 1, sum + candidates[i]);
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }
    }
}