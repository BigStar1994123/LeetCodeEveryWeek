using System;

namespace Leetcode38_Count_and_Say
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new Solution();
            var level = 5;
            var result = s.CountAndSay(level);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public string CountAndSay(int n)
        {
            var str = "1";
            for(var i = 1; i < n; i++)
            {
                var tempStr = "";
                var counter = 0;
                for (var j = 0; j < str.Length; j++)
                {
                    counter++;
                    if (j == str.Length - 1 || str[j] != str[j + 1])
                    {
                        tempStr += counter.ToString() + str[j];
                        counter = 0;
                    }
                }
                str = tempStr;
            }

            return str;
        }
    }
}
