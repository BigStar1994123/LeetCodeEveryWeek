using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_1049_Last_Stone_Weight_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var nums = new int[] { 2, 7, 4, 1, 8, 1 };
            //var nums = new int[] { 31, 26, 33, 21, 40 };
            var nums = new int[] { 6, 2, 2, 6, 5, 7, 7 };

            var s = new Solution2();
            Console.WriteLine(s.LastStoneWeightII(nums));
        }

        public class Solution2
        {
            public int LastStoneWeightII(int[] stones)
            {
                var dp = Enumerable.Repeat(0, 15001).ToArray();

                var sum = stones.Sum();
                var average = sum / 2;

                for (var i = 0; i < stones.Length; i++)
                {
                    for (var j = average; j >= stones[i]; j--)
                    {
                        dp[j] = Math.Max(dp[j], dp[j - stones[i]] + stones[i]);
                    }
                }
                return sum - dp[average] - dp[average];
            }
        }

        public class Solution
        {
            public int LastStoneWeightII(int[] stones)
            {
                Array.Sort(stones);
                Array.Reverse(stones);

                var sum = stones.Sum();
                var average = sum / 2;

                var listA = new List<int>();
                var listASum = 0;
                var listB = new List<int>();
                var listBSum = 0;

                for (int i = 0; i < stones.Length - 1; i++)
                {
                    var stone = stones[i];
                    if (listASum + stone <= average)
                    {
                        listA.Add(stone);
                        listASum += stone;
                    }
                    else
                    {
                        listB.Add(stone);
                        listBSum += stone;
                    }
                }

                var lastStone = stones[^1];
                if (listASum < listBSum)
                {
                    listASum += lastStone;
                }
                else
                {
                    listBSum += lastStone;
                }

                return Math.Abs(listASum - listBSum);
            }
        }
    }
}