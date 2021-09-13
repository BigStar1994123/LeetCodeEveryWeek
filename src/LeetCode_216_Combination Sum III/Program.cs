using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_216_Combination_Sum_III
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var k = 9;
            var sum = 45;

            var s = new Solution();
            var result = s.CombinationSum3(k, sum);
            Console.WriteLine(string.Join("\n", result.Select(x => string.Join("|", x))));
        }

        public class Solution
        {
            private IList<IList<int>> _result = new List<IList<int>>();
            private IList<int> _path = new List<int>();

            public IList<IList<int>> CombinationSum3(int k, int n)
            {
                BackTracking(k, n, 1, 0);
                return _result;
            }

            private void BackTracking(int k, int n, int startIndex, int tmpSum)
            {
                if (_path.Count > k)
                {
                    return;
                }

                if (tmpSum == n && _path.Count == k)
                {
                    _result.Add(_path.ToList());
                    return;
                }

                for (int i = startIndex; i <= n - tmpSum && i <= 9; i++)
                {
                    _path.Add(i);
                    BackTracking(k, n, i + 1, tmpSum + i);
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }
    }
}