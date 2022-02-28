using System;

namespace Leetcode35_Search_Insert_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var result = s.SearchInsert(new int[] { 1, 3, 5, 6 }, 2);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            var index = 0;
            foreach(var num in nums)
            {
                if (target <= num)
                {
                    return index;
                }
                index++;
            }
            return index;
        }
    }
}
