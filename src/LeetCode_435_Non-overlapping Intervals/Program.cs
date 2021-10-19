using System;
using System.Linq;

namespace LeetCode_435_Non_overlapping_Intervals
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var array2d = new int[][]
            {
                new int[] { 1,2 },
                new int[] { 2,3 },
                new int[] { 3,4 },
                new int[] { 1,3 },
            };

            var s = new Solution2();
            Console.WriteLine(s.EraseOverlapIntervals(array2d));
        }

        public class Solution2
        {
            public int EraseOverlapIntervals(int[][] intervals)
            {
                var sortedIntervals = intervals.ToList().OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();

                var result = 0;
                var index = 0;
                for (int i = 1; i < sortedIntervals.Length; i++)
                {
                    if (sortedIntervals[i][0] < sortedIntervals[index][1])
                    {
                        result++;
                        index = (sortedIntervals[i][1] < sortedIntervals[index][1] ? i : index);
                    }
                    else
                    {
                        index = i;
                    }
                }

                return result;
            }
        }

        public class Solution
        {
            public int EraseOverlapIntervals(int[][] intervals)
            {
                Array.Sort(intervals, (a, b) =>
                {
                    return (a[0] == b[0]) ? (a[1] - b[1]) : (a[0] - b[0]);
                });

                int ret = 0, cur_idx = 0;
                for (int i = 1; i < intervals.Length; i++)
                {
                    if (intervals[i][0] < intervals[cur_idx][1])
                    {
                        ret++;
                        cur_idx = (intervals[i][1] < intervals[cur_idx][1] ? i : cur_idx);
                    }
                    else
                    {
                        cur_idx = i;
                    }
                }

                return ret;
            }
        }
    }
}