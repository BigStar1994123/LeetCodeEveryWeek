using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_77_Combinations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var n = 4;
            var k = 2;

            var s = new Solution();
            var result = s.Combine(n, k);
            Console.WriteLine(string.Join("\n", result.Select(x => string.Join("|", x))));
        }

        public class Solution
        {
            private List<IList<int>> _result = new List<IList<int>>();
            private List<int> _path = new List<int>();

            public IList<IList<int>> Combine(int n, int k)
            {
                BackTracking(n, k, 1);
                return _result;
            }

            private void BackTracking(int n, int k, int startIndex)
            {
                if (_path.Count == k)
                {
                    _result.Add(_path.ToList());
                    return;
                }

                for (int i = startIndex; i <= n; i++)
                {
                    _path.Add(i);
                    BackTracking(n, k, i + 1);
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }
    }
}