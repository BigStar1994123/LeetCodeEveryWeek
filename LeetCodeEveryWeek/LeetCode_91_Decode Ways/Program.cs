using System;
using System.Collections.Generic;

namespace LeetCode_91_Decode_Ways
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var text = "111111111111111111111111111111111111111111111";

            Console.WriteLine(s.NumDecodings(text));
        }
    }

    public class Solution
    {
        private Dictionary<int, int> DP = new Dictionary<int, int>();

        public int NumDecodings(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }

            //DP.Add("", 1);

            return Recur(s, 0, s.Length - 1);
        }

        private int Recur(string s, int l, int r)
        {
            if (DP.ContainsKey(l))
            {
                return DP[l];
            }

            if (s[l] == '0')
            {
                return 0;
            }

            if (l >= r)
            {
                return 1;
            }

            var w = Recur(s, l + 1, r);
            var prefix = Convert.ToInt32($"{s[l]}{s[l + 1]}");
            if (prefix <= 26)
            {
                w += Recur(s, l + 2, r);
            }

            DP.Add(l, w);

            return w;

            //if (DP.ContainsKey(s))
            //{
            //    return DP[s];
            //}

            //if (s[0] == '0')
            //{
            //    return 0;
            //}

            //if (s.Length == 1)
            //{
            //    return 1;
            //}

            //var w = Recur(s[1..]);
            //var prefix = Convert.ToInt32(s.Substring(0, 2));

            //if (prefix <= 26)
            //{
            //    w += Recur(s[2..]);
            //}

            //return w;
        }
    }
}