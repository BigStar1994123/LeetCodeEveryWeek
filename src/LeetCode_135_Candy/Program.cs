using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_135_Candy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var rating = new int[] { 1, 0, 2, 3, 4, 4, 3, 2, 1 };

            var s = new Solution();
            Console.WriteLine(s.Candy(rating));
        }

        public class Solution
        {
            public int Candy(int[] ratings)
            {
                var candies = Enumerable.Repeat(1, ratings.Length).ToList();

                candies[0] = 1;
                candies[ratings.Length - 1] = 1;

                // 由左向右走
                for (int i = 1; i < ratings.Length; i++)
                {
                    if (ratings[i] > ratings[i - 1])
                    {
                        candies[i] = candies[i - 1] + 1;
                    }
                }

                // 由右向左走
                for (int i = ratings.Length - 2; i >= 0; i--)
                {
                    if (ratings[i] > ratings[i + 1])
                    {
                        candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
                    }
                }

                // 統計結果
                var result = 0;
                for (int i = 0; i < candies.Count; i++)
                {
                    result += candies[i];
                }

                return result;
            }
        }
    }
}