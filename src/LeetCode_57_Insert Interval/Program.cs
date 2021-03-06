using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_57_Insert_Interval
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var array2D = new int[][]
            {
                //new int[] { 1, 2, 3, 4 },
                //new int[] { 5, 6, 7, 8 },
                //new int[] { 9, 10, 11, 12 }

                new int[] { 1,3 },
                new int[] { 6,9 }
            };

            var insertArray = new int[] { 4, 8 };

            var list = s.Insert(array2D, insertArray);
            Console.WriteLine(string.Join(",", list.Select(x => x.ToString())));
        }
    }

    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
            {
                return new int[][] { newInterval };
            }

            var result = new List<int[]>();

            intervals = intervals.Append(newInterval).ToArray();
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