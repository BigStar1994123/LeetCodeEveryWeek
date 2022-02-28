using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var ns = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(ContainsDuplicate(ns));

            Console.ReadLine();
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            var dic = new Dictionary<int, bool>();

            foreach (var num in nums)
            {
                if (dic.ContainsKey(num))
                {
                    return true;
                }

                dic.Add(num, true);
            }

            return false;
        }
    }
}