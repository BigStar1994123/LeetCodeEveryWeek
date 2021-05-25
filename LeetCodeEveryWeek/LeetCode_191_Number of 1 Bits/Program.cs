using System;

namespace LeetCode_191_Number_of_1_Bits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            uint num = 11;
            var s = new Solution();
            Console.WriteLine(s.HammingWeight(num));
        }

        public class Solution
        {
            public int HammingWeight(uint n)
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