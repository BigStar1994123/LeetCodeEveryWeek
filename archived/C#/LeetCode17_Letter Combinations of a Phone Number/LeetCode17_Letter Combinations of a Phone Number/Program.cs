using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode17_Letter_Combinations_of_a_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var result = s.LetterCombinations("");

            Console.Write("[");
            foreach (var se in result)
            {
                Console.Write($"{se},");
            }
            Console.Write("]");

            Console.ReadLine();
        }

        public class Solution
        {
            public IList<string> LetterCombinations(string digits)
            {
                var ret = new List<string>();
                if (String.IsNullOrEmpty(digits))
                {
                    return ret;
                }

                var dic = new Dictionary<string, string>()
                {
                    {"2", "abc" },
                    {"3", "def" },
                    {"4", "ghi" },
                    {"5", "jkl" },
                    {"6", "mno" },
                    {"7", "pqrs" },
                    {"8", "tuv" },
                    {"9", "wxyz" }
                };

                var letters = new List<string>();
                foreach (var d in digits)
                {
                    letters.Add(dic[d.ToString()]);
                }

                ret = Rec("", letters);
                return ret;
            }

            private List<string> Rec(string c, List<string> StringList)
            {
                var ret = new List<string>();
                if (StringList.Count == 0)
                {
                    ret.Add(c);
                    return ret;
                }

                var newStringList = StringList.ToList();
                newStringList.RemoveAt(0);
                foreach (var sc in StringList[0])
                {
                    var resultList = Rec(sc.ToString(), newStringList);
                    foreach (var resultString in resultList)
                    {
                        ret.Add(c.ToString() + resultString);
                    }
                }

                return ret;
            }
        }
    }

}
