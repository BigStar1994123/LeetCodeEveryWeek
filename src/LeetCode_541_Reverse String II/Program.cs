using System;
using System.Linq;

namespace LeetCode_541_Reverse_String_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var text = "abcde";
            var k = 2;

            var s = new Solution();
            Console.WriteLine(s.ReverseStr(text, k));
        }

        public class Solution
        {
            public string ReverseStr(string s, int k)
            {
                var result = string.Empty;
                var length = s.Length;

                var i = 0;
                var needReverse = true;

                while (i < length)
                {
                    var subS = string.Empty;

                    if (i + k < length)
                    {
                        subS = s.Substring(i, k);
                    }
                    else
                    {
                        subS = s.Substring(i);
                    }

                    result += Reverse(subS, needReverse);

                    i += k;

                    needReverse = !needReverse;
                }

                return result;
            }

            private string Reverse(string s, bool needReverse)
            {
                if (needReverse)
                {
                    return new string(s.Reverse().ToArray());
                }
                else
                {
                    return s;
                }
            }
        }
    }
}