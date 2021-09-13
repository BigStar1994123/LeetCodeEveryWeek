using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_39_Combination_Sum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution2();

            var candidates = new int[] { 2, 3, 6, 7 };
            var target = 7;

            var result = s.CombinationSum(candidates, target);
            Console.WriteLine(string.Join("\n", result.Select(x => string.Join("|", x))));
        }
    }

    public class Solution2
    {
        private IList<IList<int>> _result = new List<IList<int>>();
        private IList<int> _path = new List<int>();

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            BackTracking(candidates, target, 0, 0);
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

            for (int i = startIndex; i < candidates.Length; i++)
            {
                if (sum + candidates[i] > target)
                {
                    break;
                }

                _path.Add(candidates[i]);
                BackTracking(candidates, target, i, sum + candidates[i]);
                _path.RemoveAt(_path.Count - 1);
            }
        }
    }

    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var result = new List<IList<int>>();
            GetResult(result, new List<int>(), candidates, target, 0);
            return result;

            //var result = new List<IList<int>>();

            //for (int i = 0; i < candidates.Length; i++)
            //{
            //    var resultItem = new List<int>();

            //    var value = candidates[i];
            //    var subtraction = target;
            //    while (true)
            //    {
            //        resultItem.Add(value);
            //        subtraction -= value;

            //        if (subtraction == 0)
            //        {
            //            result.Add(resultItem);
            //            break;
            //        }
            //        else
            //        {
            //            resultItem.Remove(value);
            //            break;
            //        }
            //    }
            //}
        }

        private void GetResult(List<IList<int>> result, List<int> cur, int[] candidates, int target, int start)
        {
            if (target > 0)
            {
                for (int i = start; i < candidates.Length && target >= candidates[i]; i++)
                {
                    cur.Add(candidates[i]);
                    GetResult(result, cur, candidates, target - candidates[i], i);
                    cur.RemoveAt(cur.Count - 1);
                }
            }
            else if (target == 0)
            {
                result.Add(new List<int>(cur));
            }
        }
    }
}