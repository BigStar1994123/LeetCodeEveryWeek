using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_17_Letter_Combinations_of_a_Phone_Number
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var digits = "23";

            var s = new Solution();
            var result = s.LetterCombinations(digits);
        }

        public class Solution
        {
            private Dictionary<char, char[]> _digitMap = new Dictionary<char, char[]>()
            {
                { '2', new char[] { 'a', 'b', 'c' } },
                { '3', new char[] { 'd', 'e', 'f'} },
                { '4', new char[] { 'g', 'h', 'i' } },
                { '5', new char[] { 'j', 'k', 'l' } },
                { '6', new char[] { 'm', 'n', 'o' } },
                { '7', new char[] { 'p', 'q', 'r', 's'} },
                { '8', new char[] { 't', 'u', 'v' } },
                { '9', new char[] { 'w', 'x', 'y', 'z'} }
            };

            private IList<string> _result = new List<string>();
            private IList<char> _path = new List<char>();

            public IList<string> LetterCombinations(string digits)
            {
                if (digits.Length == 0)
                {
                    return _result;
                }

                BackTracking(digits, 0);
                return _result;
            }

            private void BackTracking(string digits, int startIndex)
            {
                if (startIndex == digits.Length)
                {
                    _result.Add(new string(_path.ToArray()));
                    return;
                }

                var words = _digitMap[digits[startIndex]];

                for (int j = 0; j < words.Length; j++)
                {
                    _path.Add(words[j]);
                    BackTracking(digits, startIndex + 1);
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }
    }
}