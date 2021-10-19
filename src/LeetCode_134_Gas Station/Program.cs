using System;

namespace LeetCode_134_Gas_Station
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var gas = new int[] { 1, 2, 3, 4, 5 };
            var cost = new int[] { 3, 4, 5, 1, 2 };

            //var gas = new int[] { 2, 3, 4, 5, 6 };
            //var cost = new int[] { 3, 4, 3, 3, 8 };

            //var gas = new int[] { 5, 1, 2, 3, 4 };
            //var cost = new int[] { 4, 4, 1, 5, 1 };

            var s = new Solution();
            Console.WriteLine(s.CanCompleteCircuit(gas, cost));
        }

        public class Solution
        {
            public int CanCompleteCircuit(int[] gas, int[] cost)
            {
                var curSum = 0;
                var totalSum = 0;
                var start = 0;

                for (int i = 0; i < gas.Length; i++)
                {
                    curSum += gas[i] - cost[i];
                    totalSum += gas[i] - cost[i];
                    if (curSum < 0)
                    {
                        start = i + 1;
                        curSum = 0;
                    }
                }

                if (totalSum < 0)
                {
                    return -1;
                }

                return start;
            }
        }
    }
}