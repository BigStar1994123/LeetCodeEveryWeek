using System;

namespace Leetcode27_Remove_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var a = new Solution();
            Console.WriteLine( a.RemoveElement( new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2));

            Console.Read();
        }
    }

    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            var p = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[p] = nums[i];
                    p++;
                }
            }

            Array.Resize(ref nums, p);

            return p;
        }
    }
}
