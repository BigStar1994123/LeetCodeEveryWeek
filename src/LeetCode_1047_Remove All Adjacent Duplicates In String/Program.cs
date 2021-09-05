using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_1047_Remove_All_Adjacent_Duplicates_In_String
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var text = "abbacaacb";

            var s = new Solution();
            Console.WriteLine(s.RemoveDuplicates(text));
        }

        public class Solution
        {
            public string RemoveDuplicates(string s)
            {
                if (s.Length < 2)
                {
                    return s;
                }

                var sb = new StringBuilder();
                sb.Append(s[0]);
                var stack = new Stack<char>();
                stack.Push(s[0]);

                for (int i = 1; i < s.Length; i++)
                {
                    var peekSuccess = stack.TryPeek(out var peekValue);

                    if (!peekSuccess || s[i] != peekValue)
                    {
                        stack.Push(s[i]);
                        sb.Append(s[i]);
                    }
                    else
                    {
                        stack.Pop();
                        sb.Remove(sb.Length - 1, 1);
                    }
                }

                return sb.ToString();
            }
        }
    }
}