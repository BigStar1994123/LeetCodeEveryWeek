using System;
using System.Collections.Generic;

namespace LeetCode_190_Reverse_Bits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            uint num = 4;
            var s = new Solution();
            Console.WriteLine(s.reverseBits(num));
        }

        public class Solution
        {
            public uint reverseBits(uint n)
            {
                uint res = 0;
                for (int i = 0; i < 32; i++)
                {
                    res = (res << 1) | (n & 1);
                    n >>= 1;
                }

                return res;

                //var list = new List<uint>();

                //var count = 0;
                //while (n != 0)
                //{
                //    var remainder = n % 2;
                //    n /= 2;

                //    list.Add(remainder);
                //    count++;
                //}

                //while (count != 32)
                //{
                //    list.Add(0);
                //    count++;
                //}

                //uint result = 0;
                //uint odds = 1;

                //for (int i = list.Count - 1; i >= 0; i--)
                //{
                //    result += list[i] * odds;
                //    odds *= 2;
                //}

                //return result;
            }
        }
    }
}