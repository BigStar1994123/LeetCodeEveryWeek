using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_746_Min_Cost_Climbing_Stairs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cost = new int[] { 10, 15, 20 };
            //var cost = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };

            var s = new Solution2();
            Console.WriteLine(s.MinCostClimbingStairs(cost));
        }

        public class Solution2
        {
            public int MinCostClimbingStairs(int[] cost)
            {
                var dp = new Dictionary<int, int>();

                var costList = cost.ToList();
                costList.Add(0);

                for (int i = 0; i < costList.Count; i++)
                {
                    if (i < 2)
                    {
                        dp.Add(i, costList[i]);
                    }
                    else
                    {
                        var min = Math.Min(dp[i - 1] + costList[i], dp[i - 2] + costList[i]);
                        dp.Add(i, min);
                    }
                }

                return dp[costList.Count - 1];
            }
        }

        public class Solution
        {
            public int MinCostClimbingStairs(int[] cost)
            {
                var dp = new Dictionary<int, int>();

                var costList = cost.ToList();
                costList.Add(0);

                for (int i = 0; i < costList.Count; i++)
                {
                    if (i < 2)
                    {
                        dp.Add(i, costList[i]);
                        continue;
                    }

                    dp.Add(i, Math.Min(dp[i - 1], dp[i - 2]) + costList[i]);
                }

                return dp[costList.Count - 1];
            }
        }
    }
}