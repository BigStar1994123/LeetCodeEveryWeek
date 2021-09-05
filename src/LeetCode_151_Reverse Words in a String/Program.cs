using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_151_Reverse_Words_in_a_String
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var text = "the sky is blue";
            var s = new Solution();

            Console.WriteLine(s.ReverseWords(text));
        }

        public class Solution
        {
            public string ReverseWords(string s)
            {
                var list = new List<string>();

                var text = string.Empty;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != ' ')
                    {
                        text += s[i];
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(text))
                        {
                            list.Add(text);
                            text = string.Empty;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(text))
                {
                    list.Add(text);
                }

                list.Reverse();

                return string.Join(" ", list);

                //var splits = s.Split(" ");

                //return string.Join(" ", splits.Where(x => !string.IsNullOrEmpty(x)).Reverse());
            }
        }
    }
}