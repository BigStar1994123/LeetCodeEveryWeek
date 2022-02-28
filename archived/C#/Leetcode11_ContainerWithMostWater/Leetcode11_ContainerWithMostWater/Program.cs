using System;

namespace Leetcode11_ContainerWithMostWater
{
    /// <summary>
    /// 11. Container With Most Water
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new Solution();
            Console.WriteLine(s.MaxArea2(new int[] {1, 8, 6, 2, 5, 4, 8, 3, 7}));

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int MaxArea1(int[] height)
        {
            var max = 0;
            for (int i = 0; i < height.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var floor = i - j;
                    var h = Math.Min(height[i], height[j]);
                    var area = floor * h;

                    if (area > max)
                    {
                        max = area;
                    }
                }
            }
            return max;
        }

        public int MaxArea2(int [] height)
        {
            var max = 0;
            var head = 0;
            var tail = height.Length - 1;

            while (head < tail)
            {
                var floor = tail - head;
                var h = Math.Min(height[head], height[tail]);
                var area = floor * h;

                if (area > max)
                {
                    max = area;
                }

                if (height[head] < height[tail])
                {
                    head++;
                }
                else
                {
                    tail--;
                }
            }

            return max;
        }
    }
}
