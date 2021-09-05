using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_150_Evaluate_Reverse_Polish_Notation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var tokens = new string[] { "3", "11", "5", "+", "-" };

            var s = new Solution();
            Console.WriteLine(s.EvalRPN(tokens));
        }

        public class Solution
        {
            public int EvalRPN(string[] tokens)
            {
                if (tokens.Length == 1)
                {
                    return Convert.ToInt32(tokens[0]);
                }

                var symbols = new string[] { "+", "-", "*", "/" };
                var stack = new Stack<int>();
                int result = 0;

                for (int i = 0; i < tokens.Length; i++)
                {
                    var token = tokens[i];

                    if (!symbols.Contains(token))
                    {
                        stack.Push(Convert.ToInt32(token));
                    }
                    else
                    {
                        var popValue1 = stack.Pop();
                        var popValue2 = stack.Pop();
                        int tempReuslt = 0;

                        switch (token)
                        {
                            case "+":
                                tempReuslt = popValue2 + popValue1;
                                break;

                            case "-":
                                tempReuslt = popValue2 - popValue1;
                                break;

                            case "*":
                                tempReuslt = popValue2 * popValue1;
                                break;

                            case "/":
                                tempReuslt = popValue2 / popValue1;
                                break;

                            default:
                                break;
                        }

                        stack.Push(tempReuslt);
                        result = tempReuslt;
                    }
                }

                return result;
            }
        }
    }
}