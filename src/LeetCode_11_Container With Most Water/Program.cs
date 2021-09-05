using System;

namespace LeetCode_11_Container_With_Most_Water
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine(s.MaxArea(height));
        }
    }

    public class Solution
    {
        public int MaxArea(int[] height)
        {
            var leftPosition = 0;
            var rightPosition = height.Length - 1;

            var maxSize = 0;
            var size = (rightPosition - leftPosition) * Math.Min(height[leftPosition], height[rightPosition]);
            maxSize = Math.Max(size, maxSize);

            while (leftPosition != rightPosition)
            {
                size = (rightPosition - leftPosition) * Math.Min(height[leftPosition], height[rightPosition]);
                maxSize = Math.Max(size, maxSize);

                if (height[rightPosition] > height[leftPosition])
                {
                    leftPosition++;
                }
                else
                {
                    rightPosition--;
                }
            }

            return maxSize;
        }
    }
}