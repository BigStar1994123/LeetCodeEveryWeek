using System;
using System.Linq;

namespace LeetCode_455_Assign_Cookies
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var g = new int[] { 1, 2, 3 };
            var s = new int[] { 1, 2 };

            var sol = new Solution();
            Console.WriteLine(sol.FindContentChildren(g, s));
        }

        public class Solution2
        {
            public int FindContentChildren(int[] g, int[] s)
            {
                Array.Sort(g);
                Array.Sort(s);

                var alreadyFullChildIndex = 0;
                for (int i = 0; i < s.Length; ++i)
                {
                    if (alreadyFullChildIndex < g.Length && g[alreadyFullChildIndex] <= s[i])
                    {
                        alreadyFullChildIndex++;
                    }
                }

                return alreadyFullChildIndex;
            }
        }

        public class Solution
        {
            public int FindContentChildren(int[] g, int[] s)
            {
                var childList = g.ToList();
                childList.Sort();

                var cookieList = s.ToList();
                cookieList.Sort();

                var alreadyFullChildIndex = 0;
                for (int i = 0; i < cookieList.Count; i++)
                {
                    for (int k = alreadyFullChildIndex; k < childList.Count; k++)
                    {
                        if (childList[k] <= cookieList[i])
                        {
                            alreadyFullChildIndex++;
                            break;
                        }
                    }
                }

                return alreadyFullChildIndex;
            }
        }
    }
}