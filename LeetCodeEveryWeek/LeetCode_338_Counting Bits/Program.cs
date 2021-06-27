using System;
using System.Collections.Generic;

namespace LeetCode_338_Counting_Bits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var n = 5;

            var s = new Solution();
            var arr = s.CountBits(n);
        }

        public class Solution
        {
            public int[] CountBits(int n)
            {
                var result = new List<int>();

                for (int i = 0; i <= n; i++)
                {
                    result.Add(Calc(i));
                }

                return result.ToArray();
            }

            private int Calc(int n)
            {
                var count = 0;

                while (n > 0)
                {
                    if ((n & 1) == 1)
                    {
                        count++;
                    }

                    n >>= 1;
                }

                return count;
            }
        }
    }
}