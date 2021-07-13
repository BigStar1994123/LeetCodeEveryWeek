using System;
using System.Collections.Generic;

namespace LeetCode_202_Happy_Number
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var n = 2;

            var s = new Solution();
            Console.WriteLine(s.IsHappy(n));
        }

        public class Solution
        {
            public bool IsHappy(int n)
            {
                var hash = new HashSet<int>();
                hash.Add(n);

                while (true)
                {
                    var sum = 0;

                    while (n > 0)
                    {
                        var i = n % 10;
                        sum += Convert.ToInt32(Math.Pow(i, 2));
                        n = n / 10;
                    }

                    if (sum == 1)
                    {
                        return true;
                    }

                    if (hash.Contains(sum))
                    {
                        return false;
                    }

                    hash.Add(sum);
                    n = sum;
                }
            }
        }
    }
}