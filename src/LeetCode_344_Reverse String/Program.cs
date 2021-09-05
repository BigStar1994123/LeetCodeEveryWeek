using System;

namespace LeetCode_344_Reverse_String
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var chars = new char[] { 'h', 'e', 'l', 'l', 'o' };

            var s = new Solution();
            s.ReverseString(chars);
        }

        public class Solution
        {
            public void ReverseString(char[] s)
            {
                var last = s.Length - 1;
                var i = 0;
                char temp;

                while (i < s.Length / 2)
                {
                    temp = s[i];
                    s[i] = s[last - i];
                    s[last - i] = temp;
                    i++;
                }
            }
        }
    }
}