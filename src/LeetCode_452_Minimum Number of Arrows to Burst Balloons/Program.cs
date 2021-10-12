using System;
using System.Linq;

namespace LeetCode_452_Minimum_Number_of_Arrows_to_Burst_Balloons
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var points = new int[][]
            {
                //new int[] { 10, 16 },
                //new int[] { 2, 8 },
                //new int[] { 1, 6 },
                //new int[] { 7, 12 }
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 4, 5 }
            };

            var s = new Solution();
            Console.WriteLine(s.FindMinArrowShots(points));
        }

        public class Solution
        {
            public int FindMinArrowShots(int[][] points)
            {
                var sortedPoints = points.ToList().OrderBy(x => x[1]);

                var count = 0;
                int? nowPos = null;

                foreach (var p in sortedPoints)
                {
                    if (nowPos == null || p[0] > nowPos.Value)
                    {
                        count++;
                        nowPos = p[1];
                    }
                }

                return count;
            }
        }
    }
}