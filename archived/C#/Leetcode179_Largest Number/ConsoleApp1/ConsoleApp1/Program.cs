using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            //var a = new List<int> { 1, 2, 3, 4, 5, 99, 98 };
            //var a = new List<int> { 3, 30, 34, 5, 9 };
            var a = new List<int> { 111311, 1311 };
            Console.WriteLine(s.LargestNumber(a.ToArray()));

            Console.Read();
        }
    }

    public class Solution
    {
        public string LargestNumber(int[] nums)
        {
            var result = string.Empty;
            var resultList = new List<int>();
            var resultLinkList = new LinkedList<int>();

            foreach (var num in nums)
            {
                if (resultLinkList.Count == 0)
                {
                    resultLinkList.AddLast(num);
                }
                else
                {
                    var i = resultLinkList.First;
                    while (true)
                    {
                        if (i == null)
                        {
                            resultLinkList.AddLast(num);
                            break;
                        }

                        if (Compare(num, i.Value))
                        {
                            resultLinkList.AddBefore(i, num);
                            break;
                        }

                        i = i.Next;
                    }
                }
            }

            foreach (var item in resultLinkList)
            {
                result += item;
            }

            if (result[0] == '0')
            {
                return "0";
            }

            return result;
        }

        private bool Compare(int x, int y)
        {
            var s1 = x.ToString() + y.ToString();
            var s2 = y.ToString() + x.ToString();

            return s1.CompareTo(s2) > 0;
        }
    }
}