using System;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var num = 10;
            var s = new Solution();
            Console.WriteLine(s.IsPowerOfTwo(num));

            Console.ReadLine();
        }

        public class Solution
        {
            public bool IsPowerOfTwo(int n)
            {
                if (n <= 0) return false;

                var binary = Convert.ToString(n, 2);
                return binary[1..].IndexOf("1") == -1;

                //return (n > 0 && ((n & (n - 1)) == 0));

                //while (n != 1)
                //{
                //    if (n % 2 != 0)
                //    {
                //        return false;
                //    }

                //    n >>= 1;
                //}

                //return true;
            }
        }
    }
}