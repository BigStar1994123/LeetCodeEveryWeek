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

            var s = new Solution();

            var candidates = new int[] { 2, 3, 6, 7 };
            var target = 7;

            var list = s.CombinationSum(candidates, target);
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