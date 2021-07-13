using System;
using System.Collections.Generic;

namespace LeetCode_383_Ransom_Note
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var rNote = "aabb";

            var magazine = "aab";

            var s = new Solution();
            Console.WriteLine(s.CanConstruct(rNote, magazine));
        }

        public class Solution
        {
            public bool CanConstruct(string ransomNote, string magazine)
            {
                var magazineDp = new Dictionary<char, int>();

                foreach (var mChar in magazine)
                {
                    magazineDp[mChar] = magazineDp.ContainsKey(mChar) ? (magazineDp[mChar] + 1) : 1;
                }

                foreach (var rChar in ransomNote)
                {
                    if (!magazineDp.ContainsKey(rChar) || magazineDp[rChar] < 1)
                    {
                        return false;
                    }
                    else
                    {
                        magazineDp[rChar]--;
                    }
                }

                return true;
            }
        }
    }
}