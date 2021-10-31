using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_343_Integer_Break
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var num = 12;

            var s = new Solution2();
            Console.WriteLine(s.IntegerBreak(num));
        }

        public class Solution2
        {
            public int IntegerBreak(int n)
            {
                if (n == 2)
                {
                    return 1;
                }
                else if (n == 3)
                {
                    return 2;
                }

                var dp = new Dictionary<int, int>();
                dp.Add(1, 1);
                dp.Add(2, 2);
                dp.Add(3, 3);
                // 4, 4
                // 5, 6
                // 6, 9

                for (int i = 4; i <= n; i++)
                {
                    var val = Math.Max(dp[i - 2] * 2, dp[i - 3] * 3);
                    dp.Add(i, val);
                }

                return (dp[n]);
            }
        }

        /// <summary>
        /// Wrong
        /// </summary>
        public class Solution
        {
            private IList<int> _path = new List<int>();

            private Dictionary<string, int> _productDp = new Dictionary<string, int>
            {
                { "", 1 }
            };

            private int _maxProduct;

            private int _num;

            public int IntegerBreak(int n)
            {
                _num = n;
                BackTracking(n);
                return _maxProduct;
            }

            private void BackTracking(int n)
            {
                if (n < 1)
                {
                    return;
                }

                for (int i = (int)Math.Floor(Math.Sqrt(_num)); i <= (_num / 2) + 1; i++)
                {
                    var pathString = string.Join(".", _path);
                    var dpValue = string.IsNullOrWhiteSpace(pathString) ? 1 : _productDp[pathString];

                    _path.Add(i);

                    var product = dpValue * i;
                    _productDp.Add(string.Join(".", _path), product);

                    if (_path.Count >= 2)
                    {
                        _maxProduct = Math.Max(_maxProduct, product);
                    }

                    BackTracking(n - i);
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }
    }
}