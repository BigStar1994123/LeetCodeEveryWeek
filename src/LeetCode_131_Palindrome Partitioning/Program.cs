using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_131_Palindrome_Partitioning
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var str = "aab";

            var s = new Solution();
            var result = s.Partition(str);

            Console.WriteLine(string.Join("\n", result.Select(x => string.Join(",", x))));
        }

        public class Solution
        {
            private IList<IList<string>> _result = new List<IList<string>>();
            private IList<string> _path = new List<string>();

            public IList<IList<string>> Partition(string s)
            {
                BackTracking(s, 0);
                return _result;
            }

            private void BackTracking(string s, int startIndex)
            {
                if (startIndex >= s.Length)
                {
                    _result.Add(_path.ToList());
                    return;
                }

                for (int i = startIndex; i < s.Length; i++)
                {
                    if (IsPalindrome(s, startIndex, i))
                    {
                        var str = s.Substring(startIndex, i - startIndex + 1);
                        _path.Add(str);
                    }
                    else
                    {
                        continue;
                    }

                    BackTracking(s, i + 1);
                    _path.RemoveAt(_path.Count - 1);
                }
            }

            private bool IsPalindrome(string s, int start, int end)
            {
                for (int i = start, j = end; i < j; i++, j--)
                {
                    if (s[i] != s[j])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}