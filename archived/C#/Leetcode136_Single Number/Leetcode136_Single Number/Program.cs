using System;
using System.Collections;
using System.Collections.Generic;

namespace Leetcode136_Single_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums = new int[] { 1, 3, 5, 7, 9, 1, 3, 5, 7 };
            Console.WriteLine(SingleNumber(nums));
            Console.WriteLine(SingleNumberCorrect(nums));
            Console.ReadLine();
        }

        private static int SingleNumberCorrect(int[] nums)
        {
            var single = 0;
            foreach (var num in nums)
            {
                single = single ^ num;
            }
            return single;
        }

        public static int SingleNumber(int[] nums)
        {
            var hash = new Hashtable();
            var calc = 0;
            foreach(var num in nums)
            {
                if (hash.ContainsKey(num))
                {
                    calc -= num;
                }
                else
                {
                    calc += num;
                    hash.Add(num,1);
                }
            }

            return calc;
        }

    }
}
