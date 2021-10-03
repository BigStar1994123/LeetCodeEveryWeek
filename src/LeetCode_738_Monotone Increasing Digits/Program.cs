using System;
using System.Collections.Generic;

namespace LeetCode_738_Monotone_Increasing_Digits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var n = 1432;

            var s = new Solution();
            Console.WriteLine(s.MonotoneIncreasingDigits(n));
        }

        public class Solution
        {
            public int MonotoneIncreasingDigits(int n)
            {
                var intList = new List<int>();

                var num = n;
                while (num > 0)
                {
                    intList.Add(num % 10);
                    num /= 10;
                }

                for (int i = 1; i < intList.Count; i++)
                {
                    if (intList[i] > intList[i - 1])
                    {
                        intList[i]--;
                        for (int j = i - 1; j >= 0; j--)
                        {
                            intList[j] = 9;
                        }
                    }
                }

                var result = 0;
                var mul = 1;
                for (int i = 0; i < intList.Count; i++)
                {
                    result += intList[i] * mul;
                    mul *= 10;
                }

                return result;
            }
        }
    }
}