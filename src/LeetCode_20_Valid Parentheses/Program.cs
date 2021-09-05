using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_20_Valid_Parentheses
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution2();

            var text = "{[]}";
            Console.WriteLine(s.IsValid(text));
        }
    }

    public class Solution2
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var right = new char[] { ')', '}', ']' };

            foreach (var c in s)
            {
                if (right.Contains(c))
                {
                    var popSuccess = stack.TryPop(out var popValue);
                    if (!popSuccess)
                    {
                        return false;
                    }

                    if ((c == ')' && popValue != '(') ||
                        (c == '}' && popValue != '{') ||
                        (c == ']' && popValue != '['))
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            return true;
        }
    }

    public class Solution
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var left = new List<char> { '{', '[', '(' };

            for (var i = 0; i < s.Length; i++)
            {
                if (stack.Count == 0)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (left.Contains(s[i]))
                    {
                        stack.Push(s[i]);
                    }
                    else
                    {
                        var pop = stack.Pop();
                        if (s[i] == '}' && pop != '{')
                        {
                            return false;
                        }

                        if (s[i] == ']' && pop != '[')
                        {
                            return false;
                        }

                        if (s[i] == ')' && pop != '(')
                        {
                            return false;
                        }
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}