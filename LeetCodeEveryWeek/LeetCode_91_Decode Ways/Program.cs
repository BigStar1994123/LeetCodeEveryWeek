using System;
using System.Collections.Generic;

namespace LeetCode_91_Decode_Ways
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution2();

            //var text = "111111111111111111111111111111111111111111111";
            var text = "10011";
            //var text = "226";

            Console.WriteLine(s.NumDecodings(text));
        }
    }

    public class Solution2
    {
        public int NumDecodings(string s)
        {
            var dp = new Dictionary<int, int>();

            if (s.Length == 0)
            {
                return 0;
            }

            if (s.Length == 1)
            {
                if (s[0] == '0')
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (s[0] == '0')
            {
                return 0;
            }

            dp.Add(-1, 1);
            dp.Add(0, 1);

            for (int i = 1; i < s.Length; i++)
            {
                var num = Convert.ToInt32(s.Substring(i - 1, 2));

                if (s[i] == '0' && (num > 26 || num == 0))
                {
                    return 0;
                }

                if (num < 27)
                {
                    if (s[i - 1] == '0')
                    {
                        dp[i] = dp[i - 1];
                    }
                    else if (s[i] == '0')
                    {
                        dp[i] = dp[i - 2];
                    }
                    else
                    {
                        dp[i] = dp[i - 1] + dp[i - 2];
                    }
                }
                else
                {
                    dp[i] = dp[i - 1];
                }
            }

            return dp[s.Length - 1];
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