using System;
using System.Collections.Generic;

namespace LeetCode_860_Lemonade_Change
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var bills = new int[] { 5, 5, 10, 10, 20 };

            var s = new Solution();
            Console.WriteLine(s.LemonadeChange(bills));
        }

        public class Solution
        {
            public bool LemonadeChange(int[] bills)
            {
                var dict = new Dictionary<int, int>()
                {
                    { 5,0 }, { 10,0 }, { 20,0 }
                };

                for (int i = 0; i < bills.Length; i++)
                {
                    if (bills[i] == 5)
                    {
                        dict[5]++;
                    }
                    else if (bills[i] == 10)
                    {
                        if (dict[5] == 0)
                        {
                            return false;
                        }

                        dict[5]--;
                        dict[10]++;
                    }
                    else if (bills[i] == 20)
                    {
                        if (dict[10] > 0 && dict[5] > 0)
                        {
                            dict[5]--;
                            dict[10]--;
                            dict[20]++; // 可以不用
                        }
                        else if (dict[10] == 0 && dict[5] >= 3)
                        {
                            dict[5] -= 3;
                            dict[20]++; // 可以不用
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }
    }
}