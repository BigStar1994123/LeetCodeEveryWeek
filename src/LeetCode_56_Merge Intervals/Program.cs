using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_56_Merge_Intervals
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution2();

            var array2D = new int[][]
            {
                //new int[] { 1, 2, 3, 4 },
                //new int[] { 5, 6, 7, 8 },
                //new int[] { 9, 10, 11, 12 }

                new int[] { 1,3 },
                new int[] { 8,10 },
                new int[] { 2,6 },
                new int[] { 15,18 }
            };

            var list = s.Merge(array2D);
            Console.WriteLine(string.Join(",", list.Select(x => string.Join("-", x))));
            //Console.WriteLine(string.Join(",", string.Join("|", list.Select(x => )))));
        }
    }

    public class Solution2
    {
        public int[][] Merge(int[][] intervals)
        {
            var sortedIntervals = intervals.ToList().OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();

            var result = new List<int[]>();

            var left = sortedIntervals[0][0];
            var right = sortedIntervals[0][1];

            for (int i = 1; i < sortedIntervals.Length; i++)
            {
                if (sortedIntervals[i][0] >= left && sortedIntervals[i][0] <= right)
                {
                    right = sortedIntervals[i][1] > right ? sortedIntervals[i][1] : right;
                }
                else
                {
                    result.Add(new int[] { left, right });

                    left = sortedIntervals[i][0];
                    right = sortedIntervals[i][1];
                }
            }

            result.Add(new int[] { left, right });
            return result.ToArray();
        }
    }

    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();

            var sortIntervals = intervals.OrderBy(x => x[0]).ToArray();

            (int Start, int End)? resultItem = null;
            foreach (var item in sortIntervals)
            {
                if (resultItem == null)
                {
                    resultItem = (Start: item[0], End: item[1]);
                }
                else
                {
                    if (item[0] > resultItem.Value.End)
                    {
                        result.Add(new int[] { resultItem.Value.Start, resultItem.Value.End });
                        resultItem = (Start: item[0], End: item[1]);
                    }
                    else
                    {
                        var max = Math.Max(resultItem.Value.End, item[1]);
                        resultItem = (Start: resultItem.Value.Start, End: max);
                    }
                }
            }

            result.Add(new int[] { resultItem.Value.Start, resultItem.Value.End });

            return result.Select(x => x.ToArray()).ToArray();
        }
    }
}