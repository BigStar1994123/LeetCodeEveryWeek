using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_71_Simplify_Path
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var path = "/a/./b/../../c/";
            //var path = "/../";

            var s = new Solution();
            Console.WriteLine(s.SimplifyPath(path));
        }

        public class Solution
        {
            public string SimplifyPath(string path)
            {
                var splits = path.Split("/");

                var result = "";
                var stack = new Stack<string>();

                for (int i = 0; i < splits.Length; i++)
                {
                    if (splits[i] == "." || string.IsNullOrWhiteSpace(splits[i]))
                    {
                        // do nothing
                    }
                    else if (splits[i] == "..")
                    {
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push(splits[i]);
                    }
                }

                var reverseStack = new Stack<string>();
                while (stack.TryPop(out var popValue))
                {
                    reverseStack.Push(popValue);
                }

                while (reverseStack.TryPop(out var popValue))
                {
                    result += $"/{popValue}";
                }

                return string.IsNullOrWhiteSpace(result) ? "/" : result;
            }
        }
    }
}